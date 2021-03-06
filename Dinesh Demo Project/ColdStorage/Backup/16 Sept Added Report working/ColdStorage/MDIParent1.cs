﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColdStorage
{
    public partial class MDIParent1 : Form
    {
        public frmItemMaster frmItemMaster;
        public frmTransactionIn frmTransactionIn;
        public frmTransactionOut frmTransactionOut;


        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        public void ShowForm(string formName)
        {

            try
            {
                switch (formName)
                {
            //        case "UserRegistration":
            //            if (frmUserRegistration == null)
            //            {
            //                frmUserRegistration = new frmUserRegistration();
            //                frmUserRegistration.MdiParent = this;
            //                frmUserRegistration.Show();
            //                frmUserRegistration.BringToFront();
            //            }
            //            else if (frmUserRegistration.IsDisposed == true)
            //            {
            //                frmUserRegistration = new frmUserRegistration();
            //                frmUserRegistration.MdiParent = this;
            //                frmUserRegistration.Show();
            //                frmUserRegistration.BringToFront();
            //            }
            //            else
            //            {
            //                frmUserRegistration.Activate();
            //                frmUserRegistration.Show();
            //                frmUserRegistration.BringToFront();
            //            }
            //            break;


                    case "frmItemMaster":
                        if (frmItemMaster == null)
                        {
                            frmItemMaster = new frmItemMaster();
                            frmItemMaster.MdiParent = this;
                            frmItemMaster.Show();
                            frmItemMaster.BringToFront();
                        }
                        else if (frmItemMaster.IsDisposed == true)
                        {
                            frmItemMaster = new frmItemMaster();
                            frmItemMaster.MdiParent = this;
                            frmItemMaster.Show();
                            frmItemMaster.BringToFront();
                        }
                        else
                        {
                            frmItemMaster.Activate();
                            frmItemMaster.Show();
                            frmItemMaster.BringToFront();
                        }
                        break;


                    case "frmTransactionIn":
                        if (frmTransactionIn == null)
                        {
                            frmTransactionIn = new frmTransactionIn();
                            frmTransactionIn.MdiParent = this;
                            frmTransactionIn.Show();
                            frmTransactionIn.BringToFront();
                        }
                        else if (frmTransactionIn.IsDisposed == true)
                        {
                            frmTransactionIn = new frmTransactionIn();
                            frmTransactionIn.MdiParent = this;
                            frmTransactionIn.Show();
                            frmTransactionIn.BringToFront();
                        }
                        else
                        {
                            frmTransactionIn.Activate();
                            frmTransactionIn.Show();
                            frmTransactionIn.BringToFront();
                        }
                        break;


                    case "frmTransactionOut":
                        if (frmTransactionOut == null)
                        {
                            frmTransactionOut = new frmTransactionOut();
                            frmTransactionOut.MdiParent = this;
                            frmTransactionOut.Show();
                            frmTransactionOut.BringToFront();
                        }
                        else if (frmTransactionOut.IsDisposed == true)
                        {
                            frmTransactionOut = new frmTransactionOut();
                            frmTransactionOut.MdiParent = this;
                            frmTransactionOut.Show();
                            frmTransactionOut.BringToFront();
                        }
                        else
                        {
                            frmTransactionOut.Activate();
                            frmTransactionOut.Show();
                            frmTransactionOut.BringToFront();
                        }
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmItemMaster");
        }

        private void iNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmTransactionIn");
        }

        private void oUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmTransactionOut");
        }

    }
}
