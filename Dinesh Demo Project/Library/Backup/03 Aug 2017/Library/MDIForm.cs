using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library
{
    public partial class MDIForm : Form
    {
        public frmUserRegistration frmUserRegistration;
        public frmBooksMaster frmBooksMaster;
        
        private int childFormNumber = 0;

        public MDIForm()
        {
            InitializeComponent();
        }

        /*This is to tes layout of windoes in MDI*/

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        /**/


        public void ShowForm(string formName)
        {

            try
            {
                switch (formName)
                {
                    case "UserRegistration":
                        if (frmUserRegistration == null)
                        {
                            frmUserRegistration = new frmUserRegistration();
                            frmUserRegistration.MdiParent = this;
                            frmUserRegistration.Show();
                            frmUserRegistration.BringToFront();
                        }
                        else if (frmUserRegistration.IsDisposed == true)
                        {
                            frmUserRegistration = new frmUserRegistration();
                            frmUserRegistration.MdiParent = this;
                            frmUserRegistration.Show();
                            frmUserRegistration.BringToFront();
                        }
                        else
                        {
                            frmUserRegistration.Activate();
                            frmUserRegistration.Show();
                            frmUserRegistration.BringToFront();
                        }
                        break;


                    case "frmBooksMaster":
                        if (frmBooksMaster == null)
                        {
                            frmBooksMaster = new frmBooksMaster();
                            frmBooksMaster.MdiParent = this;
                            frmBooksMaster.Show();
                            frmBooksMaster.BringToFront();
                        }
                        else if (frmBooksMaster.IsDisposed == true)
                        {
                            frmBooksMaster = new frmBooksMaster();
                            frmBooksMaster.MdiParent = this;
                            frmBooksMaster.Show();
                            frmBooksMaster.BringToFront();
                        }
                        else
                        {
                            frmBooksMaster.Activate();
                            frmBooksMaster.Show();
                            frmBooksMaster.BringToFront();
                        }
                        break;                                        
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("UserRegistration");

        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("frmBooksMaster");
        }

       
       
    }
}
