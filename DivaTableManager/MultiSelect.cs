using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MikuMikuLibrary.IO;
using MikuMikuLibrary.Archives;
using MikuMikuLibrary.Databases;

namespace DivaTableManager
{
    public partial class MultiSelect : Form
    {
        public MultiSelect()
        {
            InitializeComponent();
        }

        public string path1;
        public string path2;
        public string sprdbpath;
        public string sprpath;
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        OpenFileDialog ofd = new OpenFileDialog();
        List<int> oldIds = new List<int>();
        private void MultiSelect_Load(object sender, EventArgs e)
        {
            if (Code.Modules.Count != 0)
            {
                var dummy = new List<string>();
                for (int i = 0; i < Code.Modules.Count; i++)
                {
                    var x = Code.Modules[i];
                    string finalModuleName = x.name + " " + "(" + x.chara + ")";
                    dummy.Add(finalModuleName);
                }
                multiListBox.DataSource = dummy;
            }
            else { MessageBox.Show("You'll need to open a module table first.", "Error"); this.Close(); }
        }

        private void batchSortButton_Click(object sender, EventArgs e)
        {
            batchSort(multiListBox.SelectedIndices, Convert.ToInt32(numericUpDown1.Value));
        }
        private void batchSort(ListBox.SelectedIndexCollection selected, int startAt)
        {
            for (int i=0; i < selected.Count; i++)
            {
                Code.Modules[selected[i]].sort_index = startAt;
                startAt++;
            }
            MessageBox.Show("Done!");
            this.Close();
        }
        
        private void batchIdButton_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select your sprite database";
            ofd.Filter = "Sprite Database files |*spr_db.bin";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sprdbpath = ofd.FileName;
                fbd.Description = "Select folder with your module preview sprite files (.farc)";
                fbd.SelectedPath = ofd.InitialDirectory;
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    sprpath = fbd.SelectedPath;
                    dbCreate(multiListBox.SelectedIndices, Convert.ToInt32(numericUpDown1.Value), true, true);
                    MessageBox.Show("Done!");
                    this.Close();
                }
                else
                {
                    dbCreate(multiListBox.SelectedIndices, Convert.ToInt32(numericUpDown1.Value), false, true);
                    MessageBox.Show("Done! (without spr renaming)");
                    this.Close();
                }
            }
        }

        private void dbCreate(ListBox.SelectedIndexCollection selected, int startAt, bool doRename, bool loaded)
        {
            var db = new SpriteDatabase();
            if (loaded)
            {
                db = BinaryFile.Load<SpriteDatabase>(sprdbpath);
            }
            // Get Old IDs for farc renaming
            oldIds.Clear();
            for (int i = 0; i < selected.Count; i++)
            {
                oldIds.Add(Code.Modules[selected[i]].id);
            }
            for (int i = 0; i < selected.Count; i++)
            {
                module checkFirst = Code.Modules.Find(x => x.id == startAt);
                while (checkFirst != null)
                {
                    startAt++;
                    checkFirst = Code.Modules.Find(x => x.id == startAt);
                }
                if (checkFirst == null)
                {
                    SpriteSetInfo sprite = new SpriteSetInfo();
                    SpriteInfo info = new SpriteInfo();
                    SpriteTextureInfo texture = new SpriteTextureInfo();
                    Code.Modules[selected[i]].id = startAt;
                    if (db.SpriteSets.Count == 0)
                    {
                        sprite.Name = "SPR_SEL_MD" + startAt + "CMN";
                        sprite.FileName = "spr_sel_md" + startAt + "cmn.bin";
                        sprite.Id = (uint)startAt*3939;
                        info.Id = sprite.Id + 1;
                        texture.Id = info.Id + 1;
                        texture.Index = 0;
                        texture.Name = "SPRTEX_SEL_MD" + startAt + "CMN_MERGE_BC5COMP_0";
                        sprite.Sprites.Add(info);
                        sprite.Textures.Add(texture);
                        db.SpriteSets.Add(sprite);
                        startAt++;
                    }
                    else
                    {
                        sprite.Name = "SPR_SEL_MD" + startAt + "CMN";
                        sprite.FileName = "spr_sel_md" + startAt + "cmn.bin";
                        sprite.Id = (db.SpriteSets[db.SpriteSets.Count - 1].Id) + 1;
                        info.Index = 0;
                        info.Name = "SPR_SEL_MD" + startAt + "CMN_MD_IMG";
                        info.Id = db.SpriteSets[db.SpriteSets.Count - 1].Textures[db.SpriteSets[db.SpriteSets.Count - 1].Textures.Count - 1].Id + 1;
                        texture.Id = info.Id + 1;
                        texture.Name = "SPRTEX_SEL_MD" + startAt + "CMN_MERGE_BC5COMP_0";
                        texture.Index = 0;
                        sprite.Sprites.Add(info);
                        sprite.Textures.Add(texture);
                        db.SpriteSets.Add(sprite);
                        startAt++;
                    }
                }
            }
            db.Save(sprdbpath);
            db.Dispose();
            if (doRename)
            {
                renameFarcs(oldIds, selected.Count, startAt - selected.Count, sprpath);
            }
        }

        private void renameFarcs(List<int> ids, int count, int startAt, string folderPath)
        {
            for (int i = 0; i < count; i++)
            {
                string file = "spr_sel_md" + ids[i] + "cmn";
                try
                {
                    var farc = BinaryFile.Load<FarcArchive>(folderPath + @"\" + file + ".farc");
                    foreach (var fileName in farc)
                    {
                        var source = farc.Open(fileName, EntryStreamMode.MemoryStream);
                        farc.Add("spr_sel_md" + startAt + "cmn.bin", source, true);
                        farc.IsCompressed = true;
                        farc.Remove(file + ".bin");
                        farc.Save(folderPath + @"\" + "spr_sel_md" + startAt + "cmn.farc");
                        break;
                    }
                    farc.Dispose();
                    File.Delete(folderPath + @"\" + file + ".farc");
                    startAt++;
                }
                catch (Exception)
                {
                    startAt++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "mod_spr_db.bin";
            sfd.Title = "Create new spr_db";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                sprdbpath = sfd.FileName;
                fbd.Description = "Select folder with your module preview sprite files (.farc)";
                fbd.SelectedPath = ofd.InitialDirectory;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    sprpath = fbd.SelectedPath;
                    dbCreate(multiListBox.SelectedIndices, Convert.ToInt32(numericUpDown1.Value), true, false);
                    MessageBox.Show("Done!");
                    this.Close();
                }
                else
                {
                    dbCreate(multiListBox.SelectedIndices, Convert.ToInt32(numericUpDown1.Value), false, false);
                    MessageBox.Show("Done! (without spr renaming)");
                    this.Close();
                }
            }
        }
    }
}
