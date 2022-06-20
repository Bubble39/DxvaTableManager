using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MikuMikuLibrary;
using MikuMikuLibrary.IO;
using MikuMikuLibrary.Archives;

namespace DivaTableManager
{
    public partial class chritm : Form
    {
        public chritm()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();
        itemEntry curItem;
        public static ListBox box = new ListBox();
        public static List<int> mIndex = new List<int>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count < 2)
            {
                curItem.objset.Add(comboBox1.Text);
                comboBox1.Items.Add(comboBox1.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Supported Files|*chritm_prop.farc";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Code.charaPath = ofd.FileName;
                Code.readCharaFile(Code.charaPath);
                initChr();
            }
        }

        private void chritm_Load(object sender, EventArgs e)
        {
            initChr();
        }
        private void initChr()
        {
            chrSel.Items.Clear();
            foreach (KeyValuePair<string, chritmFile> entry in Code.chritms)
            {
                chrSel.Items.Add(entry.Key);
            }
            if (Code.chritms.Count > 0)
            {
                chrSel.SelectedItem = chrSel.Items[0];
                KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
                loadBoxes(found.Key, true);
            }
        }

        private void loadBoxes(string chara, bool posZero)
        {
            if (Code.chritms.Count > 0)
            {
                int index = MikuItemBox.SelectedIndex;
                List<string> data = new List<string>();
                foreach (cosEntry x in Code.chritms[chara].costumes)
                {
                    data.Add("COS: " + x.id);
                }
                MikuCosBox.DataSource = data;
                if (posZero & MikuCosBox.Items.Count > 0)
                {
                    MikuCosBox.SelectedIndex = 0;
                }
                data = new List<string>();
                foreach (itemEntry x in Code.chritms[chara].items)
                {
                    data.Add(x.no + ": " + x.name);
                }
                MikuItemBox.DataSource = data;
                if(index != 0 & !posZero)
                {
                    MikuItemBox.SelectedIndex = index;
                }
                else
                {
                    MikuItemBox.SelectedIndex = 0;
                }
            }
        }

        private void MikuCosBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            popMainBoxes();
            KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
            int id = Code.chritms[found.Key].costumes[MikuCosBox.SelectedIndex].id;
            numericUpDown3.Value = id;
        }

        private void popMainBoxes()
        {
            MikuCosList.Items.Clear();
            MikuIDBox.Items.Clear();
            orgItmBox.Items.Clear();
            KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
            foreach (int x in Code.chritms[found.Key].costumes[MikuCosBox.SelectedIndex].items)
            {
                MikuCosList.Items.Add(x);
            }
            MikuCosList.SelectedIndex = 0;
            label1.Text = "COS Count: " + Code.chritms[found.Key].costumes.Count;
            foreach (itemEntry x in Code.chritms[found.Key].items)
            {
                MikuIDBox.Items.Add(x.no);
            }
            MikuIDBox.SelectedIndex = 0;
        }

        private void chrSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Code.chritms.Count > 0)
            {
                KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
                loadBoxes(found.Key, true);
                MikuIDBox.Enabled = true;
            }
        }
        private void clearTexBox()
        {
            comboBox2.Items.Clear();
            tChgBox.Text = "";
            tOrgBox.Text = "";
            comboBox2.Text = "";
        }

        private void MikuItemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //curItem = Code.itemsList[chrSel.SelectedIndex][MikuItemBox.SelectedIndex];
            updateItem();
        }

        private void updateItem()
        {
            KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
            curItem = Code.chritms[found.Key].items[MikuItemBox.SelectedIndex];
            itemPresetsToolStripMenuItem.Enabled = true;
            faceDepthNum.Value = curItem.face_depth;
            textBox4.Text = curItem.name;
            numericUpDown2.Value = curItem.no;
            attrBox.Text = curItem.attr.ToString();
            desIdBox.Text = curItem.desID.ToString();
            subIdBox.Text = curItem.subID.ToString();
            rpkBox.Text = curItem.rpk.ToString();
            orgItmBox.Items.Add("0");
            foreach (itemEntry x in Code.chritms[found.Key].items)
            {
                orgItmBox.Items.Add(x.no);
            }
            orgItmBox.Text = curItem.orgItm.ToString();
            faceDepthNum.Value = (decimal)curItem.face_depth;
            typeNum.Value = (decimal)curItem.type;
            flagBox.Text = curItem.flag.ToString();
            comboBox1.Items.Clear();
            clearTexBox();
            foreach (string x in curItem.objset)
            {
                comboBox1.Items.Add(x);
            }
            comboBox1.Text = curItem.objset[0];
            textBox2.Text = curItem.uid;
            if (curItem.dataSetTexes.Count > 0)
            {
                popTexBox(curItem);
                comboBox2.SelectedIndex = 0;
            }
        }

        private void popTexBox(itemEntry item)
        {
            clearTexBox();
            int count = 0;
            if(item.dataSetTexes.Count != 0)
            {
                foreach (dataSetTex x in item.dataSetTexes)
                {
                    comboBox2.Items.Add(count);
                    count++;
                }
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                clearTexBox();
            }
        }

        private void MikuAdd_Click(object sender, EventArgs e)
        {
            if(MikuIDBox.Text.Length > 0)
            {
                MikuCosList.Items.Add(MikuIDBox.Text);
                KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
                Code.chritms[found.Key].costumes[MikuCosBox.SelectedIndex].items.Add(Int32.Parse(MikuIDBox.Text));
            }
        }

        private void MikuDel_Click(object sender, EventArgs e)
        {
            if(MikuCosList.Items.Count > 0)
            {
                int index = MikuCosList.SelectedIndex;
                if(index > -1)
                {
                    MikuCosList.Items.RemoveAt(index);
                    KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
                    Code.chritms[found.Key].costumes[MikuCosBox.SelectedIndex].items.RemoveAt(index);
                    if (index != 0)
                    {
                        MikuCosList.SelectedIndex = index - 1;
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Code.charaPath.Length > 0)
            {
                saveChr(Code.charaPath);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(curItem.dataSetTexes.Count > 0)
            {
                tChgBox.Text = curItem.dataSetTexes[comboBox2.SelectedIndex].chg;
                tOrgBox.Text = curItem.dataSetTexes[comboBox2.SelectedIndex].org;
            }
        }

        private void tOrgBox_TextChanged(object sender, EventArgs e)
        {
            if(comboBox2.Items.Count > 0)
            {
                curItem.dataSetTexes[comboBox2.SelectedIndex].org = tOrgBox.Text;
            }
        }

        private void tChgBox_TextChanged(object sender, EventArgs e)
        {
            if(comboBox2.Items.Count > 0)
            {
                curItem.dataSetTexes[comboBox2.SelectedIndex].chg = tChgBox.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = comboBox2.SelectedIndex;
            if (curItem.dataSetTexes.Count > 0)
            {
                curItem.dataSetTexes.RemoveAt(comboBox2.SelectedIndex);
                popTexBox(curItem);
                curItem.flag = 4; // Has tex swaps
                curItem.attr = 5;
            }
            else
            {
                clearTexBox();
                curItem.flag = 0; // No tex swaps
                curItem.attr = 1;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            addToCos((int)numericUpDown3.Value);
            MikuAdd.Enabled = true;
            MikuDel.Enabled = true;
            MikuIDBox.Enabled = true;
        }
        private void addToCos(int cos)
        {
            cosEntry temp = new cosEntry();
            temp.id = cos;
            temp.items.Add(500);
            temp.items.Add(1);
            temp.items.Add(301);
            KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
            Code.chritms[found.Key].costumes.Add(temp);
            loadBoxes(found.Key, false);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
            if (Code.chritms[found.Key].costumes.Count > 0)
            {
                Code.chritms[found.Key].costumes.RemoveAt(MikuCosBox.SelectedIndex);
                loadBoxes(found.Key, false);
                if (Code.chritms[found.Key].costumes.Count == 0)
                {
                    MikuCosList.Items.Clear();
                    MikuAdd.Enabled = false;
                    MikuDel.Enabled = false;
                    MikuIDBox.Enabled = false;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text != curItem.uid)
            {
                curItem.uid = textBox2.Text;
                curItem.rpk = -1;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "FARC files (*.farc)|*.farc";
            sfd.FileName = "mod_chritm_prop.farc";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                saveChr(sfd.FileName);
            }
        }

        private void saveChr(string path)
        {
            if (path.Length > 0)
            {
                var farc = new FarcArchive();
                foreach (KeyValuePair<string, chritmFile> x in Code.chritms)
                {
                    int count = 0;
                    foreach (cosEntry cos in x.Value.costumes)
                    {
                        cos.entry = count.ToString();
                        count++;
                    }
                    count = 0;
                    foreach (itemEntry item in x.Value.items)
                    {
                        item.entry = count.ToString();
                        count++;
                    }
                }
                foreach (KeyValuePair<string, chritmFile> x in Code.chritms)
                {
                    MemoryStream outputSource = new MemoryStream();
                    using (StreamWriter tw = new StreamWriter(outputSource))
                    {
                        tw.AutoFlush = true;
                        foreach (cosEntry c in x.Value.costumes.OrderBy(o => o.entry))
                        {
                            foreach (string w in c.getEntry())
                            {
                                tw.WriteLine(w);
                            }
                        }
                        tw.WriteLine("cos.length=" + x.Value.costumes.Count);
                        foreach (itemEntry i in x.Value.items.OrderBy(o => o.entry))
                        {
                            foreach (string w in i.getEntry())
                            {
                                tw.WriteLine(w);
                            }
                        }
                        tw.WriteLine("item.length=" + x.Value.items.Count);
                        farc.Add(x.Value.getFileName(), outputSource, true, ConflictPolicy.Replace);
                        farc.IsCompressed = true;
                        farc.Save(path);
                        tw.Close();
                    }
                }
                farc.Dispose();
            }
            else { MessageBox.Show("That didn't work. Try opening a table first.", "Error"); }
        }

        private void button6_Click(object sender, EventArgs e) // Remove Item
        {
            itemDelete(MikuItemBox.SelectedIndex);
            KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
            loadBoxes(found.Key, false);
        }
        public void itemDelete(int index)
        {
            KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
            Code.chritms[found.Key].items.RemoveAt(index);
        }

        private void eyeTextureSwapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curItem.subID = 24;
            curItem.desID = 0;
            curItem.rpk = 1;
            curItem.uid = "NULL";
            curItem.attr = 37;
            curItem.type = 2;
            curItem.orgItm = 0;
            curItem.face_depth = 0;
            updateItem();
        }

        private void attrBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curItem.attr = Int32.Parse(attrBox.Text);
        }

        private void contactLensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curItem.subID = 6;
            curItem.desID = 1;
            curItem.rpk = -1;
            curItem.uid = "ENTERUIDHERE";
            curItem.attr = 1;
            curItem.type = 0;
            curItem.orgItm = 0;
            curItem.face_depth = 0;
            updateItem();
        }

        private void subIdBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curItem.subID = Int32.Parse(subIdBox.Text);
        }

        private void desIdBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curItem.desID = Int32.Parse(desIdBox.Text);
        }

        private void rpkBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curItem.rpk = Int32.Parse(rpkBox.Text);
        }

        private void typeNum_ValueChanged(object sender, EventArgs e)
        {
            curItem.type = (int)typeNum.Value;
        }

        private void orgItmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curItem.orgItm = Int32.Parse(orgItmBox.Text);
        }

        private void faceDepthNum_ValueChanged(object sender, EventArgs e)
        {
            curItem.face_depth = faceDepthNum.Value;
        }

        private void flagBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curItem.flag = Int32.Parse(flagBox.Text);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) // Change No
        {
            if(curItem.no != (int)numericUpDown2.Value)
            {
                curItem.no = (int)numericUpDown2.Value;
                KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
                loadBoxes(found.Key, false);
            }
        }

        private void button4_Click(object sender, EventArgs e) // Add Tex Swap
        {
            dataSetTex tex = new dataSetTex();
            tex.chg = tChgBox.Text;
            tex.org = tOrgBox.Text;
            curItem.dataSetTexes.Add(tex);
            comboBox2.Items.Add(comboBox2.Items.Count);
        }

        private void button2_Click(object sender, EventArgs e) // Remove Objset
        {
            if(comboBox1.Items.Count > 1)
            {
                curItem.objset.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e) // Add Item
        {
            itemEntry item = new itemEntry();
            item.name = "DUMMY";
            item.no = 4999;
            item.subID = 0;
            item.type = 0;
            item.desID = 0;
            item.face_depth = 0;
            item.uid = "ENTER UID HERE";
            item.rpk = -1;
            item.objset.Add("tempitm001");
            KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
            Code.chritms[found.Key].items.Add(item);
            loadBoxes(found.Key, false);
        }

        private void deleteShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Form.ActiveForm.ActiveControl == MikuItemBox)
            {
                KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
                itemDelete(MikuItemBox.SelectedIndex);
                loadBoxes(found.Key, false);
            }
        }

        private void multiDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mIndex.Clear();
            MultiDeteleItem mdi = new MultiDeteleItem();
            box = MikuItemBox;
            mdi.ShowDialog();
            KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
            int count = 0; // add one for every one delete or it'll start deleting unintended indexes
            foreach (int x in mIndex)
            {
                itemDelete(x - count);
                count++;
            }
            loadBoxes(found.Key, false);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            
            KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
            if((int)numericUpDown3.Value != Code.chritms[found.Key].costumes[MikuCosBox.SelectedIndex].id)
            {
                Code.chritms[found.Key].costumes[MikuCosBox.SelectedIndex].id = (int)numericUpDown3.Value;
                int index = MikuCosBox.SelectedIndex;
                List<string> data = new List<string>();
                foreach (cosEntry x in Code.chritms[found.Key].costumes)
                {
                    data.Add("COS: " + x.id);
                }
                MikuCosBox.DataSource = data;
                MikuCosBox.SelectedIndex = index;
            }
        }

        private void headAccessoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curItem.subID = 0;
            curItem.desID = 0;
            curItem.rpk = -1;
            curItem.uid = "ENTERUIDHERE";
            curItem.flag = 0;
            curItem.attr = 1;
            curItem.type = 0;
            curItem.orgItm = 0;
            curItem.face_depth = 0;
            updateItem();
        }

        private void faceAccessoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curItem.subID = 4;
            curItem.desID = 1;
            curItem.rpk = -1;
            curItem.uid = "ENTERUIDHERE";
            curItem.flag = 0;
            curItem.attr = 1;
            curItem.type = 0;
            curItem.orgItm = 0;
            curItem.face_depth = 0;
            updateItem();
        }

        private void chestAccessoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curItem.subID = 8;
            curItem.desID = 2;
            curItem.rpk = -1;
            curItem.uid = "ENTERUIDHERE";
            curItem.flag = 0;
            curItem.attr = 1;
            curItem.type = 0;
            curItem.orgItm = 0;
            curItem.face_depth = 0;
            updateItem();
        }

        private void backAccessoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curItem.subID = 16;
            curItem.desID = 2;
            curItem.rpk = -1;
            curItem.uid = "ENTERUIDHERE";
            curItem.flag = 0;
            curItem.attr = 1;
            curItem.type = 0;
            curItem.orgItm = 0;
            curItem.face_depth = 0;
            updateItem();
        }

        private void hairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curItem.subID = 1;
            curItem.desID = 0;
            curItem.rpk = -1;
            curItem.uid = "ENTERUIDHERE";
            curItem.flag = 0;
            curItem.attr = 1;
            curItem.type = 0;
            curItem.orgItm = 0;
            curItem.face_depth = 0;
            updateItem();
        }

        private void bodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curItem.subID = 10;
            curItem.desID = 2;
            curItem.rpk = -1;
            curItem.uid = "ENTERUIDHERE";
            curItem.flag = 0;
            curItem.attr = 1;
            curItem.type = 1;
            curItem.orgItm = 0;
            curItem.face_depth = 0;
            updateItem();
        }

        private void handsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curItem.subID = 14;
            curItem.desID = 2;
            curItem.rpk = -1;
            curItem.uid = "ENTERUIDHERE";
            curItem.flag = 0;
            curItem.attr = 1;
            curItem.type = 0;
            curItem.orgItm = 0;
            curItem.face_depth = 0;
            updateItem();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                curItem.name = textBox4.Text;
                KeyValuePair<string, chritmFile> found = Code.chritms.ElementAt(chrSel.SelectedIndex);
                loadBoxes(found.Key, false);
            }
        }
    }
}
