namespace Library
{
    partial class frmBooksTransactionIn
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
            this.pnlMaster.Controls.Add(this.cmdGoToList);
            this.pnlMaster.Controls.Add(this.panel2);
            this.pnlMaster.Controls.Add(this.panel1);
            this.pnlMaster.Controls.Add(this.dtpTranInDate);
            this.pnlMaster.Controls.Add(this.label11);
            this.pnlMaster.Controls.Add(this.txtRemarks);
            this.pnlMaster.Controls.Add(this.txtTranID);
            this.pnlMaster.Controls.Add(this.label9);
            this.pnlMaster.Controls.Add(this.lblID);
            this.pnlMaster.Location = new System.Drawing.Point(12, 12);
            this.pnlMaster.Name = "pnlMaster";
            this.pnlMaster.Size = new System.Drawing.Size(987, 475);
            this.pnlMaster.TabIndex = 22;
            // 
            // cmdGoToList
            // 
            this.cmdGoToList.Location = new System.Drawing.Point(263, 25);
            this.cmdGoToList.Name = "cmdGoToList";
            this.cmdGoToList.Size = new System.Drawing.Size(38, 23);
            this.cmdGoToList.TabIndex = 53;
            this.cmdGoToList.Text = "...";
            this.cmdGoToList.UseVisualStyleBackColor = true;
            this.cmdGoToList.Click += new System.EventHandler(this.cmdGoToList_Click_1);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdPrint);
            this.panel2.Controls.Add(this.cmdCancel);
            this.panel2.Controls.Add(this.cmdEdit);
            this.panel2.Controls.Add(this.cmdSave);
            this.panel2.Controls.Add(this.cmdNew);
            this.panel2.Location = new System.Drawing.Point(16, 398);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 58);
            this.panel2.TabIndex = 52;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(581, 6);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(121, 39);
            this.cmdPrint.TabIndex = 15;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(444, 6);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(121, 39);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(163, 9);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(121, 39);
            this.cmdEdit.TabIndex = 13;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(303, 8);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(121, 39);
            this.cmdSave.TabIndex = 11;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(22, 9);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(121, 39);
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
            this.panel1.Location = new System.Drawing.Point(3, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 281);
            this.panel1.TabIndex = 50;
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Location = new System.Drawing.Point(857, 65);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(96, 39);
            this.cmdAddItem.TabIndex = 45;
            this.cmdAddItem.Text = "Add";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.cmdAddItem_Click);
            // 
            // cmdRemoveItem
            // 
            this.cmdRemoveItem.Location = new System.Drawing.Point(859, 133);
            this.cmdRemoveItem.Name = "cmdRemoveItem";
            this.cmdRemoveItem.Size = new System.Drawing.Size(94, 39);
            this.cmdRemoveItem.TabIndex = 44;
            this.cmdRemoveItem.Text = "Remove";
            this.cmdRemoveItem.UseVisualStyleBackColor = true;
            this.cmdRemoveItem.Click += new System.EventHandler(this.cmdRemoveItem_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(12, 9);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(825, 263);
            this.dgvMain.TabIndex = 1;
            this.dgvMain.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellEndEdit);
            this.dgvMain.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellEnter);
            // 
            // dtpTranInDate
            // 
            this.dtpTranInDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTranInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranInDate.Location = new System.Drawing.Point(461, 28);
            this.dtpTranInDate.Name = "dtpTranInDate";
            this.dtpTranInDate.Size = new System.Drawing.Size(170, 20);
            this.dtpTranInDate.TabIndex = 49;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(386, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Tran Date";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(78, 357);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(441, 20);
            this.txtRemarks.TabIndex = 10;
            // 
            // txtTranID
            // 
            this.txtTranID.BackColor = System.Drawing.Color.White;
            this.txtTranID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTranID.Location = new System.Drawing.Point(93, 27);
            this.txtTranID.Name = "txtTranID";
            this.txtTranID.Size = new System.Drawing.Size(159, 20);
            this.txtTranID.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 360);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Remarks";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(28, 27);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(58, 13);
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
            this.pnlList.Location = new System.Drawing.Point(12, 12);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(987, 475);
            this.pnlList.TabIndex = 23;
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.Location = new System.Drawing.Point(388, 8);
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(121, 39);
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
            this.pnlControl.Location = new System.Drawing.Point(174, 398);
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
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(67, 6);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(121, 39);
            this.cmdOK.TabIndex = 17;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
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
            this.listView1.Size = new System.Drawing.Size(954, 326);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // frmBooksTransactionIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 511);
            this.Controls.Add(this.pnlMaster);
            this.Controls.Add(this.pnlList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBooksTransactionIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction In";
            this.Load += new System.EventHandler(this.frmBooksTransactionIn_Load);
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

    }
}