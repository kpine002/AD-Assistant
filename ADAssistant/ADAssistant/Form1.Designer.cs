namespace ADAssistant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.clearbutton = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.usrBox = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.pidBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkKnightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helloKittyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tardisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ironManToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jARVISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seeREADMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nEWADMINTOOLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyBox = new System.Windows.Forms.ListBox();
            this.GroupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clearbutton
            // 
            this.clearbutton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.clearbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.clearbutton.Cursor = System.Windows.Forms.Cursors.Default;
            this.clearbutton.ForeColor = System.Drawing.Color.Black;
            this.clearbutton.Location = new System.Drawing.Point(11, 192);
            this.clearbutton.Name = "clearbutton";
            this.clearbutton.Size = new System.Drawing.Size(156, 41);
            this.clearbutton.TabIndex = 9;
            this.clearbutton.Text = "Clear";
            this.clearbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.clearbutton.UseVisualStyleBackColor = false;
            this.clearbutton.Click += new System.EventHandler(this.clearbutton_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.usrBox);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.pidBox);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(12, 27);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(156, 112);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Search";
            // 
            // usrBox
            // 
            this.usrBox.BackColor = System.Drawing.Color.White;
            this.usrBox.ForeColor = System.Drawing.Color.Black;
            this.usrBox.Location = new System.Drawing.Point(6, 80);
            this.usrBox.Name = "usrBox";
            this.usrBox.Size = new System.Drawing.Size(143, 20);
            this.usrBox.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 63);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(130, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Username / MAC Address";
            this.Label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(148, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Panther ID / Visitor Username\r\n";
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // pidBox
            // 
            this.pidBox.BackColor = System.Drawing.Color.White;
            this.pidBox.ForeColor = System.Drawing.Color.Black;
            this.pidBox.Location = new System.Drawing.Point(6, 36);
            this.pidBox.Name = "pidBox";
            this.pidBox.Size = new System.Drawing.Size(143, 20);
            this.pidBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.searchButton.ForeColor = System.Drawing.Color.Black;
            this.searchButton.Location = new System.Drawing.Point(11, 145);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(156, 41);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Search";
            this.searchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.pantherUser_Click);
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.Color.White;
            this.resultBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultBox.ForeColor = System.Drawing.Color.Black;
            this.resultBox.Location = new System.Drawing.Point(175, 27);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(397, 328);
            this.resultBox.TabIndex = 10;
            this.resultBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::ADAssistant.Properties.Resources.Actions_application_exit_icon;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.themeToolStripMenuItem,
            this.exportLogFileToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.generalToolStripMenuItem.Text = "General";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem1.Text = "Always On Top";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.darkKnightToolStripMenuItem,
            this.helloKittyToolStripMenuItem,
            this.tardisToolStripMenuItem,
            this.ironManToolStripMenuItem,
            this.jARVISToolStripMenuItem});
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.themeToolStripMenuItem.Text = "Theme (BETA)";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // darkKnightToolStripMenuItem
            // 
            this.darkKnightToolStripMenuItem.Name = "darkKnightToolStripMenuItem";
            this.darkKnightToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.darkKnightToolStripMenuItem.Text = "Dark Knight";
            this.darkKnightToolStripMenuItem.Click += new System.EventHandler(this.darkKnightToolStripMenuItem_Click);
            // 
            // helloKittyToolStripMenuItem
            // 
            this.helloKittyToolStripMenuItem.Name = "helloKittyToolStripMenuItem";
            this.helloKittyToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.helloKittyToolStripMenuItem.Text = "Hello Kitty";
            this.helloKittyToolStripMenuItem.Click += new System.EventHandler(this.helloKittyToolStripMenuItem_Click);
            // 
            // tardisToolStripMenuItem
            // 
            this.tardisToolStripMenuItem.Name = "tardisToolStripMenuItem";
            this.tardisToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.tardisToolStripMenuItem.Text = "TARDIS";
            this.tardisToolStripMenuItem.Click += new System.EventHandler(this.tardisToolStripMenuItem_Click);
            // 
            // ironManToolStripMenuItem
            // 
            this.ironManToolStripMenuItem.Name = "ironManToolStripMenuItem";
            this.ironManToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ironManToolStripMenuItem.Text = "Iron Man";
            this.ironManToolStripMenuItem.Click += new System.EventHandler(this.ironManToolStripMenuItem_Click);
            // 
            // jARVISToolStripMenuItem
            // 
            this.jARVISToolStripMenuItem.Name = "jARVISToolStripMenuItem";
            this.jARVISToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.jARVISToolStripMenuItem.Text = "J.A.R.V.I.S.";
            this.jARVISToolStripMenuItem.Click += new System.EventHandler(this.jARVISToolStripMenuItem_Click);
            // 
            // exportLogFileToolStripMenuItem
            // 
            this.exportLogFileToolStripMenuItem.Name = "exportLogFileToolStripMenuItem";
            this.exportLogFileToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exportLogFileToolStripMenuItem.Text = "Export Log File";
            this.exportLogFileToolStripMenuItem.Click += new System.EventHandler(this.exportLogFileToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seeREADMEToolStripMenuItem,
            this.versionToolStripMenuItem,
            this.nEWADMINTOOLToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // seeREADMEToolStripMenuItem
            // 
            this.seeREADMEToolStripMenuItem.Name = "seeREADMEToolStripMenuItem";
            this.seeREADMEToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.seeREADMEToolStripMenuItem.Text = "See README";
            this.seeREADMEToolStripMenuItem.Click += new System.EventHandler(this.seeREADMEToolStripMenuItem_Click);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.versionToolStripMenuItem.Text = "About AD Lookup";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // nEWADMINTOOLToolStripMenuItem
            // 
            this.nEWADMINTOOLToolStripMenuItem.Name = "nEWADMINTOOLToolStripMenuItem";
            this.nEWADMINTOOLToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.nEWADMINTOOLToolStripMenuItem.Text = "NEW ADMIN TOOL";
            this.nEWADMINTOOLToolStripMenuItem.Click += new System.EventHandler(this.nEWADMINTOOLToolStripMenuItem_Click);
            // 
            // historyBox
            // 
            this.historyBox.FormattingEnabled = true;
            this.historyBox.Location = new System.Drawing.Point(11, 271);
            this.historyBox.Name = "historyBox";
            this.historyBox.Size = new System.Drawing.Size(156, 82);
            this.historyBox.TabIndex = 14;
            this.historyBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.historyBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.historyBox_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(584, 367);
            this.Controls.Add(this.historyBox);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.clearbutton);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "AD Lookup";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button clearbutton;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox usrBox;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox pidBox;
        internal System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeREADMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkKnightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helloKittyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tardisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ironManToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jARVISToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nEWADMINTOOLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportLogFileToolStripMenuItem;
        private System.Windows.Forms.ListBox historyBox;
    }
}

