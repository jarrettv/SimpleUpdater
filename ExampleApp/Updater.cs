// Updater.cs
//
// Copyright 2011 Jarrett Vance

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using ExampleApp.Properties;

namespace ExampleApp
{
    public enum UpdateStatus : byte
    {
        NoUpdate = 0,
        UpdateFailed = 1,
        NewVersionAvailable = 2
    }

    public static class Updater
    {
        /// <summary>
        /// Checks for an update and shows the update dialog if there is an update available.
        /// </summary>
        /// <param name="showUpdateDialog"></param>
        /// <returns></returns>
        public static UpdateStatus CheckForUpdate(Action<Version, Version, XDocument> showUpdateDialog)
        {
            try
            {
                // get current version
                Version appVersion = Assembly.GetExecutingAssembly().GetName().Version;

                // download manifest
                XDocument doc = XDocument.Load(Settings.Default.RemoteManifest);

                // if newer, display update dialog
                Version newestVersion = new Version((string)doc.Root.Element("version"));
                if (newestVersion > appVersion)
                {
                    showUpdateDialog(appVersion, newestVersion, doc);
                    return UpdateStatus.NewVersionAvailable;
                }
                return UpdateStatus.NoUpdate;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return UpdateStatus.UpdateFailed;
        }

        /// <summary>
        /// Saves the manifest locally and launches the updater app
        /// </summary>
        /// <param name="manifest"></param>
        public static void LaunchUpdater(XDocument manifest)
        {
            // save remote manifest locally
            string file = Application.ExecutablePath.Replace(".EXE", ".exe").Replace(".exe", ".manifest");
            manifest.Save(file);

            // launch updater
            string updater = GetUpdaterPath();
            System.Diagnostics.Process.Start(updater, "\"" + file + "\" \"" + Application.ExecutablePath + "\"");
        }

        /// <summary>
        /// Removes old updater and renames new updater after a small delay, call upon startup
        /// </summary>
        public static void UpdateUpdater()
        {
            ThreadPool.QueueUserWorkItem((x) =>
            {
                Thread.Sleep(1000);

                // rename updater after update
                try
                {
                    string updaterPath = GetUpdaterPath();
                    string tmpUpdaterPath = updaterPath.Replace(".exe", ".exe.tmp");
                    if (File.Exists(tmpUpdaterPath))
                    {
                        File.Delete(updaterPath);
                        File.Move(tmpUpdaterPath, updaterPath);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                }
            });
        }

        private static string GetUpdaterPath()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            return Path.Combine(appPath, "Updater.exe");
        }
    }
}
