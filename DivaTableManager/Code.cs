using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections;
using System.Windows.Forms;
using MikuMikuLibrary.IO;
using MikuMikuLibrary.Sprites;
using MikuMikuLibrary.Archives;
using MikuMikuLibrary.Textures.Processing;
using System.Drawing;

public class Code
{
    public static List<moduleEntry> moduleEntries = new List<moduleEntry>();
    public static List<int> usedID = new List<int>();
    public static string modulePath;
    public static string outputPath;
    public static Bitmap moduleImageBitmap;


    // If the module tbl path has been set, run the writing code upon clicking the save button
    // If the module tbl path has not been set, open a messagebox alerting them of the error
    public static void SaveButton_Click()
    {
        if (modulePath != null)
        {
            outputPath = modulePath;
            var farc = new FarcArchive();
            moduleEntries.OrderBy(x => x.entry);
            MemoryStream outputSource = new MemoryStream();
            using (StreamWriter tw = new StreamWriter(outputSource))
            {
                tw.AutoFlush = true;
                foreach (moduleEntry entry in moduleEntries.OrderBy(x => x.entry))
                {
                    tw.WriteLine("module." + entry.entry + ".attr=" + entry.attr);
                    tw.WriteLine("module." + entry.entry + ".chara=" + entry.chara);
                    tw.WriteLine("module." + entry.entry + ".cos=" + entry.cos);
                    tw.WriteLine("module." + entry.entry + ".id=" + entry.id);
                    tw.WriteLine("module." + entry.entry + ".name=" + entry.name);
                    tw.WriteLine("module." + entry.entry + ".ng=" + entry.ng);
                    tw.WriteLine("module." + entry.entry + ".shop_ed_day=" + entry.shop_ed_day);
                    tw.WriteLine("module." + entry.entry + ".shop_ed_month=" + entry.shop_ed_month);
                    tw.WriteLine("module." + entry.entry + ".shop_ed_year=" + entry.shop_ed_year);
                    tw.WriteLine("module." + entry.entry + ".shop_price=" + entry.shop_price);
                    tw.WriteLine("module." + entry.entry + ".shop_st_day=" + entry.shop_st_day);
                    tw.WriteLine("module." + entry.entry + ".shop_st_month=" + entry.shop_st_month);
                    tw.WriteLine("module." + entry.entry + ".shop_st_year=" + entry.shop_st_year);
                    tw.WriteLine("module." + entry.entry + ".sort_index=" + entry.sort_index);
                }
                tw.WriteLine("module.data_list.length=" + moduleEntries.Count.ToString());
                Console.WriteLine("Wrote " + moduleEntries.Count + " entries and closed the stream.");
                farc.Add("gm_module_id.bin", outputSource, true, ConflictPolicy.Replace);
                farc.Save(outputPath);
                tw.Close();
            }
        }
        else { MessageBox.Show("Please open a table first.", "Error"); }
    }

    // Search for module. 0 - 999 to try and cover all bases then read them
    // into a switch case to get the info for each entry (name, etc.)
    public static void readModuleFile(string modulePath)
    {
        string searchModule;
        string[] containString;
        var farc = BinaryFile.Load<FarcArchive>(modulePath);
        foreach (var fileName in farc)
        {
            var source = farc.Open(fileName, EntryStreamMode.MemoryStream);
            using (var sr = new StreamReader(source, Encoding.UTF8))
            {
                string content = sr.ReadToEnd();
                for (int i = 0; i < 999; i++)
                {
                    var readEntry = new moduleEntry();
                    searchModule = "module." + i.ToString() + ".";
                    foreach (string fileLine in content.Split(new[] { '\n', '\r' }))
                    {
                        if (fileLine.Contains(searchModule))
                        {
                            readEntry.entry = i.ToString();
                            containString = fileLine.Split('=');
                            switch (containString[0])
                            {
                                case string a when a.Contains("attr"):
                                    readEntry.attr = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains("chara"):
                                    readEntry.chara = containString[1];
                                    break;
                                case string a when a.Contains("cos"):
                                    readEntry.cos = containString[1];
                                    break;
                                case string a when a.Contains("id"):
                                    readEntry.id = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains("name"):
                                    readEntry.name = containString[1];
                                    break;
                                case string a when a.Contains("ng"):
                                    readEntry.ng = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains("shop_ed_day"):
                                    readEntry.shop_ed_day = containString[1];
                                    break;
                                case string a when a.Contains("shop_ed_month"):
                                    readEntry.shop_ed_month = containString[1];
                                    break;
                                case string a when a.Contains("shop_ed_year"):
                                    readEntry.shop_ed_year = containString[1];
                                    break;
                                case string a when a.Contains("shop_price"):
                                    readEntry.shop_price = containString[1];
                                    break;
                                case string a when a.Contains("shop_st_day"):
                                    readEntry.shop_st_day = containString[1];
                                    break;
                                case string a when a.Contains("shop_st_month"):
                                    readEntry.shop_st_month = containString[1];
                                    break;
                                case string a when a.Contains("shop_st_year"):
                                    readEntry.shop_st_year = containString[1];
                                    break;
                                case string a when a.Contains("sort_index"):
                                    readEntry.sort_index = containString[1];
                                    Code.moduleEntries.Add(readEntry);
                                    break;
                            }
                        }
                    }
                }
            }
        }
        farc.Dispose();
    }

    public static int calcAttr(string readAttr)
    {
        int attrCalc;
        switch (readAttr)
        {
            case "Default (No Pack)":
                attrCalc = 0;
                break;
            case "Default (Future Sound)":
                attrCalc = 4;
                break;
            case "Default (Colorful Tone)":
                attrCalc = 8;
                break;
            case "Default (Prelude/Etc)":
                attrCalc = 12;
                break;
            case "Swimsuit (No Pack)":
                attrCalc = 1;
                break;
            case "Swimsuit (Future Sound)":
                attrCalc = 5;
                break;
            case "Swimsuit (Colorful Tone)":
                attrCalc = 9;
                break;
            case "Swimsuit (Prelude/Etc)":
                attrCalc = 13;
                break;
            case "Hair Unswappable (No Pack)":
                attrCalc = 2;
                break;
            case "Hair Unswappable (Future Sound)":
                attrCalc = 6;
                break;
            case "Hair Unswappable (Colorful Tone)":
                attrCalc = 10;
                break;
            case "Hair Unswappable (Prelude/Etc)":
                attrCalc = 14;
                break;
            default:
                attrCalc = 0;
                break;
        }
        return attrCalc;
    }

    public static string attrCalcText(int attr)
    {
        string attrCalcText;
        switch (attr)
        {
            case 0:
                attrCalcText = "Default (No Pack)";
                break;
            case 1:
                attrCalcText = "Swimsuit (No Pack)";
                break;
            case 2:
                attrCalcText = "Hair Unswappable (No Pack)";
                break;
            case 4:
                attrCalcText = "Default (Future Sound)";
                break;
            case 5:
                attrCalcText = "Swimsuit (Future Sound)";
                break;
            case 6:
                attrCalcText = "Hair Unswappable (Future Sound)";
                break;
            case 8:
                attrCalcText = "Default (Colorful Tone)";
                break;
            case 9:
                attrCalcText = "Swimsuit (Colorful Tone)";
                break;
            case 10:
                attrCalcText = "Hair Unswappable (Colorful Tone)";
                break;
            case 12:
                attrCalcText = "Default (Prelude/Etc)";
                break;
            case 13:
                attrCalcText = "Swimsuit (Prelude/Etc)";
                break;
            case 14:
                attrCalcText = "Hair Unswappable (Prelude/Etc)";
                break;
            default:
                attrCalcText = "Default (No Pack)";
                break;
        }
        return attrCalcText;
    }

    public static bool checkNG(int x)
    {
        if (x == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static bool checkIDuse(int x)
    {
        usedID.Clear();
        foreach (moduleEntry modEn in moduleEntries)
        {
            usedID.Add(modEn.id);
        }
        if (usedID.Contains(x))
        {
            return true;
        }
        else { return false; }
    }

    public static void addDummyEntry()
    {

        var dummyEntry = new moduleEntry();
        dummyEntry.entry = moduleEntries.Count.ToString();
        dummyEntry.attr = 0;
        dummyEntry.chara = "MIKU";
        dummyEntry.cos = "COS_001";
        dummyEntry.id = 999;
        dummyEntry.name = "ダミー";
        dummyEntry.ng = 0;
        dummyEntry.shop_ed_day = "3";
        dummyEntry.shop_ed_month = "9";
        dummyEntry.shop_ed_year = "2029";
        dummyEntry.shop_price = "0";
        dummyEntry.shop_st_day = "3";
        dummyEntry.shop_st_month = "9";
        dummyEntry.shop_st_year = "2009";
        dummyEntry.sort_index = "999";
        moduleEntries.Add(dummyEntry);

    }

    public static void setPictureBox(int id)
    {
        string idString = "000";
        if (id < 10)
        {
            idString = "00" + id.ToString();
        }
        if (id >= 10 && id <= 99)
        {
            idString = "0" + id;
        }
        if (id > 99)
        {
            idString = id.ToString();
        }
        string searchModule = "spr_sel_md" + idString + "cmn.farc";
        string mdataFoldersPath = DivaTableManager.Properties.Settings.Default.userDirectoryModulePreviewMDATA + "/";
        string[] dirs = Directory.GetDirectories(mdataFoldersPath);
        string pathName = (DivaTableManager.Properties.Settings.Default.userDirectoryModulePreview + "/" + searchModule);
        try
        {
            if (pathName != null)
            {
                var farc = BinaryFile.Load<FarcArchive>(pathName);
                if (farc != null)
                {
                    foreach (var fileName in farc)
                    {
                        var source = farc.Open(fileName, EntryStreamMode.MemoryStream);
                        var sprite = BinaryFile.Load<SpriteSet>(source);
                        var cropSprite = SpriteCropper.Crop(sprite.Sprites[0], sprite);
                        moduleImageBitmap = cropSprite;
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            moduleImageBitmap = null;
            if (mdataFoldersPath != null)
            {
                foreach (string dir in dirs)
                {
                    try
                    {
                        string MDATAPath = dir + "/rom/2d/" + searchModule;
                        var farcMdata = BinaryFile.Load<FarcArchive>(MDATAPath);
                        if (farcMdata != null)
                        {
                            foreach (var fileName in farcMdata)
                            {
                                var source = farcMdata.Open(fileName, EntryStreamMode.MemoryStream);
                                var sprite = BinaryFile.Load<SpriteSet>(source);
                                var cropSprite = SpriteCropper.Crop(sprite.Sprites[0], sprite);
                                moduleImageBitmap = cropSprite;
                                return;
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                    }
                    catch (DirectoryNotFoundException)
                    {
                    }
                }
            }
        }
    }
}
