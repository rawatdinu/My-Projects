using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using VillageMeeting.AppCode;

namespace VillageMeeting
{
    public partial class MainForm : Form
    {
        public frmShareManagement ShareManagement;
        public frmCapitalLoanSetting CapitalLoanSetting;
        public frmMeetingFile MeetingFile;

        public MainForm()
        {
            InitializeComponent();

            SetDefaultInterface();
            

           // client = Controls.OfType<MdiClient>().First();
        //This will check whenever client gets focused and there aren't any
        //child forms opened, Send the client to back so that the other controls can be shown back.
            //client.GotFocus += (s, e) =>
            //{
            //    if (!MdiChildren.Any(x => x.Visible))
            //    {
            //        client.SendToBack();
            //    }

            //};
        }

        private void SetDefaultInterface()
        {
            string imageFile = Application.StartupPath + @"\Images\64X64\login1.jpg";
            string iconFile = Application.StartupPath + @"\Icon\128\Meeting.ico";
           
            if (File.Exists(iconFile))
            {
                System.Drawing.Icon ico = new System.Drawing.Icon(iconFile);
                this.Icon = ico;
            }

        }

        private void SetControlLocation()
        {
            SetWindowSize();
        }

    
        private void MainForm_Load(object sender, EventArgs e)
        {
            //if (GlobalFunction.glbUserType == GlobalFunction.SuperUser)
            //{
            //    AddAdminTab();
            //}

            SetControlLocation();
                       
        }

        private void SetWindowSize()
        {

           // tabControl1.Size = GlobalFunction.GetWindowSize();    

            //this.Size = this.MinimumSize;
            //tabControl1.Width = this.Width - 10;
            //tabControl1.Height = this.Height - 80;
            
        }

        public void ShowForm(string formName)
        {

            try
            {
                switch (formName)
                {
                    case "ShareManagement":
                        if (ShareManagement == null)
                        {
                            ShareManagement = new frmShareManagement();
                            ShareManagement.MdiParent = this;
                            ShareManagement.Show();
                            ShareManagement.BringToFront();
                        }
                        else if (ShareManagement.IsDisposed == true)
                        {
                            ShareManagement = new frmShareManagement();
                            ShareManagement.MdiParent = this;
                            ShareManagement.Show();
                            ShareManagement.BringToFront();
                        }
                        else
                        {
                            ShareManagement.Activate();
                            ShareManagement.Show();
                            ShareManagement.BringToFront();
                        }
                        break;
                    case "CapitalLoanSetting":
                        if (CapitalLoanSetting == null)
                        {
                            CapitalLoanSetting = new frmCapitalLoanSetting();
                            CapitalLoanSetting.MdiParent = this;
                            CapitalLoanSetting.Show();
                            CapitalLoanSetting.BringToFront();
                        }
                        else if (CapitalLoanSetting.IsDisposed == true)
                        {
                            CapitalLoanSetting = new frmCapitalLoanSetting();
                            CapitalLoanSetting.MdiParent = this;
                            CapitalLoanSetting.Show();
                            CapitalLoanSetting.BringToFront();
                        }
                        else
                        {
                            CapitalLoanSetting.Activate();
                            CapitalLoanSetting.Show();
                            CapitalLoanSetting.BringToFront();
                        }
                        break;
                    case "MeetingFile":
                        if (MeetingFile == null)
                        {
                            MeetingFile = new frmMeetingFile();
                            MeetingFile.MdiParent = this;
                            MeetingFile.Size = this.Size;
                            MeetingFile.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                            MeetingFile.Dock = DockStyle.Fill;
                            MeetingFile.Show();
                            MeetingFile.BringToFront();
                        }
                        else if (MeetingFile.IsDisposed == true)
                        {
                            MeetingFile = new frmMeetingFile();
                            MeetingFile.MdiParent = this;
                            MeetingFile.Size = this.Size;
                            MeetingFile.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                            MeetingFile.Dock = DockStyle.Fill;
                            MeetingFile.Show();
                            MeetingFile.BringToFront();
                        }
                        else
                        {
                            MeetingFile.Activate();
                            //MeetingFile.Show();
                            //MeetingFile.BringToFront();
                            MeetingFile.MdiParent = this;
                            MeetingFile.Size = this.Size;
                            MeetingFile.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                            MeetingFile.Dock = DockStyle.Fill;
                            MeetingFile.Show();
                            MeetingFile.BringToFront();
                        }

                        break;


                    default://Defautl meeting file at home
                        if (MeetingFile == null)
                        {
                            MeetingFile = new frmMeetingFile();
                            MeetingFile.MdiParent = this;
                            MeetingFile.Show();
                            MeetingFile.BringToFront();
                        }
                        else if (MeetingFile.IsDisposed == true)
                        {
                            MeetingFile = new frmMeetingFile();
                            MeetingFile.MdiParent = this;
                            MeetingFile.Show();
                            MeetingFile.BringToFront();
                        }
                        else
                        {
                            MeetingFile.Activate();
                            MeetingFile.Show();
                            MeetingFile.BringToFront();
                        }

                        break;

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }
        
        }

        private void capitalLoanSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {   
         // Check is meeting file is opened or not
            if (MeetingFile == null)
            {
                ShowForm("CapitalLoanSetting");
            }
            else
            {
                if (MeetingFile.IsDisposed == false)
                {
                    //Show messege for save meeting file
                    MeetingFile.Close();
                    ShowForm("CapitalLoanSetting");
                }
                else
                {
                    ShowForm("CapitalLoanSetting");
                }
            }            
        }
        private void shareManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check is meeting file is opened or not
            if (MeetingFile == null)
            {
                ShowForm("ShareManagement");
            }
            else
            {
                if (MeetingFile.IsDisposed == false)
                {
                    //Show messege for save meeting file
                    MeetingFile.Close();
                    ShowForm("ShareManagement");
                }
                else
                {
                    ShowForm("ShareManagement");
                }
            }
            
        }      
        private void meetingFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("MeetingFile");
        }

            
    }
}
