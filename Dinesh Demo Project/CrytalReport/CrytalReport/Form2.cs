using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrytalReport.Reports;


namespace CrytalReport
{
    public partial class Form2 : Form
    {
        ReportDocument ReportDoc;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable t = ds.Tables.Add("DataTable1");
            t.Columns.Add("Id");
            t.Columns.Add("Name");

            DataRow r;
            int i = 0;
            for (i = 0; i <= 9; i++)
            {
                r = t.NewRow();
                r["Id"] = Convert.ToString(i);
                r["Name"] = "Item" + i;
                t.Rows.Add(r);
            }

            CrystalReport2 objRpt = new CrystalReport2();
            objRpt.Load();
            objRpt.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh(); 
                     
        }

      


    }
}
