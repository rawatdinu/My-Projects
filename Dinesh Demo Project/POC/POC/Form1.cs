using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace POC
{
    public partial class Form1 : Form
    {
        private bool iscollapsed=true;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (iscollapsed)
            {
                cmdMaster.Image = POC.Properties.Resources.down1;
                ddPanel.Height += 10;
                if (ddPanel.Height == ddPanel.MaximumSize.Height)
                {
                    timer1.Stop();
                    iscollapsed = false;
                }
            }
            else
            {
                cmdMaster.Image = POC.Properties.Resources.up1;
                ddPanel.Height -= 10;
                if (ddPanel.Height == ddPanel.MinimumSize.Height)
                {
                    timer1.Stop();
                    iscollapsed = true;
                }
            }

        }

        private void cmdMaster_Click(object sender, EventArgs e)
        {
            
            timer1.Start();
        }
    }
}
