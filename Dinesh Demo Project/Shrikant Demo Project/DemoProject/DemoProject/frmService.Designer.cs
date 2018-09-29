namespace DemoProject
{
    partial class frmService
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmSave = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdRemoveService = new System.Windows.Forms.Button();
            this.cmdAddService = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.cmdSearchClient = new System.Windows.Forms.Button();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.txtServiceId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpServiceDate = new System.Windows.Forms.DateTimePicker();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancelDetails = new System.Windows.Forms.Button();
            this.cmdOKDetails = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.cmdTextSearch = new System.Windows.Forms.Button();
            this.txtSearchState = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.txtTotalAmount);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.cmdSearchClient);
            this.pnlMain.Controls.Add(this.txtClientName);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.cmdSearch);
            this.pnlMain.Controls.Add(this.txtServiceId);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.dtpServiceDate);
            this.pnlMain.Controls.Add(this.txtRemarks);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Location = new System.Drawing.Point(5, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(999, 512);
            this.pnlMain.TabIndex = 0;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Location = new System.Drawing.Point(751, 414);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(148, 20);
            this.txtTotalAmount.TabIndex = 39;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(661, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Total Amount";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmdCancel);
            this.panel3.Controls.Add(this.cmdExit);
            this.panel3.Controls.Add(this.cmSave);
            this.panel3.Controls.Add(this.cmdEdit);
            this.panel3.Controls.Add(this.cmdNew);
            this.panel3.Location = new System.Drawing.Point(655, 459);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 37);
            this.panel3.TabIndex = 37;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(191, 6);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(60, 25);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(252, 6);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(56, 25);
            this.cmdExit.TabIndex = 3;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // cmSave
            // 
            this.cmSave.Location = new System.Drawing.Point(130, 6);
            this.cmSave.Name = "cmSave";
            this.cmSave.Size = new System.Drawing.Size(56, 25);
            this.cmSave.TabIndex = 2;
            this.cmSave.Text = "Save";
            this.cmSave.UseVisualStyleBackColor = true;
            this.cmSave.Click += new System.EventHandler(this.cmSave_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(69, 6);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(56, 25);
            this.cmdEdit.TabIndex = 1;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(8, 6);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(56, 25);
            this.cmdNew.TabIndex = 0;
            this.cmdNew.Text = "Add";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdRemoveService);
            this.panel2.Controls.Add(this.cmdAddService);
            this.panel2.Controls.Add(this.dgvMain);
            this.panel2.Location = new System.Drawing.Point(21, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 241);
            this.panel2.TabIndex = 36;
            // 
            // cmdRemoveService
            // 
            this.cmdRemoveService.Location = new System.Drawing.Point(890, 134);
            this.cmdRemoveService.Name = "cmdRemoveService";
            this.cmdRemoveService.Size = new System.Drawing.Size(62, 47);
            this.cmdRemoveService.TabIndex = 25;
            this.cmdRemoveService.Text = "Remove Service";
            this.cmdRemoveService.UseVisualStyleBackColor = true;
            // 
            // cmdAddService
            // 
            this.cmdAddService.Location = new System.Drawing.Point(890, 45);
            this.cmdAddService.Name = "cmdAddService";
            this.cmdAddService.Size = new System.Drawing.Size(62, 47);
            this.cmdAddService.TabIndex = 24;
            this.cmdAddService.Text = "Add Service";
            this.cmdAddService.UseVisualStyleBackColor = true;
            // 
            // dgvMain
            // 
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(8, 9);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(869, 221);
            this.dgvMain.TabIndex = 1;
            // 
            // cmdSearchClient
            // 
            this.cmdSearchClient.Location = new System.Drawing.Point(372, 43);
            this.cmdSearchClient.Name = "cmdSearchClient";
            this.cmdSearchClient.Size = new System.Drawing.Size(34, 23);
            this.cmdSearchClient.TabIndex = 35;
            this.cmdSearchClient.Text = "...";
            this.cmdSearchClient.UseVisualStyleBackColor = true;
            this.cmdSearchClient.Click += new System.EventHandler(this.cmdSearchClient_Click);
            // 
            // txtClientName
            // 
            this.txtClientName.BackColor = System.Drawing.Color.White;
            this.txtClientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClientName.Location = new System.Drawing.Point(89, 43);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(277, 20);
            this.txtClientName.TabIndex = 34;
            this.txtClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Client Name";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(195, 3);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(34, 23);
            this.cmdSearch.TabIndex = 32;
            this.cmdSearch.Text = "...";
            this.cmdSearch.UseVisualStyleBackColor = true;
            // 
            // txtServiceId
            // 
            this.txtServiceId.BackColor = System.Drawing.Color.White;
            this.txtServiceId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceId.Location = new System.Drawing.Point(89, 6);
            this.txtServiceId.Name = "txtServiceId";
            this.txtServiceId.Size = new System.Drawing.Size(100, 20);
            this.txtServiceId.TabIndex = 31;
            this.txtServiceId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Service Id";
            // 
            // dtpServiceDate
            // 
            this.dtpServiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtpServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpServiceDate.Location = new System.Drawing.Point(327, 7);
            this.dtpServiceDate.Name = "dtpServiceDate";
            this.dtpServiceDate.Size = new System.Drawing.Size(122, 20);
            this.dtpServiceDate.TabIndex = 29;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(89, 84);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(898, 42);
            this.txtRemarks.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Remarks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Service Date";
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.panel1);
            this.pnlDetails.Controls.Add(this.dgvDetails);
            this.pnlDetails.Controls.Add(this.cmdTextSearch);
            this.pnlDetails.Controls.Add(this.txtSearchState);
            this.pnlDetails.Controls.Add(this.label5);
            this.pnlDetails.Location = new System.Drawing.Point(5, 5);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(999, 512);
            this.pnlDetails.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdCancelDetails);
            this.panel1.Controls.Add(this.cmdOKDetails);
            this.panel1.Location = new System.Drawing.Point(426, 463);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 37);
            this.panel1.TabIndex = 38;
            // 
            // cmdCancelDetails
            // 
            this.cmdCancelDetails.Location = new System.Drawing.Point(103, 5);
            this.cmdCancelDetails.Name = "cmdCancelDetails";
            this.cmdCancelDetails.Size = new System.Drawing.Size(60, 25);
            this.cmdCancelDetails.TabIndex = 4;
            this.cmdCancelDetails.Text = "Cancel";
            this.cmdCancelDetails.UseVisualStyleBackColor = true;
            // 
            // cmdOKDetails
            // 
            this.cmdOKDetails.Location = new System.Drawing.Point(20, 5);
            this.cmdOKDetails.Name = "cmdOKDetails";
            this.cmdOKDetails.Size = new System.Drawing.Size(56, 25);
            this.cmdOKDetails.TabIndex = 3;
            this.cmdOKDetails.Text = "OK";
            this.cmdOKDetails.UseVisualStyleBackColor = true;
            // 
            // dgvDetails
            // 
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(7, 47);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.Size = new System.Drawing.Size(981, 407);
            this.dgvDetails.TabIndex = 27;
            // 
            // cmdTextSearch
            // 
            this.cmdTextSearch.Location = new System.Drawing.Point(327, 12);
            this.cmdTextSearch.Name = "cmdTextSearch";
            this.cmdTextSearch.Size = new System.Drawing.Size(29, 25);
            this.cmdTextSearch.TabIndex = 26;
            this.cmdTextSearch.Text = "....";
            this.cmdTextSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearchState
            // 
            this.txtSearchState.BackColor = System.Drawing.Color.White;
            this.txtSearchState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchState.Location = new System.Drawing.Point(109, 12);
            this.txtSearchState.Name = "txtSearchState";
            this.txtSearchState.Size = new System.Drawing.Size(212, 20);
            this.txtSearchState.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Search Service";
            // 
            // frmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 523);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmService";
            this.Load += new System.EventHandler(this.frmService_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmSave;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdRemoveService;
        private System.Windows.Forms.Button cmdAddService;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button cmdSearchClient;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.TextBox txtServiceId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpServiceDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button cmdTextSearch;
        private System.Windows.Forms.TextBox txtSearchState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdCancelDetails;
        private System.Windows.Forms.Button cmdOKDetails;

    }
}