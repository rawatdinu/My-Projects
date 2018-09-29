using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormResize
{
    public partial class UserControl1 : UserControl
    {
        public int tabWidth;
        public int tabHeight;
        public TabPage tabPage;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            ResizeWindowTo();
            tabPage = new TabPage();
            //this.Size = this.MinimumSize;
            tabPage = (TabPage)((this.Parent).Parent);

            tabPage.Size = new Size(tabWidth, tabHeight);
        }
        private void ResizeWindowTo()
        {

            tabWidth = Convert.ToInt32(txtWidth.Text);
            tabHeight = Convert.ToInt32(txtHeight.Text);
          

        }
    }
}
