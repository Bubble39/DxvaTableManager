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

namespace DxvaTableManager
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
            if (Form1.isModule)
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
            else
            {
                var dummy = new List<string>();
                for (int i = 0; i < Code.Items.Count; i++)
                {
                    var x = Code.Items[i];
                    string finalItemName = x.name + " " + "(" + x.chara + ")";
                    dummy.Add(finalItemName);
                }
                multiListBox.DataSource = dummy;
            }
        }

        private void batchSortButton_Click(object sender, EventArgs e)
        {
            batchSort(multiListBox.SelectedIndices, Convert.ToInt32(numericUpDown1.Value), Form1.isModule);
        }
        private void batchSort(ListBox.SelectedIndexCollection selected, int startAt, bool isModule)
        {
            if (isModule)
            {
                for (int i = 0; i < selected.Count; i++)
                {
                    Code.Modules[selected[i]].sort_index = startAt;
                    startAt++;
                }
            }
            else
            {
                for (int i = 0; i < selected.Count; i++)
                {
                    Code.Items[selected[i]].sort_index = startAt;
                    startAt++;
                }
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
                fbd.Description = "Select folder with your sprite files (.farc)";
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
            oldIds.Clear();
            // Get Old IDs for farc renaming
            if (Form1.isModule)
            {
                for (int i = 0; i < selected.Count; i++)
                {
                    oldIds.Add(Code.Modules[selected[i]].id);
                }
            }
            else
            {
                for (int i = 0; i < selected.Count; i++)
                {
                    oldIds.Add(Code.Items[selected[i]].id);
                }
            }

            for (int i = 0; i < selected.Count; i++)
            {
                bool isOk = false;
                if (Form1.isModule)
                {
                    module checkFirst = Code.Modules.Find(x => x.id == startAt);
                    while (checkFirst != null)
                    {
                        startAt++;
                        checkFirst = Code.Modules.Find(x => x.id == startAt);
                        isOk = false;
                    }
                    if (checkFirst == null)
                    {
                        isOk = true;
                    }
                }
                else
                {
                    cstm_item checkFirst = Code.Items.Find(x => x.id == startAt);
                    while (checkFirst != null)
                    {
                        startAt++;
                        checkFirst = Code.Items.Find(x => x.id == startAt);
                        isOk = false;
                    }
                    if (checkFirst == null)
                    {
                        isOk = true;
                    }
                }
                if (isOk)
                {
                    SpriteSetInfo sprite = new SpriteSetInfo();
                    SpriteInfo info = new SpriteInfo();
                    SpriteTextureInfo texture = new SpriteTextureInfo();
                    if (Form1.isModule)
                    {
                        Code.Modules[selected[i]].id = startAt;
                        sprite.Name = "SPR_SEL_MD" + startAt + "CMN";
                        info.Name = "SPR_SEL_MD" + startAt + "CMN_MD_IMG";
                        sprite.FileName = "spr_sel_md" + startAt + "cmn.bin";
                        texture.Name = "SPRTEX_SEL_MD" + startAt + "CMN_MERGE_BC5COMP_0";
                    }
                    else
                    {
                        Code.Items[selected[i]].id = startAt;
                        sprite.Name = "SPR_CMNITM_THMB" + startAt.ToString();
                        sprite.FileName = "spr_cmnitm_thmb" + startAt + ".bin";
                        info.Name = "SPR_CMNITM_THMB" + startAt + "_ITM_IMG";
                        texture.Name = "SPRTEX_CMNITM_THMB" + startAt + "_MERGE_BC5COMP_0";
                    }
                    if (db.SpriteSets.Count == 0)
                    {
                        sprite.Id = (uint)startAt * 3939;
                        info.Id = sprite.Id + 1;
                        texture.Id = info.Id + 1;
                        texture.Index = 0;
                        sprite.Sprites.Add(info);
                        sprite.Textures.Add(texture);
                        db.SpriteSets.Add(sprite);
                        startAt++;
                    }
                    else
                    {
                        sprite.Id = (db.SpriteSets[db.SpriteSets.Count - 1].Id) + 1;
                        info.Index = 0;
                        info.Id = db.SpriteSets[db.SpriteSets.Count - 1].Textures[db.SpriteSets[db.SpriteSets.Count - 1].Textures.Count - 1].Id + 1;
                        texture.Id = info.Id + 1;
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
            if (Form1.isModule)
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
            else
            {
                for (int i = 0; i < count; i++)
                {
                    string file = "spr_cmnitm_thmb" + ids[i].ToString();
                    try
                    {
                        var farc = BinaryFile.Load<FarcArchive>(folderPath + @"\" + file + ".farc");
                        foreach (var fileName in farc)
                        {
                            var source = farc.Open(fileName, EntryStreamMode.MemoryStream);
                            farc.Add("spr_cmnitm_thmb" + startAt + ".bin", source, true);
                            farc.IsCompressed = true;
                            farc.Remove(file + ".bin");
                            farc.Save(folderPath + @"\" + "spr_cmnitm_thmb" + startAt + ".farc");
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
