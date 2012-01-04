/*
 * Jarrett Vance 
 * see http://jvance.com/pages/SimpleUpdater.xhtml
*/
namespace ExampleApp
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using ExampleApp.Properties;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // load state
            miAutoCheck.Checked = Settings.Default.AutoCheckForUpdate;

            // auto update
            if (Settings.Default.AutoCheckForUpdate)
                ThreadPool.QueueUserWorkItem((w) => Updater.CheckForUpdate(ShowUpdateDialog));
        }

        private void ShowUpdateDialog(Version appVersion, Version newVersion, XDocument doc)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Version, Version, XDocument>(ShowUpdateDialog), appVersion, newVersion, doc);
                return;
            }

            using (UpdateForm f = new UpdateForm())
            {
                f.Text = string.Format(f.Text, Application.ProductName, appVersion);
                f.MoreInfoLink = (string)doc.Root.Element("info");
                f.Info = string.Format(f.Info, newVersion, (DateTime)doc.Root.Element("date"));
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    Updater.LaunchUpdater(doc);
                    this.Close();
                }
            }
        }

        private void miUpdate_Click(object sender, EventArgs e)
        {
            UpdateStatus status = Updater.CheckForUpdate(ShowUpdateDialog);

            if (status == UpdateStatus.UpdateFailed)
                MessageBox.Show(this, "Failed to check for update.  Please ty again later.", "Warning");
            else if (status == UpdateStatus.NoUpdate)
                MessageBox.Show(this, "There are no updates available at this time.", "Update Check");
        }

        private void miAutoCheck_Click(object sender, EventArgs e)
        {
            Settings.Default.AutoCheckForUpdate = miAutoCheck.Checked;
            Settings.Default.Save();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
