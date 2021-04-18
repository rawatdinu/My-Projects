namespace ColdStorage
{
    partial class frmPartyMaster
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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmdNew = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlLookupControl = new System.Windows.Forms.Panel();
            this.cmdOKLookup = new System.Windows.Forms.Button();
            this.cmdCancelLookup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlLookupControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 51;
            this.dgvMain.Size = new System.Drawing.Size(979, 399);
            this.dgvMain.TabIndex = 18;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            this.dgvMain.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentDoubleClick);

            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(15, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 46);
            this.panel2.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Party Master";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Controls.Add(this.cmdSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(15, 46);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(997, 50);
            this.panel3.TabIndex = 25;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(9, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(285, 30);
            this.txtSearch.TabIndex = 8;
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.cmdSearch.FlatAppearance.BorderSize = 0;
            this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSearch.ForeColor = System.Drawing.Color.White;
            this.cmdSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSearch.Location = new System.Drawing.Point(303, 5);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(0);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(200, 35);
            this.cmdSearch.TabIndex = 7;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmdNew);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(15, 96);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(997, 50);
            this.panel4.TabIndex = 26;
            // 
            // cmdNew
            // 
            this.cmdNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.cmdNew.FlatAppearance.BorderSize = 0;
            this.cmdNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNew.ForeColor = System.Drawing.Color.White;
            this.cmdNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNew.Location = new System.Drawing.Point(0, 7);
            this.cmdNew.Margin = new System.Windows.Forms.Padding(0);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(200, 35);
            this.cmdNew.TabIndex = 10;
            this.cmdNew.Text = "New";
            this.cmdNew.UseVisualStyleBackColor = false;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvMain);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(15, 146);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(997, 426);
            this.panel5.TabIndex = 27;
            // 
            // pnlLookupControl
            // 
            this.pnlLookupControl.Controls.Add(this.cmdCancelLookup);
            this.pnlLookupControl.Controls.Add(this.cmdOKLookup);
            this.pnlLookupControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLookupControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLookupControl.Location = new System.Drawing.Point(15, 572);
            this.pnlLookupControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLookupControl.Name = "pnlLookupControl";
            this.pnlLookupControl.Size = new System.Drawing.Size(997, 50);
            this.pnlLookupControl.TabIndex = 28;
            // 
            // cmdOKLookup
            // 
            this.cmdOKLookup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.cmdOKLookup.FlatAppearance.BorderSize = 0;
            this.cmdOKLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOKLookup.ForeColor = System.Drawing.Color.White;
            this.cmdOKLookup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdOKLookup.Location = new System.Drawing.Point(0, 7);
            this.cmdOKLookup.Margin = new System.Windows.Forms.Padding(0);
            this.cmdOKLookup.Name = "cmdOKLookup";
            this.cmdOKLookup.Size = new System.Drawing.Size(200, 35);
            this.cmdOKLookup.TabIndex = 10;
            this.cmdOKLookup.Text = "OK";
            this.cmdOKLookup.UseVisualStyleBackColor = false;
            this.cmdOKLookup.Click += new System.EventHandler(this.cmdOKLookup_Click);
            // 
            // cmdCancelLookup
            // 
            this.cmdCancelLookup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.cmdCancelLookup.FlatAppearance.BorderSize = 0;
            this.cmdCancelLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancelLookup.ForeColor = System.Drawing.Color.White;
            this.cmdCancelLookup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelLookup.Location = new System.Drawing.Point(226, 8);
            this.cmdCancelLookup.Margin = new System.Windows.Forms.Padding(0);
            this.cmdCancelLookup.Name = "cmdCancelLookup";
            this.cmdCancelLookup.Size = new System.Drawing.Size(200, 35);
            this.cmdCancelLookup.TabIndex = 11;
            this.cmdCancelLookup.Text = "Cancel";
            this.cmdCancelLookup.UseVisualStyleBackColor = false;
            this.cmdCancelLookup.Click += new System.EventHandler(this.cmdCancelLookup_Click);
            // 
            // frmPartyMaster
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1012, 737);
            this.Controls.Add(this.pnlLookupControl);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPartyMaster";
            this.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.Text = "Item Master";
            this.Load += new System.EventHandler(this.frmPartyMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.pnlLookupControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlLookupControl;
        private System.Windows.Forms.Button cmdCancelLookup;
        private System.Windows.Forms.Button cmdOKLookup;
    }
}