using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxvaTableManager
{
    public partial class BindModule : Form
    {
        public BindModule()
        {
            InitializeComponent();
        }

        private void BindModule_Load(object sender, EventArgs e)
        {
            bindModuleList.Items.Clear();
            List<string> Data = new List<string>();
            foreach(module x in Code.Modules)
            {
                string name = x.name + "(" + x.chara + ")";
                Data.Add(name);

            }
            bindModuleList.DataSource = Data;
            module find = Code.Modules.Find(i => i.id.Equals(Form1.curCustom.bind_module));
            int index = Code.Modules.IndexOf(find);
            bindModuleList.SelectedIndex = index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Code.Modules[bindModuleList.SelectedIndex].chara == Form1.curCustom.chara)
            {
                Form1.curCustom.bind_module = Code.Modules[bindModuleList.SelectedIndex].id;
                this.Close();
            }
            else
            {
                MessageBox.Show("You cannot bind a hairstyle to a module from a different character.");
            }
        }
    }
}
