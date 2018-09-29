namespace VillageMeeting
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capitalLoanSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meetingFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capitalLoanSettingToolStripMenuItem,
            this.shareManagerToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.menuToolStripMenuItem.Text = "Master";
            // 
            // capitalLoanSettingToolStripMenuItem
            // 
            this.capitalLoanSettingToolStripMenuItem.Name = "capitalLoanSettingToolStripMenuItem";
            this.capitalLoanSettingToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.capitalLoanSettingToolStripMenuItem.Text = "Capital/Loan Setting";
            this.capitalLoanSettingToolStripMenuItem.Click += new System.EventHandler(this.capitalLoanSettingToolStripMenuItem_Click);
            // 
            // shareManagerToolStripMenuItem
            // 
            this.shareManagerToolStripMenuItem.Name = "shareManagerToolStripMenuItem";
            this.shareManagerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.shareManagerToolStripMenuItem.Text = "Share Manager";
            this.shareManagerToolStripMenuItem.Click += new System.EventHandler(this.shareManagerToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meetingFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // meetingFileToolStripMenuItem
            // 
            this.meetingFileToolStripMenuItem.Name = "meetingFileToolStripMenuItem";
            this.meetingFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.meetingFileToolStripMenuItem.Text = "Meeting File";
            this.meetingFileToolStripMenuItem.Click += new System.EventHandler(this.meetingFileToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1182, 662);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Village Meeting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capitalLoanSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meetingFileToolStripMenuItem;

    }
}