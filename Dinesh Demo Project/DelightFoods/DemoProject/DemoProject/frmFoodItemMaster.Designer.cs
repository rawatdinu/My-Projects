﻿namespace DemoProject
{
    partial class frmFoodItemMaster
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
            this.lvwFoodItem = new System.Windows.Forms.ListView();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.txtSearchState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwFoodItem
            // 
            this.lvwFoodItem.Location = new System.Drawing.Point(12, 38);
            this.lvwFoodItem.Name = "lvwFoodItem";
            this.lvwFoodItem.Size = new System.Drawing.Size(731, 446);
            this.lvwFoodItem.TabIndex = 29;
            this.lvwFoodItem.UseCompatibleStateImageBehavior = false;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(365, 7);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(29, 25);
            this.cmdSearch.TabIndex = 28;
            this.cmdSearch.Text = "....";
            this.cmdSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearchState
            // 
            this.txtSearchState.BackColor = System.Drawing.Color.White;
            this.txtSearchState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchState.Location = new System.Drawing.Point(109, 7);
            this.txtSearchState.Name = "txtSearchState";
            this.txtSearchState.Size = new System.Drawing.Size(250, 20);
            this.txtSearchState.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Search Food Item";
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.cmdCancel);
            this.pnlControl.Controls.Add(this.cmdOK);
            this.pnlControl.Controls.Add(this.cmdDelete);
            this.pnlControl.Controls.Add(this.cmdEdit);
            this.pnlControl.Controls.Add(this.cmdNew);
            this.pnlControl.Location = new System.Drawing.Point(411, 494);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(332, 37);
            this.pnlControl.TabIndex = 25;
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
            // frmFoodItemMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 543);
            this.Controls.Add(this.lvwFoodItem);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtSearchState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFoodItemMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Food Item Master";
            this.Load += new System.EventHandler(this.frmFoodItemMaster_Load);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwFoodItem;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.TextBox txtSearchState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdNew;
    }
}