using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColdStorage
{
    public partial class frmDeshboard : Form
    {
        private bool iscollapsedMaster = true;
        private bool iscollapsedTransaction = true;


        private string selectedMenu = "";

        public frmDeshboard()
        {
            InitializeComponent();
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            selectedMenu = ((Button)sender).Text;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                switch (selectedMenu)
                {


                    case "Master":
                        if (iscollapsedMaster)
                        {
                            //cmdMaster.Image = POC.Properties.Resources.down1;
                            pnlddMaster.Height += 10;
                            if (pnlddMaster.Height == pnlddMaster.MaximumSize.Height)
                            {
                                timer1.Stop();
                                iscollapsedMaster = false;
                            }
                        }
                        else
                        {
                            //cmdMaster.Image = POC.Properties.Resources.up1;
                            pnlddMaster.Height -= 10;
                            if (pnlddMaster.Height == pnlddMaster.MinimumSize.Height)
                            {
                                timer1.Stop();
                                iscollapsedMaster = true;
                            }
                        }
                        break;

                    case "Transaction":
                        if (iscollapsedTransaction)
                        {
                            //cmdTransaction.Image = POC.Properties.Resources.down1;
                            pnlddTransaction.Height += 10;
                            if (pnlddTransaction.Height == pnlddTransaction.MaximumSize.Height)
                            {
                                timer1.Stop();
                                iscollapsedTransaction = false;
                            }
                        }
                        else
                        {
                            //cmdTransaction.Image = POC.Properties.Resources.up1;
                            pnlddTransaction.Height -= 10;
                            if (pnlddTransaction.Height == pnlddTransaction.MinimumSize.Height)
                            {
                                timer1.Stop();
                                iscollapsedTransaction = true;
                            }
                        }
                        break;



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdItemMaster_Click(object sender, EventArgs e)
        {
            frmItemMaster objForm = new frmItemMaster();
            objForm.TopLevel = false;
            this.pnlContainer.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //objForm.Dock = DockStyle.Fill;
            objForm.Show();
        } 

      
       


    }


}
