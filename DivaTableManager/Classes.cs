public class moduleEntry
{
    public string entry;
    public int attr;
    public string chara;
    public string cos;
    public string edit_size;
    public int id;
    public string name;
    public int ng;
    public string sleeve;
    public string shop_ed_day;
    public string shop_ed_month;
    public string shop_ed_year;
    public string shop_price;
    public string shop_st_day;
    public string shop_st_month;
    public string shop_st_year;
    public string sort_index;
}

public class cosEntry
{
    public int entry;
    public int id;
    public int item0;
    public int item1;
    public int item2;
    public int item3;
    public int item4;
    public int item5;
    public int item6;
    public int itemLength;
}

public class itemEntry
{
    public int entry;
    public int attr;
    class dataSetObj
    {
        int rpk;
        string uid;
    }
    int dataSetObjLength;
    class dataSetTex
    {
        string chg;
        string org;
    }
    int dataSetTexLength;
    int desID;
    int exclusion;
    int faceDepth;
    int flag;
    string name;
    int no;
    string[] objSet;
    int objSetLength;
    int orgItm;
    int point;
    int subID;
    int type;
}
