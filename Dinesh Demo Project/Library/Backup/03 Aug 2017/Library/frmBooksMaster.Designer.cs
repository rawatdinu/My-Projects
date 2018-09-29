namespace Library
{
    partial class frmBooksMaster
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
            this.cmdClear = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtEditionYear = new System.Windows.Forms.TextBox();
            this.txtPublication = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtEditionNo = new System.Windows.Forms.TextBox();
            this.txtAuthorName = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdAddNewInList = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pnlMaster.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMaster
            // 
            this.pnlMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMaster.Controls.Add(this.cmdClear);
            this.pnlMaster.Controls.Add(this.txtPrice);
            this.pnlMaster.Controls.Add(this.label1);
            this.pnlMaster.Controls.Add(this.cmdSave);
            this.pnlMaster.Controls.Add(this.cmdNew);
            this.pnlMaster.Controls.Add(this.txtRemarks);
            this.pnlMaster.Controls.Add(this.txtEditionYear);
            this.pnlMaster.Controls.Add(this.txtPublication);
            this.pnlMaster.Controls.Add(this.txtSubject);
            this.pnlMaster.Controls.Add(this.txtISBN);
            this.pnlMaster.Controls.Add(this.txtEditionNo);
            this.pnlMaster.Controls.Add(this.txtAuthorName);
            this.pnlMaster.Controls.Add(this.txtTitle);
            this.pnlMaster.Controls.Add(this.txtBookId);
            this.pnlMaster.Controls.Add(this.label9);
            this.pnlMaster.Controls.Add(this.label8);
            this.pnlMaster.Controls.Add(this.label7);
            this.pnlMaster.Controls.Add(this.label6);
            this.pnlMaster.Controls.Add(this.label5);
            this.pnlMaster.Controls.Add(this.label4);
            this.pnlMaster.Controls.Add(this.label3);
            this.pnlMaster.Controls.Add(this.label2);
            this.pnlMaster.Controls.Add(this.lblID);
            this.pnlMaster.Location = new System.Drawing.Point(12, 12);
            this.pnlMaster.Name = "pnlMaster";
            this.pnlMaster.Size = new System.Drawing.Size(807, 352);
            this.pnlMaster.TabIndex = 22;
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(235, 219);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(121, 39);
            this.cmdClear.TabIndex = 13;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Location = new System.Drawing.Point(93, 131);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(159, 20);
            this.txtPrice.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Price";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(382, 219);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(121, 39);
            this.cmdSave.TabIndex = 11;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(89, 219);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(121, 39);
            this.cmdNew.TabIndex = 12;
            this.cmdNew.Text = "Add New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(93, 172);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(441, 20);
            this.txtRemarks.TabIndex = 10;
            // 
            // txtEditionYear
            // 
            this.txtEditionYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEditionYear.Location = new System.Drawing.Point(364, 105);
            this.txtEditionYear.Name = "txtEditionYear";
            this.txtEditionYear.Size = new System.Drawing.Size(170, 20);
            this.txtEditionYear.TabIndex = 8;
            // 
            // txtPublication
            // 
            this.txtPublication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPublication.Location = new System.Drawing.Point(364, 79);
            this.txtPublication.Name = "txtPublication";
            this.txtPublication.Size = new System.Drawing.Size(170, 20);
            this.txtPublication.TabIndex = 6;
            // 
            // txtSubject
            // 
            this.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubject.Location = new System.Drawing.Point(364, 53);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(170, 20);
            this.txtSubject.TabIndex = 4;
            // 
            // txtISBN
            // 
            this.txtISBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtISBN.Location = new System.Drawing.Point(364, 27);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(170, 20);
            this.txtISBN.TabIndex = 2;
            // 
            // txtEditionNo
            // 
            this.txtEditionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEditionNo.Location = new System.Drawing.Point(93, 105);
            this.txtEditionNo.Name = "txtEditionNo";
            this.txtEditionNo.Size = new System.Drawing.Size(159, 20);
            this.txtEditionNo.TabIndex = 7;
            // 
            // txtAuthorName
            // 
            this.txtAuthorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthorName.Location = new System.Drawing.Point(93, 79);
            this.txtAuthorName.Name = "txtAuthorName";
            this.txtAuthorName.Size = new System.Drawing.Size(159, 20);
            this.txtAuthorName.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.Location = new System.Drawing.Point(93, 53);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(159, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // txtBookId
            // 
            this.txtBookId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookId.Location = new System.Drawing.Point(93, 27);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.Size = new System.Drawing.Size(159, 20);
            this.txtBookId.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Remarks";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(292, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Edition Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Publication";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Subject";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "ISBN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Edition No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Author";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Title";
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
            this.pnlList.Controls.Add(this.cmdEdit);
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
            this.pnlControl.Controls.Add(this.cmdCancel);
            this.pnlControl.Controls.Add(this.cmdOK);
            this.pnlControl.Location = new System.Drawing.Point(184, 287);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(402, 52);
            this.pnlControl.TabIndex = 17;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(213, 6);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(121, 39);
            this.cmdCancel.TabIndex = 18;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
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
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(398, 8);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(121, 39);
            this.cmdEdit.TabIndex = 16;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
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
            // frmBooksMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 376);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlMaster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBooksMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Books Master";
            this.Load += new System.EventHandler(this.frmBooksMaster_Load);
            this.pnlMaster.ResumeLayout(false);
            this.pnlMaster.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMaster;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtEditionYear;
        private System.Windows.Forms.TextBox txtPublication;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtEditionNo;
        private System.Windows.Forms.TextBox txtAuthorName;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdAddNewInList;
        private System.Windows.Forms.ListView listView1;

    }
}