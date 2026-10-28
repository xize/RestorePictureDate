namespace RestorePictureDate
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rtargettext = new System.Windows.Forms.TextBox();
            this.rtargetbtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.restorebtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.copytargetfield = new System.Windows.Forms.TextBox();
            this.copytargetbtn = new System.Windows.Forms.Button();
            this.copypastebtn = new System.Windows.Forms.Button();
            this.copyimgsrcbtn = new System.Windows.Forms.Button();
            this.copysrcfield = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rtargetdialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.currentfiletext = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.copysrcdialog = new System.Windows.Forms.FolderBrowserDialog();
            this.copydstdialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(99, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 117);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 86);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // rtargettext
            // 
            this.rtargettext.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rtargettext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtargettext.Location = new System.Drawing.Point(87, 110);
            this.rtargettext.Name = "rtargettext";
            this.rtargettext.ReadOnly = true;
            this.rtargettext.Size = new System.Drawing.Size(226, 13);
            this.rtargettext.TabIndex = 2;
            // 
            // rtargetbtn
            // 
            this.rtargetbtn.Location = new System.Drawing.Point(6, 105);
            this.rtargetbtn.Name = "rtargetbtn";
            this.rtargetbtn.Size = new System.Drawing.Size(75, 23);
            this.rtargetbtn.TabIndex = 3;
            this.rtargetbtn.Text = "Target";
            this.rtargetbtn.UseVisualStyleBackColor = true;
            this.rtargetbtn.Click += new System.EventHandler(this.rtargetbtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.restorebtn);
            this.groupBox2.Controls.Add(this.rtargetbtn);
            this.groupBox2.Controls.Add(this.rtargettext);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 158);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restore Dates";
            // 
            // restorebtn
            // 
            this.restorebtn.Location = new System.Drawing.Point(114, 129);
            this.restorebtn.Name = "restorebtn";
            this.restorebtn.Size = new System.Drawing.Size(75, 23);
            this.restorebtn.TabIndex = 4;
            this.restorebtn.Text = "Restore";
            this.restorebtn.UseVisualStyleBackColor = true;
            this.restorebtn.Click += new System.EventHandler(this.restorebtn_ClickAsync);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.copytargetfield);
            this.groupBox3.Controls.Add(this.copytargetbtn);
            this.groupBox3.Controls.Add(this.copypastebtn);
            this.groupBox3.Controls.Add(this.copyimgsrcbtn);
            this.groupBox3.Controls.Add(this.copysrcfield);
            this.groupBox3.Location = new System.Drawing.Point(12, 298);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(319, 152);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Copy and preserve dates";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 48);
            this.label2.TabIndex = 7;
            this.label2.Text = "This copies already existing files safely without compromising the creation date " +
    "to a other location.\r\nThis however does not restore dates.";
            // 
            // copytargetfield
            // 
            this.copytargetfield.BackColor = System.Drawing.SystemColors.ControlLight;
            this.copytargetfield.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.copytargetfield.Location = new System.Drawing.Point(90, 101);
            this.copytargetfield.Name = "copytargetfield";
            this.copytargetfield.Size = new System.Drawing.Size(223, 13);
            this.copytargetfield.TabIndex = 6;
            // 
            // copytargetbtn
            // 
            this.copytargetbtn.AutoSize = true;
            this.copytargetbtn.Location = new System.Drawing.Point(6, 96);
            this.copytargetbtn.Name = "copytargetbtn";
            this.copytargetbtn.Size = new System.Drawing.Size(78, 23);
            this.copytargetbtn.TabIndex = 5;
            this.copytargetbtn.Text = "Target folder";
            this.copytargetbtn.UseVisualStyleBackColor = true;
            this.copytargetbtn.Click += new System.EventHandler(this.copytargetbtn_Click);
            // 
            // copypastebtn
            // 
            this.copypastebtn.AutoSize = true;
            this.copypastebtn.Location = new System.Drawing.Point(114, 120);
            this.copypastebtn.Name = "copypastebtn";
            this.copypastebtn.Size = new System.Drawing.Size(92, 23);
            this.copypastebtn.TabIndex = 4;
            this.copypastebtn.Text = "&Copy and Paste";
            this.copypastebtn.UseVisualStyleBackColor = true;
            this.copypastebtn.Click += new System.EventHandler(this.copypastebtn_Click);
            // 
            // copyimgsrcbtn
            // 
            this.copyimgsrcbtn.AutoSize = true;
            this.copyimgsrcbtn.Location = new System.Drawing.Point(6, 67);
            this.copyimgsrcbtn.Name = "copyimgsrcbtn";
            this.copyimgsrcbtn.Size = new System.Drawing.Size(78, 23);
            this.copyimgsrcbtn.TabIndex = 3;
            this.copyimgsrcbtn.Text = "Image Folder";
            this.copyimgsrcbtn.UseVisualStyleBackColor = true;
            this.copyimgsrcbtn.Click += new System.EventHandler(this.copyimgsrcbtn_Click);
            // 
            // copysrcfield
            // 
            this.copysrcfield.BackColor = System.Drawing.SystemColors.ControlLight;
            this.copysrcfield.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.copysrcfield.Location = new System.Drawing.Point(90, 72);
            this.copysrcfield.Name = "copysrcfield";
            this.copysrcfield.Size = new System.Drawing.Size(223, 13);
            this.copysrcfield.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 488);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(238, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // rtargetdialog
            // 
            this.rtargetdialog.ShowNewFolderButton = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 456);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 26);
            this.panel2.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.currentfiletext);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(65, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(254, 26);
            this.panel4.TabIndex = 1;
            // 
            // currentfiletext
            // 
            this.currentfiletext.AutoEllipsis = true;
            this.currentfiletext.Location = new System.Drawing.Point(0, 13);
            this.currentfiletext.Name = "currentfiletext";
            this.currentfiletext.Size = new System.Drawing.Size(141, 13);
            this.currentfiletext.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(65, 26);
            this.panel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(0, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current FIle:";
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(256, 488);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 9;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // copysrcdialog
            // 
            this.copysrcdialog.ShowNewFolderButton = false;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 523);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(359, 562);
            this.Name = "Window";
            this.Text = "Restore Picture Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog rtargetdialog;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Button restorebtn;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button rtargetbtn;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox copytargetfield;
        public System.Windows.Forms.Button copytargetbtn;
        public System.Windows.Forms.Button copypastebtn;
        public System.Windows.Forms.Button copyimgsrcbtn;
        public System.Windows.Forms.TextBox copysrcfield;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox rtargettext;
        public System.Windows.Forms.Button cancelbtn;
        public System.Windows.Forms.Label currentfiletext;
        public System.Windows.Forms.FolderBrowserDialog copysrcdialog;
        private System.Windows.Forms.FolderBrowserDialog copydstdialog;
    }
}

