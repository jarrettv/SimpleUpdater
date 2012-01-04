/*
 * Jarrett Vance 
 * see http://jvance.com/pages/SimpleUpdater.xhtml
*/
namespace ExampleApp
{
    using System;
    using System.Windows.Forms;

    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // (Add this line to your app)
            // Update the updater when file not in use.
            Updater.UpdateUpdater();

            Application.EnableVisualStyles();
            var f = new MainForm();
            Application.Run(f);
        }
    }
}
