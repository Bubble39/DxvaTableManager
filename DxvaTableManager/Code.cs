using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MikuMikuLibrary.IO;
using MikuMikuLibrary.Archives;

public class Code
{
    public static List<module> Modules = new List<module>();
    public static List<cstm_item> Items = new List<cstm_item>();
    public static List<int> usedID = new List<int>();
    public static string modulePath;
    public static string charaPath;
    public static string customPath;
    public static List<string> intakeTables = new List<string>();
    public static Dictionary<string, chritmFile> chritms = new Dictionary<string, chritmFile>();

    
    public static void readCharaFile(string charaPath)
    {
        chritms.Clear();
        var farc = BinaryFile.Load<FarcArchive>(charaPath);
        foreach (var fileName in farc)
        {
            if (fileName.EndsWith("_tbl.txt"))
            {
                var source = farc.Open(fileName, EntryStreamMode.MemoryStream);
                string name = fileName.Remove(3);
                StreamReader sr = new StreamReader(source);
                string content = sr.ReadToEnd();
                string[] vs = content.Split(new[] { '\n', '\r' });
                chritms.Add(name, readList(vs, name));
            }
            else
            {
                MessageBox.Show("Unexpected item in baggage area: " + fileName.ToString());
            }
        }
        farc.Dispose();
    }

    public static chritmFile readList(string[] content, string name)
    {
        List<cosEntry> tempCosList = new List<cosEntry>();
        List<itemEntry> tempItemList = new List<itemEntry>();
        cosEntry readEntry = new cosEntry();
        itemEntry itemEntry = new itemEntry();
        dataSetTex setTex = new dataSetTex();
        foreach (string fileLine in content)
        {
            string[] split = fileLine.Split('=');
            if(fileLine.Contains("cos.") && fileLine.Contains(".id="))
            {
                readEntry.id = int.Parse(split[1]);
            }
            if(fileLine.Contains("cos.") && fileLine.Contains("item.") && !fileLine.Contains("length"))
            {
                readEntry.items.Add(int.Parse(split[1]));
            }
            if(fileLine.Contains("cos.") && fileLine.Contains("item.length"))
            {
                tempCosList.Add(readEntry);
                readEntry = new cosEntry();
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".attr="))
            {
                itemEntry.attr = Int32.Parse(split[1]);
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".data.obj.0.rpk="))
            {
                itemEntry.rpk = Int32.Parse(split[1]);
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".data.obj.0.uid="))
            {
                itemEntry.uid = split[1];
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".chg="))
            {
                setTex.chg = split[1];
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".org="))
            {
                setTex.org = split[1];
                itemEntry.flag = 4;
                itemEntry.dataSetTexes.Add(setTex);
                setTex = new dataSetTex();
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".des_id="))
            {
                itemEntry.desID = int.Parse(split[1]);
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".face_depth="))
            {
                itemEntry.face_depth = decimal.Parse(split[1]);
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".flag="))
            {
                itemEntry.flag = Int32.Parse(split[1]);
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".name="))
            {
                itemEntry.name = split[1];
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".no="))
            {
                itemEntry.no = int.Parse(split[1]);
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".objset") && !fileLine.Contains("length"))
            {
                itemEntry.objset.Add(split[1]);
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".org_itm="))
            {
                itemEntry.orgItm = int.Parse(split[1]);
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".sub_id="))
            {
                itemEntry.subID = int.Parse(split[1]);
            }
            if (fileLine.Contains("item.") && fileLine.Contains(".type="))
            {
                itemEntry.type = int.Parse(split[1]);
                tempItemList.Add(itemEntry);
                itemEntry = new itemEntry();
            }
        }
        tempCosList = tempCosList.OrderBy(o => o.id).ToList();
        tempItemList = tempItemList.OrderBy(o => o.no).ToList();
        chritmFile x = new chritmFile();
        x.chara = name;
        x.costumes = tempCosList;
        x.items = tempItemList;
        return x;
    }

    public static void readModuleFile(string modulePath)
    {
        string[] containString;
        var farc = BinaryFile.Load<FarcArchive>(modulePath);
        foreach (var fileName in farc)
        {
            if (fileName.EndsWith(".bin"))
            {
                var source = farc.Open(fileName, EntryStreamMode.MemoryStream);
                using (var sr = new StreamReader(source, Encoding.UTF8))
                {
                    string content = sr.ReadToEnd();
                    var readEntry = new module();
                    foreach (string fileLine in content.Split(new[] { '\n', '\r' }))
                    {
                        if (fileLine.Contains("module."))
                        {
                            containString = fileLine.Split('=');
                            switch (containString[0])
                            {
                                case string a when a.Contains(".attr"):
                                    Enum.TryParse(containString[1], out Attr value);
                                    readEntry.attr = value;
                                    break;
                                case string a when a.Contains(".chara"):
                                    readEntry.chara = containString[1];
                                    break;
                                case string a when a.Contains(".cos"):
                                    readEntry.cos = containString[1];
                                    break;
                                case string a when a.Contains(".id"):
                                    readEntry.id = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains(".name"):
                                    readEntry.name = containString[1];
                                    break;
                                case string a when a.Contains(".ng"):
                                    int store = Int32.Parse(containString[1]);
                                    readEntry.ng = Convert.ToBoolean(store);
                                    break;
                                case string a when a.Contains("shop_price"):
                                    readEntry.shop_price = containString[1];
                                    break;
                                case string a when a.Contains("shop_st_day"):
                                    readEntry.shop_st_day = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains("shop_st_month"):
                                    readEntry.shop_st_month = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains("shop_st_year"):
                                    readEntry.shop_st_year = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains("sort_index"):
                                    readEntry.sort_index = Int32.Parse(containString[1]);
                                    Modules.Add(readEntry);
                                    readEntry = new module();
                                    break;
                            }
                        }
                    }
                }
            }
        }
        farc.Dispose();
        Modules = Modules.OrderBy(x => x.sort_index).ToList();
    }
    public static void readCustomFile(string customPath)
    {
        string[] containString;
        var farc = BinaryFile.Load<FarcArchive>(customPath);
        foreach (var fileName in farc)
        {
            if (fileName.EndsWith(".bin"))
            {
                var source = farc.Open(fileName, EntryStreamMode.MemoryStream);
                using (var sr = new StreamReader(source, Encoding.UTF8))
                {
                    string content = sr.ReadToEnd();
                    var readEntry = new cstm_item();
                    foreach (string fileLine in content.Split(new[] { '\n', '\r' }))
                    {
                        if (fileLine.Contains("cstm_item."))
                        {
                            containString = fileLine.Split('=');
                            switch (containString[0])
                            {
                                case string a when a.Contains(".bind_module"):
                                    readEntry.bind_module = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains(".chara"):
                                    readEntry.chara = containString[1];
                                    break;
                                case string a when a.Contains(".id"):
                                    readEntry.id = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains(".name"):
                                    readEntry.name = containString[1];
                                    break;
                                case string a when a.Contains(".ng"):
                                    int boolVal = int.Parse(containString[1]);
                                    readEntry.ng = Convert.ToBoolean(boolVal);
                                    break;
                                case string a when a.Contains(".obj_id"):
                                    readEntry.obj_id = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains(".sell_type"):
                                    int boolVal2 = int.Parse(containString[1]);
                                    readEntry.sell_type = Convert.ToBoolean(boolVal2);
                                    break;
                                case string a when a.Contains(".parts"):
                                    readEntry.parts = containString[1];
                                    break;
                                case string a when a.Contains("shop_price"):
                                    readEntry.shop_price = containString[1];
                                    break;
                                case string a when a.Contains("shop_st_day"):
                                    readEntry.shop_st_day = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains("shop_st_month"):
                                    readEntry.shop_st_month = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains("shop_st_year"):
                                    readEntry.shop_st_year = Int32.Parse(containString[1]);
                                    break;
                                case string a when a.Contains("sort_index"):
                                    readEntry.sort_index = Int32.Parse(containString[1]);
                                    Items.Add(readEntry);
                                    readEntry = new cstm_item();
                                    break;
                            }
                        }
                    }
                }
            }
        }
        farc.Dispose();
        Items = Items.OrderBy(x => x.id).ToList();
    }

    public static void saveFile<T>(string path, List<T> list) where T : Entry
    {
        if (path.Length > 0)
        {
            int count = 0;
            var farc = new FarcArchive();
            foreach (T x in list)
            {
                x.entry = count.ToString();
                count++;
            }
            MemoryStream outputSource = new MemoryStream();
            using (StreamWriter tw = new StreamWriter(outputSource))
            {
                tw.AutoFlush = true;
                foreach (T entry in list.OrderBy(x => x.entry))
                {
                    foreach (string x in entry.getEntry())
                    {
                        tw.WriteLine(x);
                    }
                }
                if (typeof(T) == typeof(module))
                {
                    tw.WriteLine(nameof(module) + ".data_list.length=" + list.Count);
                    farc.Add("gm_module_id.bin", outputSource, true, ConflictPolicy.Replace);
                }
                if (typeof(T) == typeof(cstm_item))
                {
                    tw.WriteLine(nameof(cstm_item) + ".data_list.length=" + list.Count);
                    farc.Add("gm_customize_item_id.bin", outputSource, true, ConflictPolicy.Replace);
                }
                farc.IsCompressed = true;
                farc.Save(path);
                tw.Close();
            }
            farc.Dispose();
        }
        else { MessageBox.Show("That didn't work. Try opening a table first.", "Error"); }
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
        foreach (module m in Modules)
        {
            usedID.Add(m.id);
        }
        if (usedID.Contains(x))
        {
            return true;
        }
        else { return false; }
    }

    public static void addDummyEntry(int index)
    {
        var dummyEntry = new module();
        dummyEntry.chara = "MIKU";
        dummyEntry.cos = "COS_001";
        dummyEntry.id = 999;
        dummyEntry.name = "DUMMY";
        dummyEntry.shop_price = "0";
        dummyEntry.attr = Attr.Default_N;
        dummyEntry.ng = false;
        dummyEntry.sort_index = 800;
        Modules.Insert(index ,dummyEntry);
    }
    public static void addDummyEntryCstm(int index)
    {
        var dummyEntry = new cstm_item();
        dummyEntry.chara = "ALL";
        dummyEntry.bind_module = -1;
        dummyEntry.id = 999;
        dummyEntry.name = "DUMMY";
        dummyEntry.shop_price = "0";
        dummyEntry.obj_id = 0;
        dummyEntry.parts = "ZUJO";
        dummyEntry.sell_type = false;
        dummyEntry.ng = false;
        dummyEntry.sort_index = 999;
        Items.Insert(index, dummyEntry);
    }
}
