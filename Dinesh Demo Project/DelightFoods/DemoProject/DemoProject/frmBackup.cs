using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace DemoProject
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        string sourcefilePath = ConfigurationManager.AppSettings["DatabasePath"];

        private void cmdPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            string path = fd.SelectedPath;
            txtPath.Text = path;
        }

        private void cmdBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string destinationFile = txtPath.Text.Trim() + @"\DBDelightFoods_" + DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss") + @".accdb";
                if (Directory.Exists(txtPath.Text.Trim()))
                {
                    File.Copy(sourcefilePath, destinationFile, true);
                    lblMsg.Text = "";
                    MessageBox.Show("Process is complete");
                }
                else
                {
                    lblMsg.Text = "Path does not exist";
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
           
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
        }
    }
}
