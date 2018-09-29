using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShrikantProjectDesing
{
    public partial class MDIParent1 : Form
    {
        public frmItemMaster frmItemMaster;
        public frmAdd frmAdd;
        public frmModify frmModify;

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

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            CloseAllForms();
        }

        private void CloseAllForms()
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
                    case "frmItemMaster":
                        if (frmItemMaster == null)
                        {
                            frmItemMaster = new frmItemMaster();
                            frmItemMaster.Size = this.Size;
                            frmItemMaster.MdiParent = this;
                            frmItemMaster.Show();
                            frmItemMaster.BringToFront();
                        }
                        else if (frmItemMaster.IsDisposed == true)
                        {
                            frmItemMaster = new frmItemMaster();
                            frmItemMaster.Size = this.Size;
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


                    case "frmAdd":
                        if (frmAdd == null)
                        {
                            frmAdd = new frmAdd();
                            frmAdd.Size = this.Size;
                            frmAdd.MdiParent = this;
                            frmAdd.Show();
                            frmAdd.BringToFront();
                        }
                        else if (frmAdd.IsDisposed == true)
                        {
                            frmAdd = new frmAdd();
                            frmAdd.Size = this.Size;
                            frmAdd.MdiParent = this;
                            frmAdd.Show();
                            frmAdd.BringToFront();
                        }
                        else
                        {
                            frmAdd.Activate();
                            frmAdd.Show();
                            frmAdd.BringToFront();
                        }
                        break;
                    case "frmModify":
                        if (frmModify == null)
                        {
                            frmModify = new frmModify();
                            frmModify.Size = this.Size;
                            frmModify.MdiParent = this;
                            frmModify.Show();
                            frmModify.BringToFront();
                        }
                        else if (frmModify.IsDisposed == true)
                        {
                            frmModify = new frmModify();
                            frmModify.Size = this.Size;
                            frmModify.MdiParent = this;
                            frmModify.Show();
                            frmModify.BringToFront();
                        }
                        else
                        {
                            frmModify.Activate();
                            frmModify.Show();
                            frmModify.BringToFront();
                        }
                        break;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            ShowForm("frmAdd");
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            ShowForm("frmItemMaster");
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForms();
            ShowForm("frmModify");
        }

      
    }
}
