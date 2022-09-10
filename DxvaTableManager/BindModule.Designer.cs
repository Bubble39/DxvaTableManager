
namespace DxvaTableManager
{
    partial class BindModule
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
            this.bindModuleList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bindModuleList
            // 
            this.bindModuleList.FormattingEnabled = true;
            this.bindModuleList.ItemHeight = 16;
            this.bindModuleList.Location = new System.Drawing.Point(0, 0);
            this.bindModuleList.Name = "bindModuleList";
            this.bindModuleList.Size = new System.Drawing.Size(216, 340);
            this.bindModuleList.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BindModule
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(207, 377);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bindModuleList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindModule";
            this.ShowIcon = false;
            this.Text = "Select a Module";
            this.Load += new System.EventHandler(this.BindModule_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox bindModuleList;
        private System.Windows.Forms.Button button1;
    }
}