using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections;
using System.Windows.Forms;

public class FormExtras
{
    public static string userDirectory2D;
    public static void exitToolStripMenuItem_Click()
    {
        System.Windows.Forms.Application.Exit();
    }

    public static void informationToolStripMenuItem_Click()
    {
        MessageBox.Show("DivaTableManager by Jay39w" + Environment.NewLine + "Thanks to all who helped me with learning C#!" + Environment.NewLine + "Current Version: v1.4 (08/04/2021)", "About DTM");
    }

    public static void moduleTableHelpToolStripMenuItem_Click()
    {
        MessageBox.Show("This program accepts gm_module_id.bin files and allows the user to edit them." + Environment.NewLine + Environment.NewLine +
            "If you do not have a gm_module_id.bin file, please extract it from mdata_gm_module_tbl.farc or gm_module_tbl.farc files using FarcPack or MikuMikuModel (by Skyth)" + Environment.NewLine + Environment.NewLine +
            "Please hover over any of the property names to find out more information about them." + Environment.NewLine + Environment.NewLine +
            "If you are still struggling, you can contact me for help at POI39#7310 on Discord.", "Help");
    }

    public static void mentalHelpToolStripMenuItem_Click()
    {
        MessageBox.Show("You can do this!", "Mental Help");
    }

    public static void characterItemTableHelpToolStripMenuItem_Click()
    {
        MessageBox.Show("This function is not yet implemented." + Environment.NewLine + "Please wait patiently.", "Help");
    }

    public static void setDirectory2d()
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        fbd.Description = "Please select your rom/2d folder";
        fbd.ShowDialog();
        if(fbd.SelectedPath != null)
        {
            DivaTableManager.Properties.Settings.Default.userDirectoryModulePreview = fbd.SelectedPath;
            DivaTableManager.Properties.Settings.Default.Save();
        }
    }
    public static void setDirectory2dMDATA()
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        fbd.Description = "Please select your MDATA folder";
        fbd.ShowDialog();
        if (fbd.SelectedPath != null)
        {
            DivaTableManager.Properties.Settings.Default.userDirectoryModulePreviewMDATA = fbd.SelectedPath;
            DivaTableManager.Properties.Settings.Default.Save();
        }
    }
}