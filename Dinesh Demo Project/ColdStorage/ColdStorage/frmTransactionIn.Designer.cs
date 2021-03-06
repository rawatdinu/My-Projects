﻿namespace ColdStorage
{
    partial class frmTransactionIn
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
            this.cmdPartyLookup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGoToList = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.cmdRemoveItem = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.dtpTranInDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtTranID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.cmdViewDetails = new System.Windows.Forms.Button();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.cmdCancelSelection = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdAddNewInList = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.pnlMaster.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.pnlList.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMaster
            // 
            this.pnlMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMaster.Controls.Add(this.txtContactNo);
            this.pnlMaster.Controls.Add(this.cmdPartyLookup);
            this.pnlMaster.Controls.Add(this.label4);
            this.pnlMaster.Controls.Add(this.label3);
            this.pnlMaster.Controls.Add(this.label2);
            this.pnlMaster.Controls.Add(this.txtAddress);
            this.pnlMaster.Controls.Add(this.txtPartyName);
            this.pnlMaster.Controls.Add(this.txtAmount);
            this.pnlMaster.Controls.Add(this.label1);
            this.pnlMaster.Controls.Add(this.cmdGoToList);
            this.pnlMaster.Controls.Add(this.panel2);
            this.pnlMaster.Controls.Add(this.panel1);
            this.pnlMaster.Controls.Add(this.dtpTranInDate);
            this.pnlMaster.Controls.Add(this.label11);
            this.pnlMaster.Controls.Add(this.txtRemarks);
            this.pnlMaster.Controls.Add(this.txtTranID);
            this.pnlMaster.Controls.Add(this.label9);
            this.pnlMaster.Controls.Add(this.lblID);
            this.pnlMaster.Location = new System.Drawing.Point(16, 15);
            this.pnlMaster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMaster.Name = "pnlMaster";
            this.pnlMaster.Size = new System.Drawing.Size(1315, 743);
            this.pnlMaster.TabIndex = 22;
            // 
            // cmdPartyLookup
            // 
            this.cmdPartyLookup.Location = new System.Drawing.Point(540, 84);
            this.cmdPartyLookup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdPartyLookup.Name = "cmdPartyLookup";
            this.cmdPartyLookup.Size = new System.Drawing.Size(51, 28);
            this.cmdPartyLookup.TabIndex = 62;
            this.cmdPartyLookup.Text = "...";
            this.cmdPartyLookup.UseVisualStyleBackColor = true;
            this.cmdPartyLookup.Click += new System.EventHandler(this.cmdPartyLookup_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 61;
            this.label4.Text = "Contact No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(697, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 60;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "Party Name";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(797, 120);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(478, 72);
            this.txtAddress.TabIndex = 57;
            // 
            // txtPartyName
            // 
            this.txtPartyName.BackColor = System.Drawing.Color.White;
            this.txtPartyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartyName.Location = new System.Drawing.Point(124, 82);
            this.txtPartyName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(407, 22);
            this.txtPartyName.TabIndex = 56;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(935, 590);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(186, 26);
            this.txtAmount.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(849, 597);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Amount";
            // 
            // cmdGoToList
            // 
            this.cmdGoToList.Location = new System.Drawing.Point(351, 31);
            this.cmdGoToList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdGoToList.Name = "cmdGoToList";
            this.cmdGoToList.Size = new System.Drawing.Size(51, 28);
            this.cmdGoToList.TabIndex = 53;
            this.cmdGoToList.Text = "...";
            this.cmdGoToList.UseVisualStyleBackColor = true;
            this.cmdGoToList.Click += new System.EventHandler(this.cmdGoToList_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdPrint);
            this.panel2.Controls.Add(this.cmdCancel);
            this.panel2.Controls.Add(this.cmdEdit);
            this.panel2.Controls.Add(this.cmdSave);
            this.panel2.Controls.Add(this.cmdNew);
            this.panel2.Location = new System.Drawing.Point(21, 639);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 71);
            this.panel2.TabIndex = 52;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(775, 7);
            this.cmdPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(161, 48);
            this.cmdPrint.TabIndex = 15;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(592, 7);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(161, 48);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(217, 11);
            this.cmdEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(161, 48);
            this.cmdEdit.TabIndex = 13;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(404, 10);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(161, 48);
            this.cmdSave.TabIndex = 11;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(29, 11);
            this.cmdNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(161, 48);
            this.cmdNew.TabIndex = 12;
            this.cmdNew.Text = "Add New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdAddItem);
            this.panel1.Controls.Add(this.cmdRemoveItem);
            this.panel1.Controls.Add(this.dgvMain);
            this.panel1.Location = new System.Drawing.Point(4, 225);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 345);
            this.panel1.TabIndex = 50;
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Location = new System.Drawing.Point(1143, 80);
            this.cmdAddItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(128, 48);
            this.cmdAddItem.TabIndex = 45;
            this.cmdAddItem.Text = "Add";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.cmdAddItem_Click);
            // 
            // cmdRemoveItem
            // 
            this.cmdRemoveItem.Location = new System.Drawing.Point(1145, 164);
            this.cmdRemoveItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdRemoveItem.Name = "cmdRemoveItem";
            this.cmdRemoveItem.Size = new System.Drawing.Size(125, 48);
            this.cmdRemoveItem.TabIndex = 44;
            this.cmdRemoveItem.Text = "Remove";
            this.cmdRemoveItem.UseVisualStyleBackColor = true;
            this.cmdRemoveItem.Click += new System.EventHandler(this.cmdRemoveItem_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(16, 11);
            this.dgvMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 51;
            this.dgvMain.Size = new System.Drawing.Size(1100, 324);
            this.dgvMain.TabIndex = 1;
            this.dgvMain.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellEndEdit);
            this.dgvMain.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellEnter);
            // 
            // dtpTranInDate
            // 
            this.dtpTranInDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTranInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranInDate.Location = new System.Drawing.Point(797, 30);
            this.dtpTranInDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTranInDate.Name = "dtpTranInDate";
            this.dtpTranInDate.Size = new System.Drawing.Size(225, 22);
            this.dtpTranInDate.TabIndex = 49;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(697, 32);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.TabIndex = 48;
            this.label11.Text = "Tran Date";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(104, 589);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(587, 22);
            this.txtRemarks.TabIndex = 10;
            // 
            // txtTranID
            // 
            this.txtTranID.BackColor = System.Drawing.Color.White;
            this.txtTranID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTranID.Location = new System.Drawing.Point(124, 33);
            this.txtTranID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTranID.Name = "txtTranID";
            this.txtTranID.Size = new System.Drawing.Size(211, 22);
            this.txtTranID.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 443);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 30;
            this.label9.Text = "Remarks";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(37, 33);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(74, 17);
            this.lblID.TabIndex = 22;
            this.lblID.Text = "Tran. In ID";
            // 
            // pnlList
            // 
            this.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlList.Controls.Add(this.cmdViewDetails);
            this.pnlList.Controls.Add(this.pnlControl);
            this.pnlList.Controls.Add(this.cmdAddNewInList);
            this.pnlList.Controls.Add(this.listView1);
            this.pnlList.Location = new System.Drawing.Point(16, 15);
            this.pnlList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(1315, 700);
            this.pnlList.TabIndex = 23;
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.Location = new System.Drawing.Point(517, 10);
            this.cmdViewDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(161, 48);
            this.cmdViewDetails.TabIndex = 18;
            this.cmdViewDetails.Text = "View Details";
            this.cmdViewDetails.UseVisualStyleBackColor = true;
            this.cmdViewDetails.Click += new System.EventHandler(this.cmdViewDetails_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.cmdCancelSelection);
            this.pnlControl.Controls.Add(this.cmdOK);
            this.pnlControl.Location = new System.Drawing.Point(232, 490);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(535, 64);
            this.pnlControl.TabIndex = 17;
            // 
            // cmdCancelSelection
            // 
            this.cmdCancelSelection.Location = new System.Drawing.Point(284, 7);
            this.cmdCancelSelection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancelSelection.Name = "cmdCancelSelection";
            this.cmdCancelSelection.Size = new System.Drawing.Size(161, 48);
            this.cmdCancelSelection.TabIndex = 18;
            this.cmdCancelSelection.Text = "Cancel";
            this.cmdCancelSelection.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(89, 7);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(161, 48);
            this.cmdOK.TabIndex = 17;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // cmdAddNewInList
            // 
            this.cmdAddNewInList.Location = new System.Drawing.Point(336, 10);
            this.cmdAddNewInList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdAddNewInList.Name = "cmdAddNewInList";
            this.cmdAddNewInList.Size = new System.Drawing.Size(161, 48);
            this.cmdAddNewInList.TabIndex = 15;
            this.cmdAddNewInList.Text = "Add New";
            this.cmdAddNewInList.UseVisualStyleBackColor = true;
            this.cmdAddNewInList.Click += new System.EventHandler(this.cmdAddNewInList_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(4, 66);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1271, 400);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // txtContactNo
            // 
            this.txtContactNo.BackColor = System.Drawing.Color.White;
            this.txtContactNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactNo.Location = new System.Drawing.Point(124, 120);
            this.txtContactNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactNo.Multiline = true;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(478, 72);
            this.txtContactNo.TabIndex = 63;
            // 
            // frmTransactionIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 771);
            this.Controls.Add(this.pnlMaster);
            this.Controls.Add(this.pnlList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransactionIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction In";
            this.Load += new System.EventHandler(this.frmTransactionIn_Load);
            this.pnlMaster.ResumeLayout(false);
            this.pnlMaster.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.pnlList.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMaster;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtTranID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button cmdCancelSelection;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdAddNewInList;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DateTimePicker dtpTranInDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.Button cmdRemoveItem;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdViewDetails;
        private System.Windows.Forms.Button cmdGoToList;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdPartyLookup;
        private System.Windows.Forms.TextBox txtContactNo;
    }
}