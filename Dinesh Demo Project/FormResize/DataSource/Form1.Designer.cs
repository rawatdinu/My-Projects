namespace DataSource
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvGrid2 = new System.Windows.Forms.DataGridView();
            this.txtModel2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.airplaneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelLeftKgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airplaneBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrid
            // 
            this.dgvGrid.AutoGenerateColumns = false;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.fuelLeftKgDataGridViewTextBoxColumn});
            this.dgvGrid.DataSource = this.airplaneBindingSource;
            this.dgvGrid.Location = new System.Drawing.Point(13, 52);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.Size = new System.Drawing.Size(352, 254);
            this.dgvGrid.TabIndex = 0;
            // 
            // txtModel
            // 
            this.txtModel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.airplaneBindingSource, "Model", true));
            this.txtModel.Location = new System.Drawing.Point(23, 16);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(186, 20);
            this.txtModel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvGrid);
            this.panel1.Controls.Add(this.txtModel);
            this.panel1.Location = new System.Drawing.Point(17, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 323);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvGrid2);
            this.panel2.Controls.Add(this.txtModel2);
            this.panel2.Location = new System.Drawing.Point(459, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 323);
            this.panel2.TabIndex = 3;
            // 
            // dgvGrid2
            // 
            this.dgvGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid2.Location = new System.Drawing.Point(13, 52);
            this.dgvGrid2.Name = "dgvGrid2";
            this.dgvGrid2.Size = new System.Drawing.Size(352, 254);
            this.dgvGrid2.TabIndex = 0;
            // 
            // txtModel2
            // 
            this.txtModel2.Location = new System.Drawing.Point(179, 16);
            this.txtModel2.Name = "txtModel2";
            this.txtModel2.Size = new System.Drawing.Size(186, 20);
            this.txtModel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "At Designer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(482, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Using Backend Code";
            // 
            // airplaneBindingSource
            // 
            this.airplaneBindingSource.DataSource = typeof(DataSource.Airplane);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            // 
            // fuelLeftKgDataGridViewTextBoxColumn
            // 
            this.fuelLeftKgDataGridViewTextBoxColumn.DataPropertyName = "FuelLeftKg";
            this.fuelLeftKgDataGridViewTextBoxColumn.HeaderText = "FuelLeftKg";
            this.fuelLeftKgDataGridViewTextBoxColumn.Name = "fuelLeftKgDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 428);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airplaneBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelLeftKgDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource airplaneBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvGrid2;
        private System.Windows.Forms.TextBox txtModel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

