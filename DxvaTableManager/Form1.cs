using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DxvaTableManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();
        public static module curModule;
        public static cstm_item curCustom;
        public static bool isModule;
        bool moduleExists;
        public void refreshModuleList()
        {
            if (Code.Modules != null)
            {
                var data = new List<string>();
                foreach(module x in Code.Modules)
                {
                    string name = x.name + " " + "(" + x.chara + ")";
                    data.Add(name);
                }
                listBox1.DataSource = data;
            }
            else { MessageBox.Show("this isnt supposed to happen", "what?"); }
        }
        public void refreshCustomList()
        {
            if (Code.Items != null)
            {
                var data = new List<string>();
                foreach (cstm_item x in Code.Items)
                {
                    string name = x.name + " " + "(" + x.chara + ")";
                    data.Add(name);
                }
                listBox2.DataSource = data;
            }
            else { MessageBox.Show("this isnt supposed to happen", "what?"); }
        }
        private void populateCharaBox(ComboBox box) // Adds items to the comboBox
        {
            string[] chara = { "MIKU", "RIN", "LEN", "LUKA", "KAITO", "MEIKO", "NERU", "HAKU", "SAKINE", "TETO" };
            box.Items.AddRange(chara);
            if(box == charaComboBox)
            {
                attrComboBox.DataSource = System.Enum.GetValues(typeof(Attr));
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Supported Files|*_module_tbl.farc; *chritm_prop.farc; *customize_item_tbl.farc|Module Table files|*_module_tbl.farc|Character Item Table files| *chritm_prop.farc|Customize Item Table files| *customize_item_tbl.farc|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Contains("module_tbl.farc"))
                {
                    if (Code.Modules != null)
                    {
                        Code.Modules.Clear(); //clear list of module entries when opening a new file
                    }
                    Code.modulePath = ofd.FileName; //set this on file opening to also allow for saving to use the path
                    Code.readModuleFile(ofd.FileName);
                    populateCharaBox(charaComboBox);
                    refreshModuleList();
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                }
                else if (ofd.FileName.Contains("customize_item"))
                {
                    if (Code.Items != null)
                    {
                        Code.Items.Clear();
                    }
                    Code.customPath = ofd.FileName;
                    Code.readCustomFile(ofd.FileName);
                    populateCharaBox(comboBox2);
                    comboBox2.Items.Add("ALL");
                    refreshCustomList();
                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                }
                else if (ofd.FileName.Contains("chritm_prop.farc"))
                {
                    Code.charaPath = ofd.FileName;
                    Code.readCharaFile(Code.charaPath);
                    openChritm();
                }
            }
            else { }
        }

        private void attrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(moduleExists)
            { 
                curModule.attr = (Attr)attrComboBox.SelectedItem;
            }
        }

        private void charaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moduleExists)
            {
                if (charaComboBox.Text != null && listBox1.SelectedItem.ToString() != (curModule.name + " " + "(" + charaComboBox.Text + ")"))
                {
                    curModule.chara = charaComboBox.Text;
                    int indexStore = listBox1.SelectedIndex;
                    refreshModuleList();
                    listBox1.SelectedIndex = indexStore;
                }
            }
        }

        private void cosTextBox_TextChanged(object sender, EventArgs e)
        {
            if (moduleExists && cosTextBox.Text.Contains("COS_")) { curModule.cos = cosTextBox.Text; }
        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Code.Modules != null && e.KeyCode == Keys.Enter)
            {
                if (nameTextBox.Text != null && listBox1.SelectedItem.ToString() != (nameTextBox.Text + " (" + curModule.chara + ")"))
                {
                    int indexStore = listBox1.SelectedIndex;
                    curModule.name = nameTextBox.Text;
                    refreshModuleList();
                    listBox1.SelectedIndex = indexStore;
                }
            }
        }
        // Ignore functions
        private void ignoreShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (moduleExists)
            {
                ngCheckFunc();
            }
        }
        private void ngCheck_CheckedChanged(object sender, EventArgs e)
        {
            ngCheckFunc();
        }
        private void ngCheckFunc()
        {
            if (moduleExists)
            {
                curModule.ng = ngCheck.Checked;
            }
        }

        private void priceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (moduleExists && curModule.shop_price != priceTextBox.Text) {
                curModule.shop_price = priceTextBox.Text;
            }
        }

        private void indexTextBox_TextChanged(object sender, EventArgs e)
        {
            if (moduleExists) { curModule.sort_index = Convert.ToInt32(indexTextBox.Value); }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (moduleExists)
            {
                curModule.shop_st_day = dateTimePicker1.Value.Day;
                curModule.shop_st_month = dateTimePicker1.Value.Month;
                curModule.shop_st_year = dateTimePicker1.Value.Year;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            curModule = Code.Modules[listBox1.SelectedIndex];
            if (curModule != null)
            {
                moduleExists = true;
                attrComboBox.Enabled = true;
                ngCheck.Enabled = true;
                attrComboBox.SelectedItem = curModule.attr;
                charaComboBox.Text = curModule.chara;
                cosTextBox.Text = curModule.cos;
                idUpDown.Value = curModule.id;
                nameTextBox.Text = curModule.name;
                priceTextBox.Text = curModule.shop_price;
                indexTextBox.Value = curModule.sort_index;
                ngCheck.Checked = curModule.ng;
                var startDate = new DateTime(curModule.shop_st_year, curModule.shop_st_month, curModule.shop_st_day);
                dateTimePicker1.Value = startDate;
            }
            modCount.Text = "Modules: " + Code.Modules.Count;
        }

        private void addModuleEntry_Click(object sender, EventArgs e)
        {
            if (Code.Modules.Count > 0)
            {
                int prev = listBox1.SelectedIndex;
                Code.addDummyEntry(prev+1);
                refreshModuleList();
                listBox1.SelectedIndex = prev+1;
            }
            else { MessageBox.Show("Please open a table file before editing the list.", "Error"); }
        }

        private void delModuleEntry_Click(object sender, EventArgs e)
        {
            delModule();
        }
        private void delModule()
        {
            if (Code.Modules.Count > 0)
            {
                int indexStore = listBox1.SelectedIndex;
                Code.Modules.RemoveAt(listBox1.SelectedIndex);
                refreshModuleList();
                if(indexStore == 0)
                {
                    listBox1.SelectedIndex = indexStore;
                }
                else
                {
                    listBox1.SelectedIndex = indexStore-1;
                }
            }
            else { MessageBox.Show("Please open a table file before editing the list.", "Error"); }
        }
        private void delCustom() //Move these into one function later - TODO
        {
            if (Code.Items.Count > 0)
            {
                int indexStore = listBox2.SelectedIndex;
                Code.Items.RemoveAt(listBox2.SelectedIndex);
                refreshCustomList();
                if (indexStore == 0)
                {
                    listBox2.SelectedIndex = indexStore;
                }
                else
                {
                    listBox2.SelectedIndex = indexStore - 1;
                }
            }
            else { MessageBox.Show("Please open a table file before editing the list.", "Error"); }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Code.modulePath != null && tabControl1.SelectedIndex == 0)
            {
                Code.saveFile<module>(Code.modulePath, Code.Modules);
            }
            else if(Code.customPath != null && tabControl1.SelectedIndex == 1)
            {
                Code.saveFile<cstm_item>(Code.customPath, Code.Items);
            }
            else { MessageBox.Show("No.", "Error");  }
        }

        // Change this to work after clicking a button, it's annoying otherwise!
        private void idUpDown_ValueChanged(object sender, EventArgs e)
        {
            idCheckLabel.Text = "";
            idCheckLabel.ForeColor = System.Drawing.Color.Transparent;
            curModule.id = (int)idUpDown.Value;
        }

        // Less Relevant Toolbar Stuff

        private void moduleBatchIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Code.Modules.Count != 0)
            {
                isModule = true;
                MultiSelect ms = new MultiSelect();
                ms.ShowDialog();
            }
            else { MessageBox.Show("You'll need to open a module table first.", "Error"); this.Close(); }
        }

        private void characterItemchritmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChritm();
        }
        private void openChritm()
        {
            chritm ci = new chritm();
            ci.ShowDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "FARC files (*.farc)|*.farc";
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                sfd.FileName = "mod_gm_module_tbl.farc";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Code.saveFile<module>(sfd.FileName, Code.Modules);
                }
            }
            else
            {
                sfd.FileName = "mod_gm_customize_item_tbl.farc";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Code.saveFile<cstm_item>(sfd.FileName, Code.Items);
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            curCustom = Code.Items[listBox2.SelectedIndex];
            if (curCustom != null)
            {
                if (curCustom.chara == "ALL")
                {
                    button3.Enabled = false;
                    numericUpDown3.Enabled = false;
                }
                else
                {
                    button3.Enabled = true;
                    numericUpDown3.Enabled = true;
                }
                comboBox2.SelectedItem = curCustom.chara;
                textBox3.Text = curCustom.name;
                checkBox1.Checked = curCustom.ng;
                checkBox2.Checked = curCustom.sell_type;
                numericUpDown2.Value = curCustom.id;
                numericUpDown4.Value = curCustom.obj_id;
                comboBox1.SelectedItem = curCustom.parts;
                textBox2.Text = curCustom.shop_price;
                numericUpDown1.Value = curCustom.sort_index;
                numericUpDown3.Value = curCustom.bind_module;
                dateTimePicker2.Value = new DateTime(curCustom.shop_st_year, curCustom.shop_st_month, curCustom.shop_st_day);
                label1.Text = "Items: " + Code.Items.Count;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (curCustom != null && Code.Modules.Count > 0)
            {
                BindModule bm = new BindModule();
                bm.ShowDialog();
                numericUpDown3.Value = curCustom.bind_module;
            }
            else { MessageBox.Show("Looks like there's no module table currently open."); }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != null && listBox2.SelectedItem.ToString() != (curCustom.name + " " + "(" + comboBox2.Text + ")"))
            {
                if (comboBox2.Text == "ALL")
                {
                    curCustom.bind_module = -1;
                    numericUpDown3.Value = -1;
                }
                curCustom.chara = comboBox2.Text;
                int indexStore = listBox2.SelectedIndex;
                refreshCustomList();
                listBox2.SelectedIndex = indexStore;
            }
        }

        private void textBox3_TextChanged(object sender, KeyEventArgs e)
        {
            if (Code.Items != null && e.KeyCode == Keys.Enter)
            {
                if (textBox3.Text != null && listBox2.SelectedItem.ToString() != (textBox3.Text + " (" + curCustom.chara + ")"))
                {
                    curCustom.name = textBox3.Text;
                    int indexStore = listBox2.SelectedIndex;
                    refreshCustomList();
                    listBox2.SelectedIndex = indexStore;
                }
            }
        }

        private void checkIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curModule != null)
            {
                bool checkIDUsage = Code.checkIDuse((int)idUpDown.Value);
                if (checkIDUsage)
                {
                    idCheckLabel.Text = "USED";
                    idCheckLabel.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    idCheckLabel.Text = "OK";
                    idCheckLabel.ForeColor = System.Drawing.Color.Lime;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Code.Items.Count > 0)
            {
                int prev = listBox2.SelectedIndex;
                Code.addDummyEntryCstm(listBox2.SelectedIndex + 1);
                refreshCustomList();
                listBox2.SelectedIndex = prev + 1;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DxvaTableManager by Bubble39" + Environment.NewLine + "Thanks to all who helped me with learning C#!" + Environment.NewLine + "NOT FOR COMMERCIAL OR FINANCIALLY SUPPORTED USE - RIP BOZO!!" + Environment.NewLine + "Current Version: v1.6b (10/09/2022)", "About DTM");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(tabControl1.SelectedIndex == 0)
            {
                sfd.FileName = "mod_gm_module_tbl.farc";
                Code.modulePath = sfd.FileName;
                Code.Modules.Clear();
                Code.addDummyEntry(0);
                populateCharaBox(charaComboBox);
                refreshModuleList();
            }
            else
            {
                sfd.FileName = "mod_gm_customize_item_tbl.farc";
                Code.customPath = sfd.FileName;
                Code.Items.Clear();
                Code.addDummyEntryCstm(0);
                populateCharaBox(comboBox2);
                comboBox2.Items.Add("ALL");
                refreshCustomList();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                delModule();
            }
            else
            {
                delCustom();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delCustom();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (curCustom != null)
            {
                curCustom.bind_module = (int)numericUpDown3.Value;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curCustom != null)
            {
                curCustom.parts = comboBox1.Text;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (curCustom != null)
            {
                curCustom.sort_index = (int)numericUpDown1.Value;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (curCustom != null)
            {
                curCustom.shop_st_day = dateTimePicker2.Value.Day;
                curCustom.shop_st_month = dateTimePicker2.Value.Month;
                curCustom.shop_st_year = dateTimePicker2.Value.Year;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (curCustom != null)
            {
                curCustom.shop_price = dateTimePicker2.Value.Day.ToString();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (curCustom != null)
            {
                curCustom.id = (int)numericUpDown2.Value;
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (curCustom != null)
            {
                curCustom.obj_id = (int)numericUpDown4.Value;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (curCustom != null)
            {
                curCustom.ng = checkBox1.Checked;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (curCustom != null)
            {
                curCustom.sell_type = checkBox2.Checked;
            }
        }

        private void indexTextBox_ValueChanged(object sender, EventArgs e)
        {
            if (moduleExists)
            {
                curModule.sort_index = (int)indexTextBox.Value;
            }
        }

        private void customiseItemManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Code.Items.Count > 0)
            {
                isModule = false;
                MultiSelect ms = new MultiSelect();
                ms.ShowDialog();
            }
            else { MessageBox.Show("You'll need to open a customise item table first.", "Error"); this.Close(); }

        }
    }
}