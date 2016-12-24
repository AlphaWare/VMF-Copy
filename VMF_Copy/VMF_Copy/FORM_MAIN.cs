using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace VMF_Copy
{
    public partial class FORM_MAIN : Form
    {
        public FORM_MAIN()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Properties.Settings.Default.Save();
        }
        public bool Override = false, CopyMDL, CopyVMT, CopyWAV, CopyVTF;
        private void B_RUN_Click(object sender, EventArgs e)
        {
            //PrintToLog("Null");
            //PrintToLog("Info",1);
            //PrintToLog("Warning",2);
            //PrintToLog("Copied", 3);
            //PrintToLog("Error copy", 4);
            //PrintToLog("Filtered", 5);
            LV_LOG.Items.Clear();
            //CB_VMF.Items.Add(CB_VMF.Text);
            //CB_GAME_FOLDER.Items.Add(CB_GAME_FOLDER.Text);
            //CB_COPY_TO_FOLDER.Items.Add(CB_COPY_TO_FOLDER.Text);
            if(File.Exists(TB_VMF.Text))
            {
                if(Directory.Exists(TB_GAME_FOLDER.Text))
                {
                    if(Directory.Exists(TB_COPY_TO_FOLDER.Text))
                    {
                        CopyMDL = CB_COPY_MODELS.Checked;
                        CopyVMT = CB_COPY_MATERIALS.Checked;
                        CopyWAV = CB_COPY_SOUNDS.Checked;
                        CopyVTF = CB_COPY_TEXTURES.Checked;
                        B_RUN.Enabled = false;
                        G_INFO.Enabled = false;
                        VMF_COPY_RUN.Run(TB_VMF.Text, TB_GAME_FOLDER.Text, TB_COPY_TO_FOLDER.Text, CLB_FILTER.Text, this);
                    }
                    else
                    {
                        PrintToLog("Copy to folder does not exist!",2);
                    }
                }
                else
                {
                    PrintToLog("Game folder does not exist!", 2);
                }
            }
            else
            {
                PrintToLog("VMF file does not exist!", 2);
            }
        }

        public void EnableRunNControls()
        {
            this.Invoke(new MethodInvoker(delegate() { B_RUN.Enabled = true; G_INFO.Enabled = true; }));
            
        }
        /*
         * 0 - Null
         * 1 - Info
         * 2 - Warning
         * 3 - Copied
         * 4 - Errpr copy
         * 5 - Filter
         * 6 - Model
         * 7 - Material
         * 8 - Sound
         * 9 - Particle
         * 10 - Color correction
         */

        public void PrintToLog(string message="", int IIndex=0)
        {
            this.Invoke(new MethodInvoker(delegate () {

                var ITEM = new ListViewItem();
                ITEM.ImageIndex = IIndex;
                ITEM.SubItems.Add(message);
                this.LV_LOG.Items.Add(ITEM);
                LV_LOG.Items[LV_LOG.Items.Count - 1].EnsureVisible();

            }));
        }

        private void FORM_MAIN_Load(object sender, EventArgs e)
        {
            LV_LOG.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            Override = CB_OVERRIDE.Checked;
        }

        private void B_VMF_Click(object sender, EventArgs e)
        {

            using (var VMF = new OpenFileDialog())
            {
                VMF.Filter = "Valve map format|*.vmf";
                if (VMF.ShowDialog() != DialogResult.Yes)
                {
                    TB_VMF.Text = VMF.FileName;
                }

            }
        }

        private void CB_COPY_MODELS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void B_GAME_Click(object sender, EventArgs e)
        {
            using (var Gamedirectory = new FolderBrowserDialog())
            {
                if (Gamedirectory.ShowDialog() == DialogResult.OK)
                {
                    TB_GAME_FOLDER.Text = Gamedirectory.SelectedPath;
                }
            }
        }

        private void B_COPY_TO_Click(object sender, EventArgs e)
        {
            using (var CopyToFolder = new FolderBrowserDialog())
            {
                if (CopyToFolder.ShowDialog() == DialogResult.OK)
                {
                    TB_COPY_TO_FOLDER.Text = CopyToFolder.SelectedPath;
                }
            }
        }

        private void B_SCAN_Click(object sender, EventArgs e)
        {
            
        }

        private void CB_OVERRIDE_CheckedChanged(object sender, EventArgs e)
        {
            Override = CB_OVERRIDE.Checked;
        }
    }

}
