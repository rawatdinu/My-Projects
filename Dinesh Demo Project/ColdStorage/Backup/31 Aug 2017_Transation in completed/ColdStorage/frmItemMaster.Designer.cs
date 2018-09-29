namespace ColdStorage
{
    partial class frmItemMaster
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdGoToList = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.cmdCancelSelection = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdViewDetail = new System.Windows.Forms.Button();
            this.cmdAddNewInList = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pnlMaster.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMaster
            // 
            this.pnlMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMaster.Controls.Add(this.panel1);
            this.pnlMaster.Controls.Add(this.cmdGoToList);
            this.pnlMaster.Controls.Add(this.txtRemarks);
            this.pnlMaster.Controls.Add(this.txtItemName);
            this.pnlMaster.Controls.Add(this.txtItemId);
            this.pnlMaster.Controls.Add(this.label9);
            this.pnlMaster.Controls.Add(this.label5);
            this.pnlMaster.Controls.Add(this.lblID);
            this.pnlMaster.Location = new System.Drawing.Point(12, 12);
            this.pnlMaster.Name = "pnlMaster";
            this.pnlMaster.Size = new System.Drawing.Size(807, 352);
            this.pnlMaster.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancel);
            this.panel1.Controls.Add(this.cmdNew);
            this.panel1.Controls.Add(this.cmdEdit);
            this.panel1.Controls.Add(this.cmdSave);
            this.panel1.Location = new System.Drawing.Point(24, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 58);
            this.panel1.TabIndex = 44;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(418, 8);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(121, 39);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(14, 8);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(121, 39);
            this.cmdNew.TabIndex = 12;
            this.cmdNew.Text = "Add New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(142, 8);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(121, 39);
            this.cmdEdit.TabIndex = 13;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(279, 8);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(121, 39);
            this.cmdSave.TabIndex = 11;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdGoToList
            // 
            this.cmdGoToList.Location = new System.Drawing.Point(258, 26);
            this.cmdGoToList.Name = "cmdGoToList";
            this.cmdGoToList.Size = new System.Drawing.Size(34, 26);
            this.cmdGoToList.TabIndex = 43;
            this.cmdGoToList.Text = "...";
            this.cmdGoToList.UseVisualStyleBackColor = true;
            this.cmdGoToList.Click += new System.EventHandler(this.cmdGoToList_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(93, 107);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(441, 20);
            this.txtRemarks.TabIndex = 10;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Location = new System.Drawing.Point(93, 70);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(441, 20);
            this.txtItemName.TabIndex = 2;
            // 
            // txtItemId
            // 
            this.txtItemId.BackColor = System.Drawing.Color.White;
            this.txtItemId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemId.Location = new System.Drawing.Point(93, 27);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(159, 20);
            this.txtItemId.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Remarks";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Item Name";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(28, 27);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 22;
            this.lblID.Text = "ID";
            // 
            // pnlList
            // 
            this.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlList.Controls.Add(this.pnlControl);
            this.pnlList.Controls.Add(this.cmdViewDetail);
            this.pnlList.Controls.Add(this.cmdAddNewInList);
            this.pnlList.Controls.Add(this.listView1);
            this.pnlList.Location = new System.Drawing.Point(12, 12);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(807, 352);
            this.pnlList.TabIndex = 23;
            // 
            // pnlControl
            // 
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.cmdCancelSelection);
            this.pnlControl.Controls.Add(this.cmdOK);
            this.pnlControl.Location = new System.Drawing.Point(184, 287);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(402, 52);
            this.pnlControl.TabIndex = 17;
            // 
            // cmdCancelSelection
            // 
            this.cmdCancelSelection.Location = new System.Drawing.Point(213, 6);
            this.cmdCancelSelection.Name = "cmdCancelSelection";
            this.cmdCancelSelection.Size = new System.Drawing.Size(121, 39);
            this.cmdCancelSelection.TabIndex = 18;
            this.cmdCancelSelection.Text = "Cancel";
            this.cmdCancelSelection.UseVisualStyleBackColor = true;
            this.cmdCancelSelection.Click += new System.EventHandler(this.cmdCancelSelection_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(67, 6);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(121, 39);
            this.cmdOK.TabIndex = 17;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdViewDetail
            // 
            this.cmdViewDetail.Location = new System.Drawing.Point(398, 8);
            this.cmdViewDetail.Name = "cmdViewDetail";
            this.cmdViewDetail.Size = new System.Drawing.Size(121, 39);
            this.cmdViewDetail.TabIndex = 16;
            this.cmdViewDetail.Text = "View Details";
            this.cmdViewDetail.UseVisualStyleBackColor = true;
            this.cmdViewDetail.Click += new System.EventHandler(this.cmdViewDetail_Click);
            // 
            // cmdAddNewInList
            // 
            this.cmdAddNewInList.Location = new System.Drawing.Point(252, 8);
            this.cmdAddNewInList.Name = "cmdAddNewInList";
            this.cmdAddNewInList.Size = new System.Drawing.Size(121, 39);
            this.cmdAddNewInList.TabIndex = 15;
            this.cmdAddNewInList.Text = "Add New";
            this.cmdAddNewInList.UseVisualStyleBackColor = true;
            this.cmdAddNewInList.Click += new System.EventHandler(this.cmdAddNewInList_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(3, 54);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(799, 221);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // frmItemMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 376);
            this.Controls.Add(this.pnlMaster);
            this.Controls.Add(this.pnlList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Books Master";
            this.Load += new System.EventHandler(this.frmItemMaster_Load);
            this.pnlMaster.ResumeLayout(false);
            this.pnlMaster.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlList.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMaster;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button cmdCancelSelection;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdViewDetail;
        private System.Windows.Forms.Button cmdAddNewInList;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button cmdGoToList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdCancel;

    }
}