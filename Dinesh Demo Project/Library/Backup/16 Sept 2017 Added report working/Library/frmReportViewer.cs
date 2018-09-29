using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.Reporting;
using Microsoft.ReportingServices;
using Library.ListDataSet;
using Library;
using Library.BLL;

namespace Library
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            ReportDataSource rptDataSource;

            try
            {
                //Original tested
                string reportPath = @"E:\Dinesh Demo Project\Library\Library\Reports\Report1.rdlc";
                reportViewer1.LocalReport.ReportPath = reportPath;
                reportViewer1.LocalReport.DataSources.Clear();

                BooksMasterDataSet ds = new BooksMasterDataSet();
                ListDataSet.BooksMasterDataSetTableAdapters.BooksMasterTableAdapter da = new ListDataSet.BooksMasterDataSetTableAdapters.BooksMasterTableAdapter();

                string str;
                str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\LibraryProject.accdb;Jet OLEDB:Database Password=123456";
                da.Connection.ConnectionString = str;

                da.Fill(ds.BooksMaster);


                rptDataSource = new ReportDataSource("BooksMasterDataSet", ds.Tables["BooksMaster"]);

               

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
