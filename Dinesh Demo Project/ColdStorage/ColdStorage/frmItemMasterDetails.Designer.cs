namespace ColdStorage
{
    partial class frmItemMasterDetails
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
            this.pnlMaster = new System.Windows.Forms.Panel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlMaster.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMaster
            // 
            this.pnlMaster.Controls.Add(this.cmdClose);
            this.pnlMaster.Controls.Add(this.label6);
            this.pnlMaster.Controls.Add(this.pnlControl);
            this.pnlMaster.Controls.Add(this.txtRemarks);
            this.pnlMaster.Controls.Add(this.txtItemName);
            this.pnlMaster.Controls.Add(this.txtItemId);
            this.pnlMaster.Controls.Add(this.label9);
            this.pnlMaster.Controls.Add(this.label5);
            this.pnlMaster.Controls.Add(this.lblID);
            this.pnlMaster.Location = new System.Drawing.Point(7, 6);
            this.pnlMaster.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMaster.Name = "pnlMaster";
            this.pnlMaster.Size = new System.Drawing.Size(535, 243);
            this.pnlMaster.TabIndex = 23;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(487, 2);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(44, 35);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "X";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(39)))), ((int)(((byte)(160)))));
            this.label6.Location = new System.Drawing.Point(18, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 24);
            this.label6.TabIndex = 45;
            this.label6.Text = "Set Item Rates";
            // 
            // pnlControl
            // 
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.cmdCancel);
            this.pnlControl.Controls.Add(this.cmdSave);
            this.pnlControl.Location = new System.Drawing.Point(108, 167);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(373, 46);
            this.pnlControl.TabIndex = 2;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.ForeColor = System.Drawing.Color.White;
            this.cmdCancel.Location = new System.Drawing.Point(127, 4);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(108, 35);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.ForeColor = System.Drawing.Color.White;
            this.cmdSave.Location = new System.Drawing.Point(4, 4);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(108, 35);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(108, 132);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(395, 26);
            this.txtRemarks.TabIndex = 1;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Location = new System.Drawing.Point(108, 99);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(212, 26);
            this.txtItemName.TabIndex = 0;
            // 
            // txtItemId
            // 
            this.txtItemId.BackColor = System.Drawing.Color.White;
            this.txtItemId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemId.Location = new System.Drawing.Point(108, 61);
            this.txtItemId.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.ReadOnly = true;
            this.txtItemId.Size = new System.Drawing.Size(212, 26);
            this.txtItemId.TabIndex = 1;
            this.txtItemId.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 134);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Remarks";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Item Name";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(18, 63);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 20);
            this.lblID.TabIndex = 22;
            this.lblID.Text = "ID";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(39)))), ((int)(((byte)(160)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(547, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 266);
            this.panel4.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(39)))), ((int)(((byte)(160)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 3);
            this.panel1.TabIndex = 25;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(39)))), ((int)(((byte)(160)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(3, 263);
            this.panel5.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(39)))), ((int)(((byte)(160)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 263);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(544, 3);
            this.panel3.TabIndex = 27;
            // 
            // frmItemMasterDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 266);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlMaster);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemMasterDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items Add/Update";
            this.Load += new System.EventHandler(this.frmItemMasterDetails_Load);
            this.pnlMaster.ResumeLayout(false);
            this.pnlMaster.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMaster;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
    }
}