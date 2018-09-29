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
using CrystalReportDS.Data;


namespace CrystalReportDS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet1 ds = new DataSet1();
            DataTable t = ds.Tables.Add("DataTable1");
            t.Columns.Add("ID");
            t.Columns.Add("Name");

            DataRow r;
            int i = 0;
            for (i = 0; i <= 9; i++)
            {
                r = t.NewRow();
                r["ID"] = i.ToString();
                r["Name"] = "Dinesh Chandra Singh" + i;
                t.Rows.Add(r);
            }

            //ds.WriteXml(@"G:\Dinesh Demo Project\CrystalReportDS\CrystalReportDS\Data\DataSet1.xsd");

            CrystalReport1 objRpt = new CrystalReport1();
            objRpt.SetDataSource(ds.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh(); 
        }
    }
}
