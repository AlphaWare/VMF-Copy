namespace VMF_Copy
{
    partial class FORM_MAIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_MAIN));
            this.label1 = new System.Windows.Forms.Label();
            this.B_RUN = new System.Windows.Forms.Button();
            this.LV_LOG = new System.Windows.Forms.ListView();
            this.Icons = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Detail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OUTPUT_IMAGE_LIST = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CLB_FILTER = new System.Windows.Forms.CheckedListBox();
            this.B_ADD = new System.Windows.Forms.Button();
            this.G_INFO = new System.Windows.Forms.GroupBox();
            this.CB_OVERRIDE = new System.Windows.Forms.CheckBox();
            this.TB_COPY_TO_FOLDER = new System.Windows.Forms.TextBox();
            this.TB_GAME_FOLDER = new System.Windows.Forms.TextBox();
            this.TB_VMF = new System.Windows.Forms.TextBox();
            this.B_COPY_TO = new System.Windows.Forms.Button();
            this.B_GAME = new System.Windows.Forms.Button();
            this.B_VMF = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.CB_COPY_SOUNDS = new System.Windows.Forms.CheckBox();
            this.CB_COPY_TEXTURES = new System.Windows.Forms.CheckBox();
            this.CB_COPY_MODELS = new System.Windows.Forms.CheckBox();
            this.CB_COPY_MATERIALS = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.B_REMOVE = new System.Windows.Forms.Button();
            this.B_CHECK_ALL = new System.Windows.Forms.Button();
            this.B_UNCHECK_ALL = new System.Windows.Forms.Button();
            this.B_INVERT = new System.Windows.Forms.Button();
            this.G_INFO.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "VMF FILE";
            // 
            // B_RUN
            // 
            this.B_RUN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.B_RUN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.B_RUN.FlatAppearance.BorderSize = 0;
            this.B_RUN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_RUN.Location = new System.Drawing.Point(12, 623);
            this.B_RUN.Name = "B_RUN";
            this.B_RUN.Size = new System.Drawing.Size(1002, 23);
            this.B_RUN.TabIndex = 2;
            this.B_RUN.Text = "Run";
            this.B_RUN.UseVisualStyleBackColor = false;
            this.B_RUN.Click += new System.EventHandler(this.B_RUN_Click);
            // 
            // LV_LOG
            // 
            this.LV_LOG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LV_LOG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LV_LOG.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Icons,
            this.Detail});
            this.LV_LOG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_LOG.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV_LOG.ForeColor = System.Drawing.Color.White;
            this.LV_LOG.HideSelection = false;
            this.LV_LOG.LargeImageList = this.OUTPUT_IMAGE_LIST;
            this.LV_LOG.Location = new System.Drawing.Point(3, 16);
            this.LV_LOG.MultiSelect = false;
            this.LV_LOG.Name = "LV_LOG";
            this.LV_LOG.Size = new System.Drawing.Size(994, 273);
            this.LV_LOG.SmallImageList = this.OUTPUT_IMAGE_LIST;
            this.LV_LOG.TabIndex = 3;
            this.LV_LOG.UseCompatibleStateImageBehavior = false;
            this.LV_LOG.View = System.Windows.Forms.View.Details;
            // 
            // Icons
            // 
            this.Icons.Text = "";
            this.Icons.Width = 24;
            // 
            // Detail
            // 
            this.Detail.Text = "Details";
            this.Detail.Width = 1430;
            // 
            // OUTPUT_IMAGE_LIST
            // 
            this.OUTPUT_IMAGE_LIST.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("OUTPUT_IMAGE_LIST.ImageStream")));
            this.OUTPUT_IMAGE_LIST.TransparentColor = System.Drawing.Color.Transparent;
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(0, "null.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(1, "Info-16.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(2, "Error-16.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(3, "Checkmark-20.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(4, "Delete-20.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(5, "Filled Filter-16.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(6, "Model.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(7, "Material.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(8, "Speaker-20.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(9, "texture.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(10, "Sound.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(11, "Checkmark-16.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(12, "Delete-16.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(13, "Particle.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(14, "CC.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(15, "Material.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(16, "Teapot-20.png");
            this.OUTPUT_IMAGE_LIST.Images.SetKeyName(17, "emoticon_smile.png");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "GAME FOLDER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "COPY TO FOLDER";
            // 
            // CLB_FILTER
            // 
            this.CLB_FILTER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CLB_FILTER.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CLB_FILTER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLB_FILTER.ForeColor = System.Drawing.Color.White;
            this.CLB_FILTER.FormattingEnabled = true;
            this.CLB_FILTER.Location = new System.Drawing.Point(3, 16);
            this.CLB_FILTER.Name = "CLB_FILTER";
            this.CLB_FILTER.Size = new System.Drawing.Size(994, 130);
            this.CLB_FILTER.TabIndex = 4;
            // 
            // B_ADD
            // 
            this.B_ADD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.B_ADD.Enabled = false;
            this.B_ADD.FlatAppearance.BorderSize = 0;
            this.B_ADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_ADD.Location = new System.Drawing.Point(15, 296);
            this.B_ADD.Name = "B_ADD";
            this.B_ADD.Size = new System.Drawing.Size(195, 23);
            this.B_ADD.TabIndex = 2;
            this.B_ADD.Text = "Add";
            this.B_ADD.UseVisualStyleBackColor = false;
            this.B_ADD.Click += new System.EventHandler(this.B_SCAN_Click);
            // 
            // G_INFO
            // 
            this.G_INFO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.G_INFO.Controls.Add(this.CB_OVERRIDE);
            this.G_INFO.Controls.Add(this.TB_COPY_TO_FOLDER);
            this.G_INFO.Controls.Add(this.TB_GAME_FOLDER);
            this.G_INFO.Controls.Add(this.TB_VMF);
            this.G_INFO.Controls.Add(this.B_COPY_TO);
            this.G_INFO.Controls.Add(this.B_GAME);
            this.G_INFO.Controls.Add(this.B_VMF);
            this.G_INFO.Controls.Add(this.checkBox6);
            this.G_INFO.Controls.Add(this.checkBox5);
            this.G_INFO.Controls.Add(this.CB_COPY_SOUNDS);
            this.G_INFO.Controls.Add(this.CB_COPY_TEXTURES);
            this.G_INFO.Controls.Add(this.CB_COPY_MODELS);
            this.G_INFO.Controls.Add(this.CB_COPY_MATERIALS);
            this.G_INFO.Controls.Add(this.label1);
            this.G_INFO.Controls.Add(this.label2);
            this.G_INFO.Controls.Add(this.label3);
            this.G_INFO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.G_INFO.ForeColor = System.Drawing.Color.White;
            this.G_INFO.Location = new System.Drawing.Point(12, 12);
            this.G_INFO.Name = "G_INFO";
            this.G_INFO.Size = new System.Drawing.Size(1000, 126);
            this.G_INFO.TabIndex = 5;
            this.G_INFO.TabStop = false;
            this.G_INFO.Text = "Info";
            // 
            // CB_OVERRIDE
            // 
            this.CB_OVERRIDE.AutoSize = true;
            this.CB_OVERRIDE.Checked = global::VMF_Copy.Properties.Settings.Default.cOR;
            this.CB_OVERRIDE.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::VMF_Copy.Properties.Settings.Default, "cOR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CB_OVERRIDE.Location = new System.Drawing.Point(740, 100);
            this.CB_OVERRIDE.Name = "CB_OVERRIDE";
            this.CB_OVERRIDE.Size = new System.Drawing.Size(66, 17);
            this.CB_OVERRIDE.TabIndex = 6;
            this.CB_OVERRIDE.Text = "Override";
            this.CB_OVERRIDE.UseVisualStyleBackColor = true;
            this.CB_OVERRIDE.CheckedChanged += new System.EventHandler(this.CB_OVERRIDE_CheckedChanged);
            // 
            // TB_COPY_TO_FOLDER
            // 
            this.TB_COPY_TO_FOLDER.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_COPY_TO_FOLDER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TB_COPY_TO_FOLDER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_COPY_TO_FOLDER.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::VMF_Copy.Properties.Settings.Default, "CopyToFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TB_COPY_TO_FOLDER.ForeColor = System.Drawing.Color.White;
            this.TB_COPY_TO_FOLDER.Location = new System.Drawing.Point(116, 73);
            this.TB_COPY_TO_FOLDER.Name = "TB_COPY_TO_FOLDER";
            this.TB_COPY_TO_FOLDER.Size = new System.Drawing.Size(793, 20);
            this.TB_COPY_TO_FOLDER.TabIndex = 5;
            this.TB_COPY_TO_FOLDER.Text = global::VMF_Copy.Properties.Settings.Default.CopyToFolder;
            // 
            // TB_GAME_FOLDER
            // 
            this.TB_GAME_FOLDER.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_GAME_FOLDER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TB_GAME_FOLDER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GAME_FOLDER.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::VMF_Copy.Properties.Settings.Default, "GameFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TB_GAME_FOLDER.ForeColor = System.Drawing.Color.White;
            this.TB_GAME_FOLDER.Location = new System.Drawing.Point(116, 46);
            this.TB_GAME_FOLDER.Name = "TB_GAME_FOLDER";
            this.TB_GAME_FOLDER.Size = new System.Drawing.Size(793, 20);
            this.TB_GAME_FOLDER.TabIndex = 5;
            this.TB_GAME_FOLDER.Text = global::VMF_Copy.Properties.Settings.Default.GameFolder;
            // 
            // TB_VMF
            // 
            this.TB_VMF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_VMF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TB_VMF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_VMF.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::VMF_Copy.Properties.Settings.Default, "vmfPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TB_VMF.ForeColor = System.Drawing.Color.White;
            this.TB_VMF.Location = new System.Drawing.Point(116, 19);
            this.TB_VMF.Name = "TB_VMF";
            this.TB_VMF.Size = new System.Drawing.Size(793, 20);
            this.TB_VMF.TabIndex = 5;
            this.TB_VMF.Text = global::VMF_Copy.Properties.Settings.Default.vmfPath;
            // 
            // B_COPY_TO
            // 
            this.B_COPY_TO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_COPY_TO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.B_COPY_TO.FlatAppearance.BorderSize = 0;
            this.B_COPY_TO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_COPY_TO.Location = new System.Drawing.Point(915, 71);
            this.B_COPY_TO.Name = "B_COPY_TO";
            this.B_COPY_TO.Size = new System.Drawing.Size(79, 23);
            this.B_COPY_TO.TabIndex = 4;
            this.B_COPY_TO.Text = "Browse";
            this.B_COPY_TO.UseVisualStyleBackColor = false;
            this.B_COPY_TO.Click += new System.EventHandler(this.B_COPY_TO_Click);
            // 
            // B_GAME
            // 
            this.B_GAME.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_GAME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.B_GAME.FlatAppearance.BorderSize = 0;
            this.B_GAME.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_GAME.Location = new System.Drawing.Point(915, 44);
            this.B_GAME.Name = "B_GAME";
            this.B_GAME.Size = new System.Drawing.Size(79, 23);
            this.B_GAME.TabIndex = 4;
            this.B_GAME.Text = "Browse";
            this.B_GAME.UseVisualStyleBackColor = false;
            this.B_GAME.Click += new System.EventHandler(this.B_GAME_Click);
            // 
            // B_VMF
            // 
            this.B_VMF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_VMF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.B_VMF.FlatAppearance.BorderSize = 0;
            this.B_VMF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_VMF.Location = new System.Drawing.Point(915, 17);
            this.B_VMF.Name = "B_VMF";
            this.B_VMF.Size = new System.Drawing.Size(79, 23);
            this.B_VMF.TabIndex = 4;
            this.B_VMF.Text = "Browse";
            this.B_VMF.UseVisualStyleBackColor = false;
            this.B_VMF.Click += new System.EventHandler(this.B_VMF_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = global::VMF_Copy.Properties.Settings.Default.cCC;
            this.checkBox6.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::VMF_Copy.Properties.Settings.Default, "cCC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(513, 100);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(128, 17);
            this.checkBox6.TabIndex = 3;
            this.checkBox6.Text = "Copy Color Correction";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = global::VMF_Copy.Properties.Settings.Default.cPar;
            this.checkBox5.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::VMF_Copy.Properties.Settings.Default, "cPar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(414, 100);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(93, 17);
            this.checkBox5.TabIndex = 3;
            this.checkBox5.Text = "Copy Particles";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // CB_COPY_SOUNDS
            // 
            this.CB_COPY_SOUNDS.AutoSize = true;
            this.CB_COPY_SOUNDS.Checked = global::VMF_Copy.Properties.Settings.Default.cSou;
            this.CB_COPY_SOUNDS.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::VMF_Copy.Properties.Settings.Default, "cSou", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CB_COPY_SOUNDS.Location = new System.Drawing.Point(319, 100);
            this.CB_COPY_SOUNDS.Name = "CB_COPY_SOUNDS";
            this.CB_COPY_SOUNDS.Size = new System.Drawing.Size(89, 17);
            this.CB_COPY_SOUNDS.TabIndex = 3;
            this.CB_COPY_SOUNDS.Text = "Copy Sounds";
            this.CB_COPY_SOUNDS.UseVisualStyleBackColor = true;
            // 
            // CB_COPY_TEXTURES
            // 
            this.CB_COPY_TEXTURES.AutoSize = true;
            this.CB_COPY_TEXTURES.Checked = global::VMF_Copy.Properties.Settings.Default.cTex;
            this.CB_COPY_TEXTURES.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::VMF_Copy.Properties.Settings.Default, "cTex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CB_COPY_TEXTURES.Location = new System.Drawing.Point(219, 100);
            this.CB_COPY_TEXTURES.Name = "CB_COPY_TEXTURES";
            this.CB_COPY_TEXTURES.Size = new System.Drawing.Size(94, 17);
            this.CB_COPY_TEXTURES.TabIndex = 2;
            this.CB_COPY_TEXTURES.Text = "Copy Textures";
            this.CB_COPY_TEXTURES.UseVisualStyleBackColor = true;
            // 
            // CB_COPY_MODELS
            // 
            this.CB_COPY_MODELS.AutoSize = true;
            this.CB_COPY_MODELS.Checked = global::VMF_Copy.Properties.Settings.Default.cMDL;
            this.CB_COPY_MODELS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_COPY_MODELS.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::VMF_Copy.Properties.Settings.Default, "cMDL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CB_COPY_MODELS.Location = new System.Drawing.Point(647, 100);
            this.CB_COPY_MODELS.Name = "CB_COPY_MODELS";
            this.CB_COPY_MODELS.Size = new System.Drawing.Size(87, 17);
            this.CB_COPY_MODELS.TabIndex = 2;
            this.CB_COPY_MODELS.Text = "Copy Models";
            this.CB_COPY_MODELS.UseVisualStyleBackColor = true;
            this.CB_COPY_MODELS.CheckedChanged += new System.EventHandler(this.CB_COPY_MODELS_CheckedChanged);
            // 
            // CB_COPY_MATERIALS
            // 
            this.CB_COPY_MATERIALS.AutoSize = true;
            this.CB_COPY_MATERIALS.Checked = global::VMF_Copy.Properties.Settings.Default.cMat;
            this.CB_COPY_MATERIALS.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::VMF_Copy.Properties.Settings.Default, "cMat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CB_COPY_MATERIALS.Location = new System.Drawing.Point(116, 100);
            this.CB_COPY_MATERIALS.Name = "CB_COPY_MATERIALS";
            this.CB_COPY_MATERIALS.Size = new System.Drawing.Size(94, 17);
            this.CB_COPY_MATERIALS.TabIndex = 2;
            this.CB_COPY_MATERIALS.Text = "Copy materials";
            this.CB_COPY_MATERIALS.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.CLB_FILTER);
            this.groupBox2.Enabled = false;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(14, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1000, 149);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.LV_LOG);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 325);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1000, 292);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // B_REMOVE
            // 
            this.B_REMOVE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.B_REMOVE.Enabled = false;
            this.B_REMOVE.FlatAppearance.BorderSize = 0;
            this.B_REMOVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_REMOVE.Location = new System.Drawing.Point(214, 296);
            this.B_REMOVE.Name = "B_REMOVE";
            this.B_REMOVE.Size = new System.Drawing.Size(195, 23);
            this.B_REMOVE.TabIndex = 2;
            this.B_REMOVE.Text = "Remove";
            this.B_REMOVE.UseVisualStyleBackColor = false;
            this.B_REMOVE.Click += new System.EventHandler(this.B_SCAN_Click);
            // 
            // B_CHECK_ALL
            // 
            this.B_CHECK_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.B_CHECK_ALL.Enabled = false;
            this.B_CHECK_ALL.FlatAppearance.BorderSize = 0;
            this.B_CHECK_ALL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_CHECK_ALL.Location = new System.Drawing.Point(413, 296);
            this.B_CHECK_ALL.Name = "B_CHECK_ALL";
            this.B_CHECK_ALL.Size = new System.Drawing.Size(195, 23);
            this.B_CHECK_ALL.TabIndex = 2;
            this.B_CHECK_ALL.Text = "Check all";
            this.B_CHECK_ALL.UseVisualStyleBackColor = false;
            this.B_CHECK_ALL.Click += new System.EventHandler(this.B_SCAN_Click);
            // 
            // B_UNCHECK_ALL
            // 
            this.B_UNCHECK_ALL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.B_UNCHECK_ALL.Enabled = false;
            this.B_UNCHECK_ALL.FlatAppearance.BorderSize = 0;
            this.B_UNCHECK_ALL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_UNCHECK_ALL.Location = new System.Drawing.Point(612, 296);
            this.B_UNCHECK_ALL.Name = "B_UNCHECK_ALL";
            this.B_UNCHECK_ALL.Size = new System.Drawing.Size(195, 23);
            this.B_UNCHECK_ALL.TabIndex = 2;
            this.B_UNCHECK_ALL.Text = "Uncheck all";
            this.B_UNCHECK_ALL.UseVisualStyleBackColor = false;
            this.B_UNCHECK_ALL.Click += new System.EventHandler(this.B_SCAN_Click);
            // 
            // B_INVERT
            // 
            this.B_INVERT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.B_INVERT.Enabled = false;
            this.B_INVERT.FlatAppearance.BorderSize = 0;
            this.B_INVERT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_INVERT.Location = new System.Drawing.Point(811, 296);
            this.B_INVERT.Name = "B_INVERT";
            this.B_INVERT.Size = new System.Drawing.Size(195, 23);
            this.B_INVERT.TabIndex = 2;
            this.B_INVERT.Text = "Invert";
            this.B_INVERT.UseVisualStyleBackColor = false;
            this.B_INVERT.Click += new System.EventHandler(this.B_SCAN_Click);
            // 
            // FORM_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1026, 658);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.G_INFO);
            this.Controls.Add(this.B_INVERT);
            this.Controls.Add(this.B_UNCHECK_ALL);
            this.Controls.Add(this.B_CHECK_ALL);
            this.Controls.Add(this.B_REMOVE);
            this.Controls.Add(this.B_ADD);
            this.Controls.Add(this.B_RUN);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::VMF_Copy.Properties.Settings.Default, "MainLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::VMF_Copy.Properties.Settings.Default.MainLocation;
            this.Name = "FORM_MAIN";
            this.Text = "VMF Copy";
            this.Load += new System.EventHandler(this.FORM_MAIN_Load);
            this.G_INFO.ResumeLayout(false);
            this.G_INFO.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_RUN;
        private System.Windows.Forms.ListView LV_LOG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox CLB_FILTER;
        private System.Windows.Forms.Button B_ADD;
        private System.Windows.Forms.GroupBox G_INFO;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox CB_COPY_SOUNDS;
        private System.Windows.Forms.CheckBox CB_COPY_TEXTURES;
        private System.Windows.Forms.CheckBox CB_COPY_MODELS;
        private System.Windows.Forms.CheckBox CB_COPY_MATERIALS;
        private System.Windows.Forms.ImageList OUTPUT_IMAGE_LIST;
        private System.Windows.Forms.ColumnHeader Icons;
        private System.Windows.Forms.ColumnHeader Detail;
        private System.Windows.Forms.Button B_COPY_TO;
        private System.Windows.Forms.Button B_GAME;
        private System.Windows.Forms.Button B_VMF;
        private System.Windows.Forms.TextBox TB_COPY_TO_FOLDER;
        private System.Windows.Forms.TextBox TB_GAME_FOLDER;
        private System.Windows.Forms.TextBox TB_VMF;
        private System.Windows.Forms.CheckBox CB_OVERRIDE;
        private System.Windows.Forms.Button B_REMOVE;
        private System.Windows.Forms.Button B_CHECK_ALL;
        private System.Windows.Forms.Button B_UNCHECK_ALL;
        private System.Windows.Forms.Button B_INVERT;
    }
}