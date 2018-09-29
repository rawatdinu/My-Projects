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

       

        //Delight Food Demo
        public frmFoodCategoryMaster frmFoodCategoryMaster;
        public frmFoodItemMaster frmFoodItemMaster;
        public frmSale frmSale;
        public frmBackup frmBackup;

        public frmItemWiseSale frmItemWiseSale;
                
       

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

            ShowForm("");
                       
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
                    

                    case "frmFoodCategoryMaster":
                        if (frmFoodCategoryMaster == null)
                        {
                            frmFoodCategoryMaster = new frmFoodCategoryMaster();
                            frmFoodCategoryMaster.MdiParent = this;
                            //frmFoodCategoryMaster.IsLookup = 0;
                            frmFoodCategoryMaster.Show();
                            frmFoodCategoryMaster.BringToFront();
                        }
                        else if (frmFoodCategoryMaster.IsDisposed == true)
                        {
                            frmFoodCategoryMaster = new frmFoodCategoryMaster();
                            frmFoodCategoryMaster.MdiParent = this;
                            //frmFoodCategoryMaster.IsLookup = 0;
                            frmFoodCategoryMaster.Show();
                            frmFoodCategoryMaster.BringToFront();
                        }
                        else
                        {
                            frmFoodCategoryMaster.Activate();
                            frmFoodCategoryMaster.Show();
                            frmFoodCategoryMaster.BringToFront();
                        }
                        break;


                    case "frmFoodItemMaster":
                        if (frmFoodItemMaster == null)
                        {
                            frmFoodItemMaster = new frmFoodItemMaster();
                            frmFoodItemMaster.MdiParent = this;
                            //frmFoodItemMaster.IsLookup = 0;
                            frmFoodItemMaster.Show();
                            frmFoodItemMaster.BringToFront();
                        }
                        else if (frmFoodItemMaster.IsDisposed == true)
                        {
                            frmFoodItemMaster = new frmFoodItemMaster();
                            frmFoodItemMaster.MdiParent = this;
                            //frmFoodItemMaster.IsLookup = 0;
                            frmFoodItemMaster.Show();
                            frmFoodItemMaster.BringToFront();
                        }
                        else
                        {
                            frmFoodItemMaster.Activate();
                            frmFoodItemMaster.Show();
                            frmFoodItemMaster.BringToFront();
                        }
                        break;

                    case "frmSale":
                        if (frmSale == null)
                        {
                            frmSale = new frmSale();
                            frmSale.MdiParent = this;
                            //frmSale.IsLookup = 0;
                            frmSale.Show();
                            frmSale.BringToFront();
                        }
                        else if (frmSale.IsDisposed == true)
                        {
                            frmSale = new frmSale();
                            frmSale.MdiParent = this;
                            //frmSale.IsLookup = 0;
                            frmSale.Show();
                            frmSale.BringToFront();
                        }
                        else
                        {
                            frmSale.Activate();
                            frmSale.Show();
                            frmSale.BringToFront();
                        }
                        break;


                    case "frmBackup":
                        if (frmBackup == null)
                        {
                            frmBackup = new frmBackup();
                            frmBackup.MdiParent = this;
                            //frmSale.IsLookup = 0;
                            frmBackup.Show();
                            frmBackup.BringToFront();
                        }
                        else if (frmBackup.IsDisposed == true)
                        {
                            frmBackup = new frmBackup();
                            frmBackup.MdiParent = this;
                            //frmSale.IsLookup = 0;
                            frmBackup.Show();
                            frmBackup.BringToFront();
                        }
                        else
                        {
                            frmBackup.Activate();
                            frmBackup.Show();
                            frmBackup.BringToFront();
                        }
                        break;

                    case "frmItemWiseSale":
                        if (frmItemWiseSale == null)
                        {
                            frmItemWiseSale = new frmItemWiseSale();
                            frmItemWiseSale.MdiParent = this;
                            //frmSale.IsLookup = 0;
                            frmItemWiseSale.Show();
                            frmItemWiseSale.BringToFront();
                        }
                        else if (frmItemWiseSale.IsDisposed == true)
                        {
                            frmItemWiseSale = new frmItemWiseSale();
                            frmItemWiseSale.MdiParent = this;
                            //frmSale.IsLookup = 0;
                            frmItemWiseSale.Show();
                            frmItemWiseSale.BringToFront();
                        }
                        else
                        {
                            frmItemWiseSale.Activate();
                            frmItemWiseSale.Show();
                            frmItemWiseSale.BringToFront();
                        }
                        break;
                    


                    default://Defautl Sale
                         if (frmSale == null)
                        {
                            frmSale = new frmSale();
                            frmSale.MdiParent = this;
                            //frmSale.IsLookup = 0;
                            frmSale.Show();
                            frmSale.BringToFront();
                        }
                        else if (frmSale.IsDisposed == true)
                        {
                            frmSale = new frmSale();
                            frmSale.MdiParent = this;
                            //frmSale.IsLookup = 0;
                            frmSale.Show();
                            frmSale.BringToFront();
                        }
                        else
                        {
                            frmSale.Activate();
                            frmSale.Show();
                            frmSale.BringToFront();
                        }
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

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmService");
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmFoodCategoryMaster");
        }

        private void foodItemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmFoodItemMaster");
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmSale");
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmBackup");
        }

        private void itemWiseSaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmItemWiseSale");
        }



     

       

            
    }
}
