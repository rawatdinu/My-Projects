using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.Reporting;
using Microsoft.ReportingServices;
using ColdStorage.Data;
using ColdStorage;
using ColdStorage.BLL;



namespace ColdStorage
{
    public partial class frmReportViewer : Form
    {
        

        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, System.EventArgs e)
        {
            ReportDataSource rptDataSource;

            try
            {
                //Original tested
                string reportPath = @"E:\Dinesh Demo Project\ColdStorage\ColdStorage\Reports\rptTransactionIn.rdlc";
                reportViewer1.LocalReport.ReportPath = reportPath;
                reportViewer1.LocalReport.DataSources.Clear();

                TransactionInDataSet ds = new TransactionInDataSet();
                //ListDataSet.BooksMasterDataSetTableAdapters.BooksMasterTableAdapter da = new ListDataSet.BooksMasterDataSetTableAdapters.BooksMasterTableAdapter();
                

                TransactionInDetails obj = new TransactionInDetails();
                DataTable datatable = obj.GetReportTransactionIn("IN000001");

               // DataTable dt = ds.Tables["dtTransactionIn"];

                ds.Tables["dtTransactionIn"].Merge(datatable);
                
                
                string str;




                rptDataSource = new ReportDataSource("DataSet1", ds.Tables["dtTransactionIn"]);



                reportViewer1.LocalReport.DataSources.Add(rptDataSource);
                reportViewer1.RefreshReport();
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

      
    }
}
