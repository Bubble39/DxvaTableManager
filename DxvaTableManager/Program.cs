using System;
using System.Windows.Forms;

namespace DxvaTableManager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // ***this line is added*** // Thank you to the stackoverflow post i took this from, muchas gracias for your awesome work
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        // ***also dllimport of that function***
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
