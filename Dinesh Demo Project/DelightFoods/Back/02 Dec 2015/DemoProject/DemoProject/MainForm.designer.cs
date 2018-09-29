namespace DemoProject
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
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cityMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.industryMaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foodItemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.transactionToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.masterToolStripMenuItem,
            this.foodItemMasterToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Master";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.generalToolStripMenuItem.Text = "Food Category Master";
            this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientMasterToolStripMenuItem,
            this.stateMasterToolStripMenuItem,
            this.cityMasterToolStripMenuItem,
            this.industryMaterToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // clientMasterToolStripMenuItem
            // 
            this.clientMasterToolStripMenuItem.Name = "clientMasterToolStripMenuItem";
            this.clientMasterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.clientMasterToolStripMenuItem.Text = "Client Master";
            this.clientMasterToolStripMenuItem.Click += new System.EventHandler(this.clientMasterToolStripMenuItem_Click);
            // 
            // stateMasterToolStripMenuItem
            // 
            this.stateMasterToolStripMenuItem.Name = "stateMasterToolStripMenuItem";
            this.stateMasterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.stateMasterToolStripMenuItem.Text = "State Master";
            this.stateMasterToolStripMenuItem.Click += new System.EventHandler(this.stateMasterToolStripMenuItem_Click);
            // 
            // cityMasterToolStripMenuItem
            // 
            this.cityMasterToolStripMenuItem.Name = "cityMasterToolStripMenuItem";
            this.cityMasterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cityMasterToolStripMenuItem.Text = "City Master";
            this.cityMasterToolStripMenuItem.Click += new System.EventHandler(this.cityMasterToolStripMenuItem_Click);
            // 
            // industryMaterToolStripMenuItem
            // 
            this.industryMaterToolStripMenuItem.Name = "industryMaterToolStripMenuItem";
            this.industryMaterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.industryMaterToolStripMenuItem.Text = "Industry Type Master";
            this.industryMaterToolStripMenuItem.Click += new System.EventHandler(this.industryMaterToolStripMenuItem_Click);
            // 
            // foodItemMasterToolStripMenuItem
            // 
            this.foodItemMasterToolStripMenuItem.Name = "foodItemMasterToolStripMenuItem";
            this.foodItemMasterToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.foodItemMasterToolStripMenuItem.Text = "Food Item Master";
            this.foodItemMasterToolStripMenuItem.Click += new System.EventHandler(this.foodItemMasterToolStripMenuItem_Click);
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviceToolStripMenuItem,
            this.saleToolStripMenuItem});
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.transactionToolStripMenuItem.Text = "Transaction";
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.serviceToolStripMenuItem.Text = "Service";
            this.serviceToolStripMenuItem.Click += new System.EventHandler(this.serviceToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // saleToolStripMenuItem
            // 
            this.saleToolStripMenuItem.Name = "saleToolStripMenuItem";
            this.saleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saleToolStripMenuItem.Text = "Sale";
            this.saleToolStripMenuItem.Click += new System.EventHandler(this.saleToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1182, 662);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cityMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem industryMaterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foodItemMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleToolStripMenuItem;


    }
}