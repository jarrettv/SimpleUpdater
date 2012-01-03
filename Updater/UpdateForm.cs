// UpdateForm.cs
//
// Copyright 2010 Jarrett Vance
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// Linking this library statically or dynamically with other modules is
// making a combined work based on this library.  Thus, the terms and
// conditions of the GNU General Public License cover the whole
// combination.
// 
// As a special exception, the copyright holders of this library give you
// permission to link this library with independent modules to produce an
// executable, regardless of the license terms of these independent
// modules, and to copy and distribute the resulting executable under
// terms of your choice, provided that you also meet, for each linked
// independent module, the terms and conditions of the license of that
// module.  An independent module is a module which is not derived from
// or based on this library.  If you modify this library, you may extend
// this exception to your version of the library, but you are not
// obligated to do so.  If you do not wish to do so, delete this
// exception statement from your version.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using ICSharpCode.SharpZipLib.Zip;

namespace JarrettVance.Updater
{
    public partial class UpdateForm : Form
    {
        private const int extraWaitMilliseconds = 1000;

        public string Manifest { get; set; }
        public string Executible { get; set; }
        protected string ZipFile { get; set; }
        protected bool Updating { get; set; }

        public UpdateForm()
        {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            Updating = true;

            try
            {
                ZipFile = System.IO.Path.GetTempFileName();

                // read manifest
                XDocument doc = XDocument.Load(Manifest);
                string title = Path.GetFileNameWithoutExtension(Manifest);
                lblTitle.Text = string.Format(lblTitle.Text, title);
                lblInfo.Text = string.Format(lblInfo.Text, title, (string)doc.Root.Element("version"), (DateTime)doc.Root.Element("date"));
                linkInfo.LinkClicked += (o, args) =>
                    {
                        linkInfo.LinkVisited = true;
                        System.Diagnostics.Process.Start((string)doc.Root.Element("info"));
                    };

                // download update zip
                lblStatus.Text = "Downloading update...";
                using (var web = new WebClient())
                {
                    web.DownloadProgressChanged += new DownloadProgressChangedEventHandler((s, args) => progressBar1.Value = args.ProgressPercentage);
                    web.DownloadFileCompleted += new AsyncCompletedEventHandler(OnDownloadCompleted);
                    web.DownloadFileAsync(new Uri((string)doc.Root.Element("download")), ZipFile);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                lblStatus.Text = "Error: failed download";
                Updating = false;
            }
        }

        private void OnDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            System.Threading.Thread.Sleep(extraWaitMilliseconds); //don't go too fast
            if (e.Error != null)
            {
                Trace.WriteLine(e.Error);
                lblStatus.Text = "Error: failed download";
                Updating = false;
                return;
            }

            lblStatus.Text = "Unzipping update...";
            progressBar1.Value = 0;
            picDownload.Visible = false;
            picZip.Visible = true;

            new System.Threading.Thread(new ThreadStart(Unzip)).Start();
        }

        private void Unzip()
        {
            try
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);

                // unzip update
                using (var fileStream = new FileStream(ZipFile, FileMode.Open, FileAccess.Read))
                using (ZipInputStream s = new ZipInputStream(fileStream))
                {
                    ZipEntry entry;
                    while ((entry = s.GetNextEntry()) != null)
                    {
                        string path = Path.GetDirectoryName(Path.Combine(appPath, entry.Name));

                        if (entry.IsDirectory)
                        {
                            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                        }
                        else
                        {
                            //write the data to disk
                            string name = entry.Name.EndsWith("Updater.exe") ? entry.Name.Replace(".exe", ".exe.tmp") : entry.Name;
                            using (FileStream fs = File.Create(Path.Combine(appPath, name)))
                            {
                                byte[] buffer = new byte[1024];
                                int read = buffer.Length;
                                while (true)
                                {
                                    read = s.Read(buffer, 0, buffer.Length);
                                    if (read > 0) fs.Write(buffer, 0, read);
                                    else break;
                                }
                            }
                        }
                        UpdateProgress(((float)s.Position / (float)fileStream.Length) * 100F);
                        System.Threading.Thread.Sleep(extraWaitMilliseconds); //don't go too fast
                    }
                }
                UnzipFinished();
            }
            catch (Exception ex)
            {
                UnzipFailed(ex);
            }
        }

        private void UnzipFinished()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UnzipFinished));
                return;
            }

            Cleanup();
        }

        private void UnzipFailed(Exception ex)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Exception>(UnzipFailed), ex);
                return;
            }

            Trace.WriteLine(ex);
            lblStatus.Text = "Error: failed unzip";
            Updating = false;
        }

        private void UpdateProgress(float percent)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<float>(UpdateProgress), percent);
                return;
            }

            progressBar1.Value = (int)percent;
        }

        private void Cleanup()
        {
            System.Threading.Thread.Sleep(extraWaitMilliseconds); //don't go too fast
            lblStatus.Text = "Cleaning up...";
            progressBar1.Value = 50;
            picZip.Visible = false;
            picCleanup.Visible = true;

            try
            {
                // delete zip
                System.IO.File.Delete(ZipFile);
                new System.Threading.Thread(new ThreadStart(Finish)).Start();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                lblStatus.Text = "Error: failed cleanup";
                Updating = false;
            }
        }

        private void Finish()
        {
            if (InvokeRequired)
            {
                System.Threading.Thread.Sleep(extraWaitMilliseconds); //don't go too fast
                Invoke(new Action(Finish));
                return;
            }

            progressBar1.Value = 100;
            lblStatus.Text = "Finished!";
            System.Threading.Thread.Sleep(extraWaitMilliseconds); //don't go too fast
            Updating = false;

            try
            {
                // relaunch app
                System.Diagnostics.Process.Start(Executible);

                // close
                this.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                lblStatus.Text = "Error: failed relaunch";
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (Updating)
            {
                e.Cancel = MessageBox.Show("Stop the update and close?", "Update in Progress",
                    MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes;
            }
        }

    }
}
