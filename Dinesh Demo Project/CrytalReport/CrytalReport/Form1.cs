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
using System.Net.Mail;

namespace CrytalReport
{
    public partial class Form1 : Form
    {
        ReportDocument ReportDoc;
        string FileName="C:\\Users\\dinesh\\Desktop\\Export_Report.pdf";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ReportDoc = new ReportDocument();
            ReportDoc.Load("G:\\Dinesh Demo Project\\CrytalReport\\CrytalReport\\Reports\\CrystalReport1.rpt");

            //ParameterFieldDefinitions prmdefs;
            //ParameterFieldDefinition prmdef;
            //ParameterValues prmVal = new ParameterValues();
            //ParameterDiscreteValue prmDisVal = new ParameterDiscreteValue();

            //prmDisVal.Value = textBox1.Text;
            //prmdefs = ReportDoc.DataDefinition.ParameterFields;
            //prmdef = prmdefs["currentdate"];
            //prmVal = prmdef.CurrentValues;

            //prmVal.Clear();
            //prmVal.Add(prmDisVal);
            //prmdef.ApplyCurrentValues(prmVal);

            TableLogOnInfos logInfoss = new TableLogOnInfos();
            TableLogOnInfo logonInfo = new TableLogOnInfo();

            ConnectionInfo conInfo = new ConnectionInfo();

            Tables tabls;

            //conInfo.ServerName = "DINESH-PC";
            //conInfo.DatabaseName = "TestDB";
            //conInfo.UserID = "sa";
            //conInfo.Password = "12345";

            conInfo.UserID = "Admin";
            conInfo.Password = "123456";


            tabls = ReportDoc.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table crTab in tabls)
            {
                logonInfo = crTab.LogOnInfo;
                logonInfo.ConnectionInfo = conInfo;
                crTab.ApplyLogOnInfo(logonInfo);

            }


            crystalReportViewer1.ReportSource = ReportDoc;
            crystalReportViewer1.Refresh();

          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // pdf or Doc file export
                ExportOptions crExportOptions;
                DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions pdfRftWordFormatOptions = new PdfRtfWordFormatOptions();
                crDiskFileDestinationOptions.DiskFileName = FileName;
                crExportOptions = ReportDoc.ExportOptions;
                {
                    crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    crExportOptions.ExportDestinationOptions = crDiskFileDestinationOptions;
                    crExportOptions.ExportFormatOptions = pdfRftWordFormatOptions;
                }
                ReportDoc.Export();

                MessageBox.Show("Report is Exported at " + crDiskFileDestinationOptions.DiskFileName);

                // Exel file export
                //ExportOptions crExportOptions;
                //DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();                
                //ExcelFormatOptions exelFormatOption = new ExcelFormatOptions();
                //crDiskFileDestinationOptions.DiskFileName = FileName;
                //crExportOptions = ReportDoc.ExportOptions;
                //{
                //    crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                //    crExportOptions.ExportFormatType = ExportFormatType.Excel;
                //    crExportOptions.ExportDestinationOptions = crDiskFileDestinationOptions;
                //    crExportOptions.ExportFormatOptions = exelFormatOption;
                //}
                //ReportDoc.Export();

                //MessageBox.Show("Report is Exported at " + crDiskFileDestinationOptions.DiskFileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            try
            {
                
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Credentials = new System.Net.NetworkCredential("rawatdinu", "Dinu9911499398.");
                smtpClient.Port=587;
                smtpClient.EnableSsl = true;


                MailMessage MailMsg = new MailMessage();
                MailMsg.From = new MailAddress("rawatdinu@gmail.com","Dinesh");
                MailMsg.To.Add("rawatdinu@yahoo.com");
                MailMsg.To.Add("rawatdinu@gmail.com");
                MailMsg.Subject = "Meeting Report";
                MailMsg.Body = "This is mail body";

                Attachment attach;
                attach = new Attachment(FileName);
                MailMsg.Attachments.Add(attach);

                smtpClient.Send(MailMsg);

                MessageBox.Show("Mail is send succefully");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            frm2.Activate();
        }
    }
}
