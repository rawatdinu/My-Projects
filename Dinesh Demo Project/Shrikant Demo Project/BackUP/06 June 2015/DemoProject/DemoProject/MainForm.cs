using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DemoProject.AppCode;

namespace DemoProject
{
    public partial class MainForm : Form
    {
        //public frmShareManagement ShareManagement;
        //public frmCapitalLoanSetting CapitalLoanSetting;
        //public frmMeetingFile MeetingFile;

        public frmClientMaster frmClientMaster;
        public frmStateMaster frmStateMaster;
        public frmCityMaster frmCityMaster;
        public frmIndustryTypeMaster frmIndustryTypeMaster;
       

        public MainForm()
        {
            InitializeComponent();

            SetDefaultInterface();

            label1.Text = "Welcome " + GlobalFunction.glbUserName;
                        

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
                    case "frmClientMaster":
                        if (frmClientMaster == null)
                        {
                            frmClientMaster = new frmClientMaster();
                            //frmClientMaster.MdiParent = this;
                            frmClientMaster.Show();
                            frmClientMaster.BringToFront();
                        }
                        else if (frmClientMaster.IsDisposed == true)
                        {
                            frmClientMaster = new frmClientMaster();
                            //frmClientMaster.MdiParent = this;
                            frmClientMaster.Show();
                            frmClientMaster.BringToFront();
                        }
                        else
                        {
                            frmClientMaster.Activate();
                            frmClientMaster.Show();
                            frmClientMaster.BringToFront();
                        }
                        break;

                    case "frmStateMaster":
                        if (frmStateMaster == null)
                        {
                            frmStateMaster = new frmStateMaster();
                            //frmClientMaster.MdiParent = this;
                            frmStateMaster.IsLookup = 0;
                            frmStateMaster.Show();
                            frmStateMaster.BringToFront();
                        }
                        else if (frmStateMaster.IsDisposed == true)
                        {
                            frmStateMaster = new frmStateMaster();
                            //frmClientMaster.MdiParent = this;
                            frmStateMaster.IsLookup = 0;
                            frmStateMaster.Show();
                            frmStateMaster.BringToFront();
                        }
                        else
                        {
                            frmStateMaster.Activate();
                            frmStateMaster.Show();
                            frmStateMaster.BringToFront();
                        }
                        break;

                    case "frmCityMaster":
                        if (frmCityMaster == null)
                        {
                            frmCityMaster = new frmCityMaster();
                            //frmClientMaster.MdiParent = this;
                            frmCityMaster.IsLookup = 0;
                            frmCityMaster.Show();
                            frmCityMaster.BringToFront();
                        }
                        else if (frmCityMaster.IsDisposed == true)
                        {
                            frmCityMaster = new frmCityMaster();
                            //frmClientMaster.MdiParent = this;
                            frmCityMaster.IsLookup = 0;
                            frmCityMaster.Show();
                            frmCityMaster.BringToFront();
                        }
                        else
                        {
                            frmCityMaster.Activate();
                            frmCityMaster.Show();
                            frmCityMaster.BringToFront();
                        }
                        break;

                    case "frmIndustryTypeMaster":
                        if (frmIndustryTypeMaster == null)
                        {
                            frmIndustryTypeMaster = new frmIndustryTypeMaster();
                            //frmClientMaster.MdiParent = this;
                            frmIndustryTypeMaster.IsLookup = 0;
                            frmIndustryTypeMaster.Show();
                            frmIndustryTypeMaster.BringToFront();
                        }
                        else if (frmIndustryTypeMaster.IsDisposed == true)
                        {
                            frmIndustryTypeMaster = new frmIndustryTypeMaster();
                            //frmClientMaster.MdiParent = this;
                            frmIndustryTypeMaster.IsLookup = 0;
                            frmIndustryTypeMaster.Show();
                            frmIndustryTypeMaster.BringToFront();
                        }
                        else
                        {
                            frmIndustryTypeMaster.Activate();
                            frmIndustryTypeMaster.Show();
                            frmIndustryTypeMaster.BringToFront();
                        }
                        break;
                    //case "CapitalLoanSetting":
                    //    if (CapitalLoanSetting == null)
                    //    {
                    //        CapitalLoanSetting = new frmCapitalLoanSetting();
                    //        CapitalLoanSetting.MdiParent = this;
                    //        CapitalLoanSetting.Show();
                    //        CapitalLoanSetting.BringToFront();
                    //    }
                    //    else if (CapitalLoanSetting.IsDisposed == true)
                    //    {
                    //        CapitalLoanSetting = new frmCapitalLoanSetting();
                    //        CapitalLoanSetting.MdiParent = this;
                    //        CapitalLoanSetting.Show();
                    //        CapitalLoanSetting.BringToFront();
                    //    }
                    //    else
                    //    {
                    //        CapitalLoanSetting.Activate();
                    //        CapitalLoanSetting.Show();
                    //        CapitalLoanSetting.BringToFront();
                    //    }
                    //    break;
                    //case "MeetingFile":
                    //    if (MeetingFile == null)
                    //    {
                    //        MeetingFile = new frmMeetingFile();
                    //        MeetingFile.MdiParent = this;
                    //        MeetingFile.Size = this.Size;
                    //        MeetingFile.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    //        MeetingFile.Dock = DockStyle.Fill;
                    //        MeetingFile.Show();
                    //        MeetingFile.BringToFront();
                    //    }
                    //    else if (MeetingFile.IsDisposed == true)
                    //    {
                    //        MeetingFile = new frmMeetingFile();
                    //        MeetingFile.MdiParent = this;
                    //        MeetingFile.Size = this.Size;
                    //        MeetingFile.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    //        MeetingFile.Dock = DockStyle.Fill;
                    //        MeetingFile.Show();
                    //        MeetingFile.BringToFront();
                    //    }
                    //    else
                    //    {
                    //        MeetingFile.Activate();
                    //        //MeetingFile.Show();
                    //        //MeetingFile.BringToFront();
                    //        MeetingFile.MdiParent = this;
                    //        MeetingFile.Size = this.Size;
                    //        MeetingFile.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    //        MeetingFile.Dock = DockStyle.Fill;
                    //        MeetingFile.Show();
                    //        MeetingFile.BringToFront();
                    //    }

                    //    break;


                    default://Defautl meeting file at home
                        //if (MeetingFile == null)
                        //{
                        //    MeetingFile = new frmMeetingFile();
                        //    MeetingFile.MdiParent = this;
                        //    MeetingFile.Show();
                        //    MeetingFile.BringToFront();
                        //}
                        //else if (MeetingFile.IsDisposed == true)
                        //{
                        //    MeetingFile = new frmMeetingFile();
                        //    MeetingFile.MdiParent = this;
                        //    MeetingFile.Show();
                        //    MeetingFile.BringToFront();
                        //}
                        //else
                        //{
                        //    MeetingFile.Activate();
                        //    MeetingFile.Show();
                        //    MeetingFile.BringToFront();
                        //}

                        break;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //private void capitalLoanSettingToolStripMenuItem_Click(object sender, EventArgs e)
        //{   
        // // Check is meeting file is opened or not
        //    if (MeetingFile == null)
        //    {
        //        ShowForm("CapitalLoanSetting");
        //    }
        //    else
        //    {
        //        if (MeetingFile.IsDisposed == false)
        //        {
        //            //Show messege for save meeting file
        //            MeetingFile.Close();
        //            ShowForm("CapitalLoanSetting");
        //        }
        //        else
        //        {
        //            ShowForm("CapitalLoanSetting");
        //        }
        //    }            
        //}
        //private void shareManagerToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    // Check is meeting file is opened or not
        //    if (MeetingFile == null)
        //    {
        //        ShowForm("ShareManagement");
        //    }
        //    else
        //    {
        //        if (MeetingFile.IsDisposed == false)
        //        {
        //            //Show messege for save meeting file
        //            MeetingFile.Close();
        //            ShowForm("ShareManagement");
        //        }
        //        else
        //        {
        //            ShowForm("ShareManagement");
        //        }
        //    }
            
        //}      
        //private void meetingFileToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShowForm("MeetingFile");
        //}

        private void clientMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmClientMaster");
        }

        private void stateMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmStateMaster");
        }

        private void cityMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmCityMaster");
        }

        private void industryMaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmIndustryTypeMaster");
        }

       

            
    }
}
