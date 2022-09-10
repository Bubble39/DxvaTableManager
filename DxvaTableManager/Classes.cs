using System.Collections.Generic;
using System;
using System.Linq;

public class module : Entry
{
    public Attr attr;
    public string cos;
    public override List<string> getEntry()
    {
        List<string> x = new List<string>();
        string a = "module."+entry+".";
        x.Add(a + "attr=" + (int)attr);
        x.Add(a + "chara=" + chara);
        x.Add(a + "cos=" + cos);
        x.Add(a + "id=" + id);
        x.Add(a + "name=" + name);
        x.Add(a + "ng=" + Convert.ToInt32(ng));
        x.Add(a + "shop_ed_day=" + shop_ed_day);
        x.Add(a + "shop_ed_month=" + shop_ed_month);
        x.Add(a + "shop_ed_year=" + shop_ed_year);
        x.Add(a + "shop_price=" + shop_price);
        x.Add(a + "shop_st_day=" + shop_st_day);
        x.Add(a + "shop_st_month=" + shop_st_month);
        x.Add(a + "shop_st_year=" + shop_st_year);
        x.Add(a + "sort_index=" + sort_index);
        return x;
    }
}

public class Entry
{
    public string entry;
    public string chara;
    public int id;
    public string name;
    public bool ng;
    public int shop_ed_day = 1;
    public int shop_ed_month = 1;
    public int shop_ed_year = 2029;
    public string shop_price;
    public int shop_st_day = 2;
    public int shop_st_month = 7;
    public int shop_st_year = 2009;
    public int sort_index;
    public virtual List<string> getEntry()
    {
        List<string> x = new List<string>();
        return x;
    }
}

public enum Attr
{
    Default_N = 0,
    Default_FS = 4,
    Default_CT = 8,
    Default_PL = 12,
    Swimsuit_N = 1,
    Swimsuit_FS = 5,
    Swimsuit_CT = 9,
    Swimsuit_PL = 13,
    NoSwap_N = 2,
    NoSwap_FS = 6,
    NoSwap_CT = 10,
    NoSwap_PL = 14,
    TShirt = 16
}
public class cosEntry
{
    public string entry;
    public int id;
    public List<int> items = new List<int>();
    public List<string> getEntry()
    {
        List<string> x = new List<string>();
        x.Add("cos." + entry + ".id=" + id);
        int count = 0;
        foreach(int i in items)
        {
            x.Add("cos." + entry + ".item." + count + "=" + i);
            count++;
        }
        x.Add("cos." + entry + ".item.length=" + count);
        return x;
    }
}
public class dataSetTex
{
    public string entry;
    public string chg;
    public string org;
}
public class itemEntry
{
    public string entry;
    public int attr = 1;
    public int rpk = -1;
    public string uid;
    public List<dataSetTex> dataSetTexes = new List<dataSetTex>();
    public int desID;
    public decimal face_depth;
    public int flag = 0;
    public string name;
    public int no;
    public List<string> objset = new List<string>();
    public int orgItm;
    public int subID;
    public int type;
    public List<string> getEntry()
    {
        List<string> x = new List<string>();
        x.Add("item." + entry + ".attr=" + attr);
        x.Add("item." + entry + ".data.obj.0.rpk=" + rpk);
        x.Add("item." + entry + ".data.obj.0.uid=" + uid);
        x.Add("item." + entry + ".data.obj.length=1");
        int count = 0;
        foreach (dataSetTex tex in dataSetTexes)
        {
            tex.entry = count.ToString();
            count++;
        }
        foreach(dataSetTex tex in dataSetTexes.OrderBy(o => o.entry))
        {
            x.Add("item." + entry + ".data.tex." + tex.entry + ".chg=" + tex.chg);
            x.Add("item." + entry + ".data.tex." + tex.entry + ".org=" + tex.org);
        }
        if(dataSetTexes.Count > 0)
        {
            x.Add("item." + entry + ".data.tex.length=" + count);
        }
        x.Add("item." + entry + ".des_id=" + desID);
        x.Add("item." + entry + ".exclusion=0");
        x.Add("item." + entry + ".face_depth=" + face_depth);
        x.Add("item." + entry + ".flag=" + flag);
        x.Add("item." + entry + ".name=" + name);
        x.Add("item." + entry + ".no=" + no);
        if(objset.Count > 1)
        {
            x.Add("item." + entry + ".objset.0=" + objset[0]);
            x.Add("item." + entry + ".objset.1=" + objset[1]);
            x.Add("item." + entry + ".objset.length=2");
        }
        else
        {
            x.Add("item." + entry + ".objset.0=" + objset[0]);
            x.Add("item." + entry + ".objset.length=1");
        }
        x.Add("item." + entry + ".org_itm=" + orgItm);
        x.Add("item." + entry + ".point=0");
        x.Add("item." + entry + ".sub_id=" + subID);
        x.Add("item." + entry + ".type=" + type);
        return x;
    }
}

public class cstm_item : Entry
{
    public int bind_module;
    public int obj_id;
    public string parts;
    public bool sell_type;
    public override List<string> getEntry()
    {
        List<string> x = new List<string>();
        string a = "cstm_item." + entry + ".";
        x.Add(a + "bind_module=" + bind_module);
        x.Add(a + "chara=" + chara);
        x.Add(a + "id=" + id);
        x.Add(a + "name=" + name);
        x.Add(a + "ng=" + Convert.ToInt32(ng));
        x.Add(a + "obj_id=" + obj_id);
        x.Add(a + "parts=" + parts);
        x.Add(a + "sell_type=" + Convert.ToInt32(sell_type));
        x.Add(a + "shop_ed_day=" + shop_ed_day);
        x.Add(a + "shop_ed_month=" + shop_ed_month);
        x.Add(a + "shop_ed_year=" + shop_ed_year);
        x.Add(a + "shop_price=" + shop_price);
        x.Add(a + "shop_st_day=" + shop_st_day);
        x.Add(a + "shop_st_month=" + shop_st_month);
        x.Add(a + "shop_st_year=" + shop_st_year);
        x.Add(a + "sort_index=" + sort_index);
        return x;
    }
}
public class chritmFile
{
    public string chara;
    public List<cosEntry> costumes;
    public List<itemEntry> items;
    public string getFileName()
    {
        string x = chara + "itm_tbl.txt";
        return x;
    }
}