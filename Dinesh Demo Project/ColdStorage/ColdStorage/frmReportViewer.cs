using System;
using System.Data;
using System.IO;
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

        public string ReportName = "";
        public string ReportPath = System.Configuration.ConfigurationManager.AppSettings["ReportPath"];
        public string PDFPath = Application.StartupPath + @"\Reports\PDF\";

        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, System.EventArgs e)
        {




        }

        public void Generate_rptTransactionIn(string transactionInID)
        {
            try
            {

                //Original tested
                ReportDataSource rptDataSource;
                string reportPath = ReportPath + "rptTransactionIn.rdlc";
                reportViewer1.LocalReport.ReportPath = reportPath;
                reportViewer1.LocalReport.DataSources.Clear();

                TransactionInDataSet ds = new TransactionInDataSet();               


                TransactionInDetails obj = new TransactionInDetails();
                DataTable dt = obj.GetReportTransactionIn(transactionInID);


                // DataTable dt = ds.Tables["dtTransactionIn"];

                ds.Tables["dtTransactionIn"].Merge(dt);

                
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


        public void Generate_rptTransactionOut(string transactionOutID)
        {
            try
            {

                //Original tested
                ReportDataSource rptDataSource;
                string reportPath = ReportPath + "rptTransactionOut.rdlc";
                reportViewer1.LocalReport.ReportPath = reportPath;
                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSet ds = new ReportDataSet();

                TransactionOutDetails obj = new TransactionOutDetails();
                DataTable datatable = obj.GetReportTransactionOut(transactionOutID);

                // DataTable dt = ds.Tables["dtTransactionIn"];

                ds.Tables["dtTransactionOut"].Merge(datatable);


                rptDataSource = new ReportDataSource("DataSet1", ds.Tables["dtTransactionOut"]);


                reportViewer1.LocalReport.DataSources.Add(rptDataSource);
                reportViewer1.RefreshReport();
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdExportPDF_Click(object sender, EventArgs e)
        {
            string fileName = PDFPath + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".pdf";

            SavePDF(reportViewer1, fileName);
            OpenPDF(fileName);
        }

        private void SavePDF(ReportViewer viewer, string savePath)
        {
            byte[] Bytes = viewer.LocalReport.Render(format: "PDF", deviceInfo: "");

            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }
        }
        private void OpenPDF(string FileName)
        {
            System.Diagnostics.Process.Start(FileName);
        }
    }
}
