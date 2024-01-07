
namespace DxvaTableManager
{
    partial class MultiSelect
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
            this.multiListBox = new System.Windows.Forms.ListBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.batchIdButton = new System.Windows.Forms.Button();
            this.batchSortButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // multiListBox
            // 
            this.multiListBox.FormattingEnabled = true;
            this.multiListBox.ItemHeight = 16;
            this.multiListBox.Location = new System.Drawing.Point(156, 12);
            this.multiListBox.Name = "multiListBox";
            this.multiListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.multiListBox.Size = new System.Drawing.Size(234, 420);
            this.multiListBox.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 29);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(130, 22);
            this.numericUpDown1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start at (Except Auto):";
            // 
            // batchIdButton
            // 
            this.batchIdButton.Location = new System.Drawing.Point(12, 385);
            this.batchIdButton.Name = "batchIdButton";
            this.batchIdButton.Size = new System.Drawing.Size(130, 47);
            this.batchIdButton.TabIndex = 3;
            this.batchIdButton.Text = "Auto IDs\r\n(Existing DB)";
            this.batchIdButton.UseVisualStyleBackColor = true;
            this.batchIdButton.Click += new System.EventHandler(this.batchIdButton_Click);
            // 
            // batchSortButton
            // 
            this.batchSortButton.Location = new System.Drawing.Point(12, 291);
            this.batchSortButton.Name = "batchSortButton";
            this.batchSortButton.Size = new System.Drawing.Size(130, 35);
            this.batchSortButton.TabIndex = 4;
            this.batchSortButton.Text = "Assign Sort Index";
            this.batchSortButton.UseVisualStyleBackColor = true;
            this.batchSortButton.Click += new System.EventHandler(this.batchSortButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 47);
            this.button1.TabIndex = 5;
            this.button1.Text = "Manual IDs\r\n(New DB)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MultiSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(402, 443);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.batchSortButton);
            this.Controls.Add(this.batchIdButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.multiListBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 490);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 490);
            this.Name = "MultiSelect";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Select Multiple Items";
            this.Load += new System.EventHandler(this.MultiSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox multiListBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button batchIdButton;
        private System.Windows.Forms.Button batchSortButton;
        private System.Windows.Forms.Button button1;
    }
}