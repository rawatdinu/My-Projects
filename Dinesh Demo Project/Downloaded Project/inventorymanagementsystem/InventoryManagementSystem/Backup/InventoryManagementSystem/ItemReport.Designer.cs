namespace InventoryManagementSystem
{
    partial class ItemReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.StockInHandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StockInHandDataSet = new InventoryManagementSystem.StockInHandDataSet();
            this.rvStockInHand = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StockInHandTableAdapter = new InventoryManagementSystem.StockInHandDataSetTableAdapters.StockInHandTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.StockInHandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockInHandDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // StockInHandBindingSource
            // 
            this.StockInHandBindingSource.DataMember = "StockInHand";
            this.StockInHandBindingSource.DataSource = this.StockInHandDataSet;
            // 
            // StockInHandDataSet
            // 
            this.StockInHandDataSet.DataSetName = "StockInHandDataSet";
            this.StockInHandDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvStockInHand
            // 
            this.rvStockInHand.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "StockInHandDataSet_StockInHand";
            reportDataSource1.Value = this.StockInHandBindingSource;
            this.rvStockInHand.LocalReport.DataSources.Add(reportDataSource1);
            this.rvStockInHand.LocalReport.ReportEmbeddedResource = "InventoryManagementSystem.StockInHandReport.rdlc";
            this.rvStockInHand.LocalReport.ReportPath = "";
            this.rvStockInHand.Location = new System.Drawing.Point(0, 0);
            this.rvStockInHand.Name = "rvStockInHand";
            this.rvStockInHand.Size = new System.Drawing.Size(698, 451);
            this.rvStockInHand.TabIndex = 0;
            // 
            // StockInHandTableAdapter
            // 
            this.StockInHandTableAdapter.ClearBeforeFill = true;
            // 
            // ItemReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 451);
            this.Controls.Add(this.rvStockInHand);
            this.Name = "ItemReport";
            this.Text = "ItemReport";
            this.Load += new System.EventHandler(this.ItemReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockInHandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockInHandDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvStockInHand;
        private System.Windows.Forms.BindingSource StockInHandBindingSource;
        private StockInHandDataSet StockInHandDataSet;
        private InventoryManagementSystem.StockInHandDataSetTableAdapters.StockInHandTableAdapter StockInHandTableAdapter;
        
    }
}