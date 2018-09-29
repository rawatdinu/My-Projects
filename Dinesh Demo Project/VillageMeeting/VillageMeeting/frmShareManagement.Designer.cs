namespace VillageMeeting
{
    partial class frmShareManagement
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvShareList = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboShareDetails = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.btnSave2 = new System.Windows.Forms.Button();
            this.btnEdit2 = new System.Windows.Forms.Button();
            this.btnNew2 = new System.Windows.Forms.Button();
            this.cboSHName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtShareName = new System.Windows.Forms.TextBox();
            this.btnUpdateShare = new System.Windows.Forms.Button();
            this.dgvShareDetails = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboShareHolderList = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnUpdateSH = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareList)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareDetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.dgvShareList);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(696, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(331, 617);
            this.panel4.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(95, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Active Share List";
            // 
            // dgvShareList
            // 
            this.dgvShareList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShareList.Location = new System.Drawing.Point(5, 29);
            this.dgvShareList.Name = "dgvShareList";
            this.dgvShareList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvShareList.Size = new System.Drawing.Size(316, 580);
            this.dgvShareList.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboShareDetails);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.btnUpdateShare);
            this.panel2.Controls.Add(this.dgvShareDetails);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(357, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 617);
            this.panel2.TabIndex = 7;
            // 
            // cboShareDetails
            // 
            this.cboShareDetails.FormattingEnabled = true;
            this.cboShareDetails.Location = new System.Drawing.Point(8, 225);
            this.cboShareDetails.Name = "cboShareDetails";
            this.cboShareDetails.Size = new System.Drawing.Size(209, 21);
            this.cboShareDetails.TabIndex = 18;
            this.cboShareDetails.SelectedIndexChanged += new System.EventHandler(this.cboShareDetails_SelectedIndexChanged);
            this.cboShareDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSHName_KeyPress);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.cboSHName);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.txtShareName);
            this.panel5.Location = new System.Drawing.Point(5, 9);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(319, 203);
            this.panel5.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel2);
            this.panel3.Controls.Add(this.btnDelete2);
            this.panel3.Controls.Add(this.btnSave2);
            this.panel3.Controls.Add(this.btnEdit2);
            this.panel3.Controls.Add(this.btnNew2);
            this.panel3.Location = new System.Drawing.Point(2, 149);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(312, 37);
            this.panel3.TabIndex = 10;
            // 
            // btnCancel2
            // 
            this.btnCancel2.Location = new System.Drawing.Point(252, 6);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(60, 25);
            this.btnCancel2.TabIndex = 4;
            this.btnCancel2.Text = "Cancel";
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // btnDelete2
            // 
            this.btnDelete2.Location = new System.Drawing.Point(191, 6);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(56, 25);
            this.btnDelete2.TabIndex = 3;
            this.btnDelete2.Text = "Delete";
            this.btnDelete2.UseVisualStyleBackColor = true;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // btnSave2
            // 
            this.btnSave2.Location = new System.Drawing.Point(130, 6);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(56, 25);
            this.btnSave2.TabIndex = 2;
            this.btnSave2.Text = "Save";
            this.btnSave2.UseVisualStyleBackColor = true;
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // btnEdit2
            // 
            this.btnEdit2.Location = new System.Drawing.Point(69, 6);
            this.btnEdit2.Name = "btnEdit2";
            this.btnEdit2.Size = new System.Drawing.Size(56, 25);
            this.btnEdit2.TabIndex = 1;
            this.btnEdit2.Text = "Edit";
            this.btnEdit2.UseVisualStyleBackColor = true;
            this.btnEdit2.Click += new System.EventHandler(this.btnEdit2_Click);
            // 
            // btnNew2
            // 
            this.btnNew2.Location = new System.Drawing.Point(8, 6);
            this.btnNew2.Name = "btnNew2";
            this.btnNew2.Size = new System.Drawing.Size(56, 25);
            this.btnNew2.TabIndex = 0;
            this.btnNew2.Text = "New";
            this.btnNew2.UseVisualStyleBackColor = true;
            this.btnNew2.Click += new System.EventHandler(this.btnNew2_Click);
            // 
            // cboSHName
            // 
            this.cboSHName.FormattingEnabled = true;
            this.cboSHName.Location = new System.Drawing.Point(93, 25);
            this.cboSHName.Name = "cboSHName";
            this.cboSHName.Size = new System.Drawing.Size(209, 21);
            this.cboSHName.TabIndex = 12;
            this.cboSHName.SelectedIndexChanged += new System.EventHandler(this.cboSHName_SelectedIndexChanged);
            this.cboSHName.SelectionChangeCommitted += new System.EventHandler(this.cboSHName_SelectionChangeCommitted);
            this.cboSHName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSHName_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Share Holder";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(111, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Share Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Share Name";
            // 
            // txtShareName
            // 
            this.txtShareName.BackColor = System.Drawing.Color.White;
            this.txtShareName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShareName.Location = new System.Drawing.Point(93, 62);
            this.txtShareName.Name = "txtShareName";
            this.txtShareName.Size = new System.Drawing.Size(209, 20);
            this.txtShareName.TabIndex = 0;
            // 
            // btnUpdateShare
            // 
            this.btnUpdateShare.Location = new System.Drawing.Point(235, 221);
            this.btnUpdateShare.Name = "btnUpdateShare";
            this.btnUpdateShare.Size = new System.Drawing.Size(61, 25);
            this.btnUpdateShare.TabIndex = 16;
            this.btnUpdateShare.Text = "Update";
            this.btnUpdateShare.UseVisualStyleBackColor = true;
            this.btnUpdateShare.Click += new System.EventHandler(this.btnUpdateShare_Click);
            // 
            // dgvShareDetails
            // 
            this.dgvShareDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShareDetails.Location = new System.Drawing.Point(8, 256);
            this.dgvShareDetails.Name = "dgvShareDetails";
            this.dgvShareDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvShareDetails.Size = new System.Drawing.Size(316, 353);
            this.dgvShareDetails.TabIndex = 11;
            this.dgvShareDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShareDetails_CellClick);
            this.dgvShareDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvShareDetails_KeyDown);
            this.dgvShareDetails.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvShareDetails_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboShareHolderList);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.btnUpdateSH);
            this.panel1.Controls.Add(this.dgvDetails);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(6, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 617);
            this.panel1.TabIndex = 6;
            // 
            // cboShareHolderList
            // 
            this.cboShareHolderList.FormattingEnabled = true;
            this.cboShareHolderList.Location = new System.Drawing.Point(12, 226);
            this.cboShareHolderList.Name = "cboShareHolderList";
            this.cboShareHolderList.Size = new System.Drawing.Size(209, 21);
            this.cboShareHolderList.TabIndex = 16;
            this.cboShareHolderList.SelectedIndexChanged += new System.EventHandler(this.cboShareHolderList_SelectedIndexChanged);
            this.cboShareHolderList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSHName_KeyPress);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.txtEmail);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.txtName);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.txtAddress);
            this.panel6.Controls.Add(this.pnlControl);
            this.panel6.Controls.Add(this.txtPhone);
            this.panel6.Location = new System.Drawing.Point(6, 9);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(327, 203);
            this.panel6.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(94, 119);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(215, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phone No.";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(94, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(215, 20);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sh.Holder Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Share Holder Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(94, 61);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(215, 20);
            this.txtAddress.TabIndex = 1;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Controls.Add(this.btnDelete);
            this.pnlControl.Controls.Add(this.btnSave);
            this.pnlControl.Controls.Add(this.btnEdit);
            this.pnlControl.Controls.Add(this.btnAdd);
            this.pnlControl.Location = new System.Drawing.Point(1, 145);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(324, 37);
            this.pnlControl.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(261, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(197, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(133, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(69, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(61, 25);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(5, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(94, 91);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(215, 20);
            this.txtPhone.TabIndex = 2;
            // 
            // btnUpdateSH
            // 
            this.btnUpdateSH.Location = new System.Drawing.Point(242, 222);
            this.btnUpdateSH.Name = "btnUpdateSH";
            this.btnUpdateSH.Size = new System.Drawing.Size(61, 25);
            this.btnUpdateSH.TabIndex = 14;
            this.btnUpdateSH.Text = "Update";
            this.btnUpdateSH.UseVisualStyleBackColor = true;
            this.btnUpdateSH.Click += new System.EventHandler(this.btnUpdateSH_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(9, 256);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetails.Size = new System.Drawing.Size(323, 353);
            this.dgvDetails.TabIndex = 11;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            this.dgvDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDetails_KeyDown);
            this.dgvDetails.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvDetails_KeyUp);
            // 
            // frmShareManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 630);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShareManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share Management";
            this.Load += new System.EventHandler(this.frmShareManagement_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvShareList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvShareDetails;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.Button btnSave2;
        private System.Windows.Forms.Button btnEdit2;
        private System.Windows.Forms.Button btnNew2;
        private System.Windows.Forms.TextBox txtShareName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSHName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnUpdateShare;
        private System.Windows.Forms.Button btnUpdateSH;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cboShareDetails;
        private System.Windows.Forms.ComboBox cboShareHolderList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
    }
}