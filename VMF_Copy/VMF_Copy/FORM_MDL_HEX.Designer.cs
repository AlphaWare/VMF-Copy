namespace VMF_Copy
{
    partial class FORM_MDL_HEX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_MDL_HEX));
            this.FCT_HEX_VIEW = new FastColoredTextBoxNS.FastColoredTextBox();
            this.FCTB_TO_ASCII = new FastColoredTextBoxNS.FastColoredTextBox();
            this.B_STOP = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.B_ADD = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.B_NEXT = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.B_FIND = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FCT_HEX_VIEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FCTB_TO_ASCII)).BeginInit();
            this.SuspendLayout();
            // 
            // FCT_HEX_VIEW
            // 
            this.FCT_HEX_VIEW.AllowDrop = false;
            this.FCT_HEX_VIEW.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.FCT_HEX_VIEW.AutoScrollMinSize = new System.Drawing.Size(0, 13);
            this.FCT_HEX_VIEW.BackBrush = null;
            this.FCT_HEX_VIEW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FCT_HEX_VIEW.CharHeight = 13;
            this.FCT_HEX_VIEW.CharWidth = 7;
            this.FCT_HEX_VIEW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FCT_HEX_VIEW.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.FCT_HEX_VIEW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FCT_HEX_VIEW.Font = new System.Drawing.Font("Courier New", 9F);
            this.FCT_HEX_VIEW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.FCT_HEX_VIEW.HighlightFoldingIndicator = false;
            this.FCT_HEX_VIEW.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.FCT_HEX_VIEW.IsReplaceMode = false;
            this.FCT_HEX_VIEW.LineNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(90)))), ((int)(((byte)(93)))));
            this.FCT_HEX_VIEW.LineNumberStartValue = ((uint)(0u));
            this.FCT_HEX_VIEW.Location = new System.Drawing.Point(0, 0);
            this.FCT_HEX_VIEW.Name = "FCT_HEX_VIEW";
            this.FCT_HEX_VIEW.Paddings = new System.Windows.Forms.Padding(0);
            this.FCT_HEX_VIEW.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FCT_HEX_VIEW.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("FCT_HEX_VIEW.ServiceColors")));
            this.FCT_HEX_VIEW.ServiceLinesColor = System.Drawing.Color.Brown;
            this.FCT_HEX_VIEW.ShowLineNumbers = false;
            this.FCT_HEX_VIEW.Size = new System.Drawing.Size(1130, 677);
            this.FCT_HEX_VIEW.TabIndex = 0;
            this.FCT_HEX_VIEW.Text = "To Hex";
            this.FCT_HEX_VIEW.TextAreaBorderColor = System.Drawing.Color.DarkTurquoise;
            this.FCT_HEX_VIEW.WordWrap = true;
            this.FCT_HEX_VIEW.Zoom = 100;
            this.FCT_HEX_VIEW.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.FCT_HEX_VIEW_TextChanged);
            this.FCT_HEX_VIEW.SelectionChanged += new System.EventHandler(this.FCT_HEX_VIEW_SelectionChanged);
            this.FCT_HEX_VIEW.Load += new System.EventHandler(this.FCT_HEX_VIEW_Load);
            this.FCT_HEX_VIEW.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FCT_HEX_VIEW_Scroll);
            this.FCT_HEX_VIEW.RegionChanged += new System.EventHandler(this.FCT_HEX_VIEW_RegionChanged);
            // 
            // FCTB_TO_ASCII
            // 
            this.FCTB_TO_ASCII.AllowDrop = false;
            this.FCTB_TO_ASCII.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.FCTB_TO_ASCII.AutoScrollMinSize = new System.Drawing.Size(50, 12);
            this.FCTB_TO_ASCII.BackBrush = null;
            this.FCTB_TO_ASCII.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.FCTB_TO_ASCII.CharHeight = 12;
            this.FCTB_TO_ASCII.CharWidth = 6;
            this.FCTB_TO_ASCII.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FCTB_TO_ASCII.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.FCTB_TO_ASCII.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FCTB_TO_ASCII.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.FCTB_TO_ASCII.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(90)))), ((int)(((byte)(93)))));
            this.FCTB_TO_ASCII.HighlightFoldingIndicator = false;
            this.FCTB_TO_ASCII.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.FCTB_TO_ASCII.IsReplaceMode = false;
            this.FCTB_TO_ASCII.LineNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(90)))), ((int)(((byte)(93)))));
            this.FCTB_TO_ASCII.LineNumberStartValue = ((uint)(0u));
            this.FCTB_TO_ASCII.Location = new System.Drawing.Point(0, 524);
            this.FCTB_TO_ASCII.Name = "FCTB_TO_ASCII";
            this.FCTB_TO_ASCII.Paddings = new System.Windows.Forms.Padding(0);
            this.FCTB_TO_ASCII.ReadOnly = true;
            this.FCTB_TO_ASCII.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FCTB_TO_ASCII.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("FCTB_TO_ASCII.ServiceColors")));
            this.FCTB_TO_ASCII.ServiceLinesColor = System.Drawing.Color.Brown;
            this.FCTB_TO_ASCII.ShowLineNumbers = false;
            this.FCTB_TO_ASCII.Size = new System.Drawing.Size(1130, 15);
            this.FCTB_TO_ASCII.TabIndex = 1;
            this.FCTB_TO_ASCII.Text = "To ASCII";
            this.FCTB_TO_ASCII.TextAreaBorderColor = System.Drawing.Color.DarkTurquoise;
            this.FCTB_TO_ASCII.Zoom = 100;
            // 
            // B_STOP
            // 
            this.B_STOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.B_STOP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.B_STOP.FlatAppearance.BorderSize = 0;
            this.B_STOP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.B_STOP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.B_STOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_STOP.Font = new System.Drawing.Font("Consolas", 9F);
            this.B_STOP.ForeColor = System.Drawing.Color.White;
            this.B_STOP.Image = global::VMF_Copy.Properties.Resources.Delete_Filled_16__1_;
            this.B_STOP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_STOP.Location = new System.Drawing.Point(0, 677);
            this.B_STOP.Name = "B_STOP";
            this.B_STOP.Size = new System.Drawing.Size(1130, 23);
            this.B_STOP.TabIndex = 5;
            this.B_STOP.Text = "STOP";
            this.B_STOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_STOP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_STOP.UseVisualStyleBackColor = false;
            this.B_STOP.Click += new System.EventHandler(this.B_STOP_Click);
            this.B_STOP.MouseEnter += new System.EventHandler(this.B_FIND_MouseEnter);
            this.B_STOP.MouseHover += new System.EventHandler(this.B_FIND_MouseHover);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Consolas", 9F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::VMF_Copy.Properties.Resources.Teapot_16__1_;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 585);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(1130, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "SHOW PATTARENS";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.B_FIND_MouseEnter);
            this.button3.MouseHover += new System.EventHandler(this.B_FIND_MouseHover);
            // 
            // B_ADD
            // 
            this.B_ADD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.B_ADD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.B_ADD.FlatAppearance.BorderSize = 0;
            this.B_ADD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.B_ADD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.B_ADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_ADD.Font = new System.Drawing.Font("Consolas", 9F);
            this.B_ADD.ForeColor = System.Drawing.Color.White;
            this.B_ADD.Image = global::VMF_Copy.Properties.Resources.Add_Database_16;
            this.B_ADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_ADD.Location = new System.Drawing.Point(0, 562);
            this.B_ADD.Name = "B_ADD";
            this.B_ADD.Size = new System.Drawing.Size(1130, 23);
            this.B_ADD.TabIndex = 3;
            this.B_ADD.Text = "ADD SELECTED HEX TO PATTERNS.BIN";
            this.B_ADD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_ADD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_ADD.UseVisualStyleBackColor = false;
            this.B_ADD.Click += new System.EventHandler(this.B_ADD_Click);
            this.B_ADD.MouseEnter += new System.EventHandler(this.B_FIND_MouseEnter);
            this.B_ADD.MouseHover += new System.EventHandler(this.B_FIND_MouseHover);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Consolas", 9F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::VMF_Copy.Properties.Resources.Folder_16;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 608);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(1130, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "FIND MATERIALS PATH";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_NEXT_Click);
            this.button2.MouseEnter += new System.EventHandler(this.B_FIND_MouseEnter);
            this.button2.MouseHover += new System.EventHandler(this.B_FIND_MouseHover);
            // 
            // B_NEXT
            // 
            this.B_NEXT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.B_NEXT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.B_NEXT.FlatAppearance.BorderSize = 0;
            this.B_NEXT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.B_NEXT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.B_NEXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_NEXT.Font = new System.Drawing.Font("Consolas", 9F);
            this.B_NEXT.ForeColor = System.Drawing.Color.White;
            this.B_NEXT.Image = global::VMF_Copy.Properties.Resources.Right_16;
            this.B_NEXT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_NEXT.Location = new System.Drawing.Point(0, 654);
            this.B_NEXT.Name = "B_NEXT";
            this.B_NEXT.Size = new System.Drawing.Size(1130, 23);
            this.B_NEXT.TabIndex = 2;
            this.B_NEXT.Text = "NEXT";
            this.B_NEXT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_NEXT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_NEXT.UseVisualStyleBackColor = false;
            this.B_NEXT.Click += new System.EventHandler(this.B_NEXT_Click);
            this.B_NEXT.MouseEnter += new System.EventHandler(this.B_FIND_MouseEnter);
            this.B_NEXT.MouseHover += new System.EventHandler(this.B_FIND_MouseHover);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::VMF_Copy.Properties.Resources.Material;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 631);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1130, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "FIND MATERIALS";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.B_FIND_Click);
            this.button1.MouseEnter += new System.EventHandler(this.B_FIND_MouseEnter);
            this.button1.MouseHover += new System.EventHandler(this.B_FIND_MouseHover);
            // 
            // B_FIND
            // 
            this.B_FIND.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.B_FIND.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.B_FIND.FlatAppearance.BorderSize = 0;
            this.B_FIND.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.B_FIND.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.B_FIND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_FIND.Font = new System.Drawing.Font("Consolas", 9F);
            this.B_FIND.ForeColor = System.Drawing.Color.White;
            this.B_FIND.Image = global::VMF_Copy.Properties.Resources.Search_16;
            this.B_FIND.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_FIND.Location = new System.Drawing.Point(0, 539);
            this.B_FIND.Name = "B_FIND";
            this.B_FIND.Size = new System.Drawing.Size(1130, 23);
            this.B_FIND.TabIndex = 4;
            this.B_FIND.Text = "FIND USING PATTERNS.BIN";
            this.B_FIND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_FIND.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_FIND.UseVisualStyleBackColor = false;
            this.B_FIND.Click += new System.EventHandler(this.B_FIND_Click);
            this.B_FIND.MouseEnter += new System.EventHandler(this.B_FIND_MouseEnter);
            this.B_FIND.MouseHover += new System.EventHandler(this.B_FIND_MouseHover);
            // 
            // FORM_MDL_HEX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1130, 700);
            this.Controls.Add(this.FCTB_TO_ASCII);
            this.Controls.Add(this.B_FIND);
            this.Controls.Add(this.B_ADD);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.B_NEXT);
            this.Controls.Add(this.FCT_HEX_VIEW);
            this.Controls.Add(this.B_STOP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORM_MDL_HEX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDL Hex (For debugging)";
            this.Load += new System.EventHandler(this.FORM_MDL_HEX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FCT_HEX_VIEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FCTB_TO_ASCII)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox FCT_HEX_VIEW;
        private FastColoredTextBoxNS.FastColoredTextBox FCTB_TO_ASCII;
        private System.Windows.Forms.Button B_NEXT;
        private System.Windows.Forms.Button B_ADD;
        private System.Windows.Forms.Button B_FIND;
        private System.Windows.Forms.Button B_STOP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}