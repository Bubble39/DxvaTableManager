
namespace DivaTableManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ModuleListLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delModuleEntry = new System.Windows.Forms.Button();
            this.addModuleEntry = new System.Windows.Forms.Button();
            this.EndLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.idCheckLabel = new System.Windows.Forms.Label();
            this.IndexLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ModIDLabel = new System.Windows.Forms.Label();
            this.CosLabel = new System.Windows.Forms.Label();
            this.CharaLabel = new System.Windows.Forms.Label();
            this.AttrLabel = new System.Windows.Forms.Label();
            this.attrComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.charaComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cosTextBox = new System.Windows.Forms.TextBox();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.ngCheck = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moduleTableHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterItemTableHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mentalHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byJay39wToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(575, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(244, 356);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(841, 437);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ModuleListLabel);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(833, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Module Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ModuleListLabel
            // 
            this.ModuleListLabel.AutoSize = true;
            this.ModuleListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleListLabel.Location = new System.Drawing.Point(570, 6);
            this.ModuleListLabel.Name = "ModuleListLabel";
            this.ModuleListLabel.Size = new System.Drawing.Size(162, 25);
            this.ModuleListLabel.TabIndex = 14;
            this.ModuleListLabel.Text = "Module Entry List";
            this.toolTip1.SetToolTip(this.ModuleListLabel, "Did you just feel like hovering over all the text?");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.delModuleEntry);
            this.groupBox1.Controls.Add(this.addModuleEntry);
            this.groupBox1.Controls.Add(this.EndLabel);
            this.groupBox1.Controls.Add(this.StartLabel);
            this.groupBox1.Controls.Add(this.idCheckLabel);
            this.groupBox1.Controls.Add(this.IndexLabel);
            this.groupBox1.Controls.Add(this.PriceLabel);
            this.groupBox1.Controls.Add(this.NameLabel);
            this.groupBox1.Controls.Add(this.ModIDLabel);
            this.groupBox1.Controls.Add(this.CosLabel);
            this.groupBox1.Controls.Add(this.CharaLabel);
            this.groupBox1.Controls.Add(this.AttrLabel);
            this.groupBox1.Controls.Add(this.attrComboBox);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.charaComboBox);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.cosTextBox);
            this.groupBox1.Controls.Add(this.indexTextBox);
            this.groupBox1.Controls.Add(this.idTextBox);
            this.groupBox1.Controls.Add(this.priceTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.ngCheck);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 384);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Module Information";
            // 
            // delModuleEntry
            // 
            this.delModuleEntry.Location = new System.Drawing.Point(217, 297);
            this.delModuleEntry.Name = "delModuleEntry";
            this.delModuleEntry.Size = new System.Drawing.Size(198, 81);
            this.delModuleEntry.TabIndex = 23;
            this.delModuleEntry.Text = "Delete Selected Entry";
            this.toolTip1.SetToolTip(this.delModuleEntry, "Removes the selected entry from the list.");
            this.delModuleEntry.UseVisualStyleBackColor = true;
            this.delModuleEntry.Click += new System.EventHandler(this.delModuleEntry_Click);
            // 
            // addModuleEntry
            // 
            this.addModuleEntry.Location = new System.Drawing.Point(6, 297);
            this.addModuleEntry.Name = "addModuleEntry";
            this.addModuleEntry.Size = new System.Drawing.Size(198, 81);
            this.addModuleEntry.TabIndex = 15;
            this.addModuleEntry.Text = "Add Dummy Entry \r\n(At End of List)";
            this.toolTip1.SetToolTip(this.addModuleEntry, "Adds a dummy entry with default values to the end of the list.\r\nOnce the entry is" +
        " added the user can edit it to their liking.");
            this.addModuleEntry.UseVisualStyleBackColor = true;
            this.addModuleEntry.Click += new System.EventHandler(this.addModuleEntry_Click);
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(286, 251);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(124, 17);
            this.EndLabel.TabIndex = 22;
            this.EndLabel.Text = "End Showing Date";
            this.toolTip1.SetToolTip(this.EndLabel, "The date on which this module will disappear from the shop.\r\nWhen the date is rea" +
        "ched, the module will no longer be\r\navailable in the shop.\r\n");
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(286, 223);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(129, 17);
            this.StartLabel.TabIndex = 21;
            this.StartLabel.Text = "Start Showing Date";
            this.toolTip1.SetToolTip(this.StartLabel, "The date on which this module will appear in the shop.\r\nIf the date is not yet re" +
        "ached, the module will not be\r\navailable in the shop.");
            // 
            // idCheckLabel
            // 
            this.idCheckLabel.AutoSize = true;
            this.idCheckLabel.ForeColor = System.Drawing.Color.Black;
            this.idCheckLabel.Location = new System.Drawing.Point(328, 112);
            this.idCheckLabel.Name = "idCheckLabel";
            this.idCheckLabel.Size = new System.Drawing.Size(0, 17);
            this.idCheckLabel.TabIndex = 20;
            // 
            // IndexLabel
            // 
            this.IndexLabel.AutoSize = true;
            this.IndexLabel.Location = new System.Drawing.Point(286, 195);
            this.IndexLabel.Name = "IndexLabel";
            this.IndexLabel.Size = new System.Drawing.Size(71, 17);
            this.IndexLabel.TabIndex = 19;
            this.IndexLabel.Text = "Sort Index";
            this.toolTip1.SetToolTip(this.IndexLabel, resources.GetString("IndexLabel.ToolTip"));
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(286, 167);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(72, 17);
            this.PriceLabel.TabIndex = 18;
            this.PriceLabel.Text = "Price (VP)";
            this.toolTip1.SetToolTip(this.PriceLabel, "The price of the module, in Vocaloid Points, in the module shop.\r\nFor consistency" +
        ", it is advised to use different values when working \r\nwith FT/M39 and when work" +
        "ing with AFT.");
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(286, 139);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 17);
            this.NameLabel.TabIndex = 17;
            this.NameLabel.Text = "Name";
            this.toolTip1.SetToolTip(this.NameLabel, "The name of the module.\r\nThis is the name that will appear in module select.\r\nBar" +
        "e in mind unsupported character sets will not display correctly in-game.");
            // 
            // ModIDLabel
            // 
            this.ModIDLabel.AutoSize = true;
            this.ModIDLabel.Location = new System.Drawing.Point(286, 111);
            this.ModIDLabel.Name = "ModIDLabel";
            this.ModIDLabel.Size = new System.Drawing.Size(21, 17);
            this.ModIDLabel.TabIndex = 16;
            this.ModIDLabel.Text = "ID";
            this.toolTip1.SetToolTip(this.ModIDLabel, resources.GetString("ModIDLabel.ToolTip"));
            // 
            // CosLabel
            // 
            this.CosLabel.AutoSize = true;
            this.CosLabel.Location = new System.Drawing.Point(286, 83);
            this.CosLabel.Name = "CosLabel";
            this.CosLabel.Size = new System.Drawing.Size(63, 17);
            this.CosLabel.TabIndex = 15;
            this.CosLabel.Text = "Costume";
            this.toolTip1.SetToolTip(this.CosLabel, resources.GetString("CosLabel.ToolTip"));
            // 
            // CharaLabel
            // 
            this.CharaLabel.AutoSize = true;
            this.CharaLabel.Location = new System.Drawing.Point(286, 54);
            this.CharaLabel.Name = "CharaLabel";
            this.CharaLabel.Size = new System.Drawing.Size(70, 17);
            this.CharaLabel.TabIndex = 14;
            this.CharaLabel.Text = "Character";
            this.toolTip1.SetToolTip(this.CharaLabel, "The character you would like this module to be used on.\r\nThis will control in whi" +
        "ch module select section the module appears and more.");
            // 
            // AttrLabel
            // 
            this.AttrLabel.AutoSize = true;
            this.AttrLabel.Location = new System.Drawing.Point(286, 24);
            this.AttrLabel.Name = "AttrLabel";
            this.AttrLabel.Size = new System.Drawing.Size(61, 17);
            this.AttrLabel.TabIndex = 13;
            this.AttrLabel.Text = "Attribute";
            this.toolTip1.SetToolTip(this.AttrLabel, "The attributes set to the module entry.\r\nYou can fully ignore the Future Sound, C" +
        "olorful Tone and Prelude tags if you are\r\nworking with Mega39\'s/MegaMix or Arcad" +
        "e Future Tone.");
            // 
            // attrComboBox
            // 
            this.attrComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attrComboBox.FormattingEnabled = true;
            this.attrComboBox.Items.AddRange(new object[] {
            "Default (No Pack)",
            "Default (Future Sound)",
            "Default (Colorful Tone)",
            "Default (Prelude/Etc)",
            "Swimsuit (No Pack)",
            "Swimsuit (Future Sound)",
            "Swimsuit (Colorful Tone)",
            "Swimsuit (Prelude/Etc)",
            "Hair Unswappable (No Pack)",
            "Hair Unswappable (Future Sound)",
            "Hair Unswappable (Colorful Tone)",
            "Hair Unswappable (Prelude/Etc)"});
            this.attrComboBox.Location = new System.Drawing.Point(6, 21);
            this.attrComboBox.Name = "attrComboBox";
            this.attrComboBox.Size = new System.Drawing.Size(274, 24);
            this.attrComboBox.TabIndex = 3;
            this.attrComboBox.SelectedIndexChanged += new System.EventHandler(this.attrComboBox_SelectedIndexChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(6, 249);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(274, 22);
            this.dateTimePicker2.TabIndex = 12;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // charaComboBox
            // 
            this.charaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.charaComboBox.FormattingEnabled = true;
            this.charaComboBox.Items.AddRange(new object[] {
            "MIKU",
            "RIN",
            "LEN",
            "LUKA",
            "KAITO",
            "MEIKO",
            "NERU",
            "HAKU",
            "SAKINE",
            "TETO"});
            this.charaComboBox.Location = new System.Drawing.Point(6, 51);
            this.charaComboBox.Name = "charaComboBox";
            this.charaComboBox.Size = new System.Drawing.Size(274, 24);
            this.charaComboBox.TabIndex = 4;
            this.charaComboBox.SelectedIndexChanged += new System.EventHandler(this.charaComboBox_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 221);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(274, 22);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cosTextBox
            // 
            this.cosTextBox.Location = new System.Drawing.Point(6, 81);
            this.cosTextBox.Name = "cosTextBox";
            this.cosTextBox.Size = new System.Drawing.Size(274, 22);
            this.cosTextBox.TabIndex = 5;
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(6, 193);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(274, 22);
            this.indexTextBox.TabIndex = 10;
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(6, 109);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(274, 22);
            this.idTextBox.TabIndex = 6;
            this.idTextBox.TextChanged += new System.EventHandler(this.idTextBox_TextChanged);
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(6, 165);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(274, 22);
            this.priceTextBox.TabIndex = 9;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(6, 137);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(274, 22);
            this.nameTextBox.TabIndex = 7;
            this.nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameTextBox_KeyDown);
            // 
            // ngCheck
            // 
            this.ngCheck.AutoSize = true;
            this.ngCheck.Location = new System.Drawing.Point(434, 328);
            this.ngCheck.Name = "ngCheck";
            this.ngCheck.Size = new System.Drawing.Size(107, 21);
            this.ngCheck.TabIndex = 8;
            this.ngCheck.Text = "Ignore Entry";
            this.toolTip1.SetToolTip(this.ngCheck, "Ignores the current entry.\r\nIf this box is checked, the module will not show in\r\n" +
        "the module select unless overridden by \'mdata\' or\r\n\'databank\' module lists.");
            this.ngCheck.UseVisualStyleBackColor = true;
            this.ngCheck.CheckedChanged += new System.EventHandler(this.ngCheck_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(833, 408);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Character Item Table";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(642, 29);
            this.label11.TabIndex = 4;
            this.label11.Text = "Please wait for this functionality to be added! - Jay39w";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(865, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(Code.SaveButton_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(FormExtras.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.informationToolStripMenuItem,
            this.byJay39wToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moduleTableHelpToolStripMenuItem,
            this.characterItemTableHelpToolStripMenuItem,
            this.mentalHelpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // moduleTableHelpToolStripMenuItem
            // 
            this.moduleTableHelpToolStripMenuItem.Name = "moduleTableHelpToolStripMenuItem";
            this.moduleTableHelpToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.moduleTableHelpToolStripMenuItem.Text = "Module Table Help";
            this.moduleTableHelpToolStripMenuItem.Click += new System.EventHandler(FormExtras.moduleTableHelpToolStripMenuItem_Click);
            // 
            // characterItemTableHelpToolStripMenuItem
            // 
            this.characterItemTableHelpToolStripMenuItem.Name = "characterItemTableHelpToolStripMenuItem";
            this.characterItemTableHelpToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.characterItemTableHelpToolStripMenuItem.Text = "Character Item Table Help";
            this.characterItemTableHelpToolStripMenuItem.Click += new System.EventHandler(FormExtras.characterItemTableHelpToolStripMenuItem_Click);
            // 
            // mentalHelpToolStripMenuItem
            // 
            this.mentalHelpToolStripMenuItem.Name = "mentalHelpToolStripMenuItem";
            this.mentalHelpToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.mentalHelpToolStripMenuItem.Text = "Mental Help";
            this.mentalHelpToolStripMenuItem.Click += new System.EventHandler(FormExtras.mentalHelpToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.informationToolStripMenuItem.Text = "Information";
            this.informationToolStripMenuItem.Click += new System.EventHandler(FormExtras.informationToolStripMenuItem_Click);
            // 
            // byJay39wToolStripMenuItem
            // 
            this.byJay39wToolStripMenuItem.Enabled = false;
            this.byJay39wToolStripMenuItem.Name = "byJay39wToolStripMenuItem";
            this.byJay39wToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.byJay39wToolStripMenuItem.Text = "by Jay39w";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 481);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DivaTableManager";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox charaComboBox;
        private System.Windows.Forms.ComboBox attrComboBox;
        private System.Windows.Forms.TextBox cosTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.CheckBox ngCheck;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox indexTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label CharaLabel;
        private System.Windows.Forms.Label AttrLabel;
        private System.Windows.Forms.Label ModIDLabel;
        private System.Windows.Forms.Label CosLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ModuleListLabel;
        private System.Windows.Forms.Label IndexLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label idCheckLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byJay39wToolStripMenuItem;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.ToolStripMenuItem moduleTableHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem characterItemTableHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mentalHelpToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button delModuleEntry;
        private System.Windows.Forms.Button addModuleEntry;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

