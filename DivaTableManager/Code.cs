using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections;
using System.Windows.Forms;

public class Code
{
    public static List<moduleEntry> moduleEntries = new List<moduleEntry>();
    public static List<string> usedID = new List<string>();
    public static string modulePath;

    // If the module tbl path has been set, run the writing code upon clicking the save button
    // If the module tbl path has not been set, open a messagebox alerting them of the error
    public static void SaveButton_Click()
    {
        if (modulePath != null)
        {
            moduleEntries.OrderBy(x => x.entry);
            using (TextWriter tw = new StreamWriter(modulePath))
            {
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
                Console.WriteLine("Wrote " + moduleEntries.Count + " entries.");
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
        using (StreamReader sr = new StreamReader(modulePath))
        {
            var readAllLines = File.ReadAllLines(modulePath);
            for (int i = 0; i < 999; i++)
            {
                var readEntry = new moduleEntry();
                searchModule = "module." + i.ToString() + ".";
                foreach (string fileLine in readAllLines)
                {
                    if (fileLine.Contains(searchModule))
                    {
                        containString = fileLine.Split('.', '=');
                        readEntry.entry = containString[1];
                        switch (containString[2])
                        {
                            case "attr":
                                readEntry.attr = Int32.Parse(containString[3]);
                                break;
                            case "chara":
                                readEntry.chara = containString[3];
                                break;
                            case "cos":
                                readEntry.cos = containString[3];
                                break;
                            case "id":
                                readEntry.id = containString[3];
                                break;
                            case "name":
                                readEntry.name = containString[3];
                                break;
                            case "ng":
                                readEntry.ng = Int32.Parse(containString[3]);
                                break;
                            case "shop_ed_day":
                                readEntry.shop_ed_day = containString[3];
                                break;
                            case "shop_ed_month":
                                readEntry.shop_ed_month = containString[3];
                                break;
                            case "shop_ed_year":
                                readEntry.shop_ed_year = containString[3];
                                break;
                            case "shop_price":
                                readEntry.shop_price = containString[3];
                                break;
                            case "shop_st_day":
                                readEntry.shop_st_day = containString[3];
                                break;
                            case "shop_st_month":
                                readEntry.shop_st_month = containString[3];
                                break;
                            case "shop_st_year":
                                readEntry.shop_st_year = containString[3];
                                break;
                            case "sort_index":
                                readEntry.sort_index = containString[3];
                                Code.moduleEntries.Add(readEntry);
                                break;
                        }
                    }
                }
            }
        }
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
        if(x == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static bool checkIDuse(string x)
    {
        usedID.Clear();
        foreach(moduleEntry modEn in moduleEntries)
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
            dummyEntry.id = "999";
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
}
