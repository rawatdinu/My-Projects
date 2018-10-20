using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDIForm
{
    public partial class Form1 : Form
    {
        private bool iscollapsed = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (iscollapsed)
            {
                cmdMaster.Image = MDIForm.Properties.Resources.down;
                ddPanel.Height += 10;
                if (ddPanel.Height == ddPanel.MaximumSize.Height)
                {
                    timer2.Stop();
                    iscollapsed = false;
                }
            }
            else
            {
                cmdMaster.Image = MDIForm.Properties.Resources.up;
                ddPanel.Height -= 10;
                if (ddPanel.Height == ddPanel.MinimumSize.Height)
                {
                    timer2.Stop();
                    iscollapsed = true;
                }
            }

        }

        private void cmdMaster_Click(object sender, EventArgs e)
        {

            timer2.Start();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdItemMaster_Click(object sender, EventArgs e)
        {
            //ItemMaster obj = new ItemMaster();
            //this.pnlContainer.Controls.Add(obj);

            //obj.Show();

            ItemMaster objForm = new ItemMaster();
            objForm.TopLevel = false;
            this.pnlContainer.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //objForm.Dock = DockStyle.Fill;
            objForm.Show();


        }
    }
}
