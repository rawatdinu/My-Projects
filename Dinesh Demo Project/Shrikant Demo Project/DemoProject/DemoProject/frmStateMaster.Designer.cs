﻿namespace DemoProject
{
    partial class frmStateMaster
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
            this.cmdSearch = new System.Windows.Forms.Button();
            this.txtSearchState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.lvwState = new System.Windows.Forms.ListView();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(315, 22);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(29, 25);
            this.cmdSearch.TabIndex = 23;
            this.cmdSearch.Text = "....";
            this.cmdSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearchState
            // 
            this.txtSearchState.BackColor = System.Drawing.Color.White;
            this.txtSearchState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchState.Location = new System.Drawing.Point(97, 22);
            this.txtSearchState.Name = "txtSearchState";
            this.txtSearchState.Size = new System.Drawing.Size(212, 20);
            this.txtSearchState.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Search State";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmdCancel);
            this.panel3.Controls.Add(this.cmdOK);
            this.panel3.Controls.Add(this.cmdDelete);
            this.panel3.Controls.Add(this.cmdEdit);
            this.panel3.Controls.Add(this.cmdNew);
            this.panel3.Location = new System.Drawing.Point(12, 508);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 37);
            this.panel3.TabIndex = 20;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(252, 6);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(60, 25);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(191, 6);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(56, 25);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(130, 6);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(56, 25);
            this.cmdDelete.TabIndex = 2;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
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
            // lvwState
            // 
            this.lvwState.Location = new System.Drawing.Point(20, 53);
            this.lvwState.Name = "lvwState";
            this.lvwState.Size = new System.Drawing.Size(324, 446);
            this.lvwState.TabIndex = 24;
            this.lvwState.UseCompatibleStateImageBehavior = false;
            // 
            // frmStateMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 557);
            this.Controls.Add(this.lvwState);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtSearchState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Name = "frmStateMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStateMaster";
            this.Load += new System.EventHandler(this.frmStateMaster_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.TextBox txtSearchState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.ListView lvwState;
    }
}