using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormResize;

namespace FormResize
{
    public partial class frmMain : Form
    {
        int tabWidth;
        int tabHeight;
        bool flagDesignTime = true;

        private UserControl1 uctr1;
        public frmMain()
        {
            InitializeComponent();
        }

        private void ResizeWindowTo()
        {
            tabWidth = Convert.ToInt32(txtWidth.Text);
            tabHeight = Convert.ToInt32(txtHeight.Text);
            tabControl1.Size = new Size(tabWidth, tabHeight);
            this.Size = this.MinimumSize;

        }

        private void btnSet_Click(object sender, EventArgs e)
        {

            ResizeWindowTo();


        }

        private void LoadUserControl()
        {
            uctr1 = new UserControl1();
            panel1.Controls.Add(uctr1);
        }


        private void Design_dgvDetails()
        {
            dgvDetails.RowCount = 1;
            dgvDetails.ColumnCount = 3;
            dgvDetails.Columns[0].Name = "S.No";
            dgvDetails.Columns[0].Width = 60;
            dgvDetails.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetails.Columns[1].Name = "ID";
            dgvDetails.Columns[1].Width = 60;
            dgvDetails.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvDetails.Columns[2].Name = "Share Holders Name";
            dgvDetails.Columns[2].Width = 270;      //323
            dgvDetails.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;


            dgvDetails.RowHeadersVisible = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToResizeRows = false;
            dgvDetails.AllowUserToResizeColumns = true;
            dgvDetails.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDetails.ScrollBars = ScrollBars.Both;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.CellSelect;

            //dgvDetails.RowsDefaultCellStyle.BackColor = Color.Bisque;
            //dgvDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.Navy;
            //dgvDetails1.RowsDefaultCellStyle.SelectionBackColor = Color.White;

            //cell style
            //dgvDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            //dgvDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetails.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDetails.Font, FontStyle.Bold);
            dgvDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDetails.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDetails.GridColor = Color.Black;

            dgvDetails.RowCount = 5;

        }


        private void Design_dgvDetails2()
        {
            dgvDetails1.RowCount = 1;
            dgvDetails1.ColumnCount = 3;
            //dgvDetails1.Columns[0].Name = "S.No";
            dgvDetails1.Columns[0].Width = 60;
            dgvDetails1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dgvDetails1.Columns[1].Name = "ID";
            dgvDetails1.Columns[1].Width = 60;
            dgvDetails1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            //dgvDetails1.Columns[2].Name = "Share Holders Name";
            dgvDetails1.Columns[2].Width = 270;      //323
            dgvDetails1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;


            dgvDetails1.RowHeadersVisible = false;
            dgvDetails1.AllowUserToDeleteRows = false;
            dgvDetails1.AllowUserToAddRows = false;
            dgvDetails1.AllowUserToResizeRows = false;
            dgvDetails1.AllowUserToResizeColumns = true;
            dgvDetails1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDetails1.ScrollBars = ScrollBars.Both;
            dgvDetails1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            //dgvDetails1.RowsDefaultCellStyle.BackColor = Color.White;
            //dgvDetails1.RowsDefaultCellStyle.SelectionBackColor = Color.White;

            dgvDetails1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvDetails1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetails1.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDetails.Font, FontStyle.Bold);
            dgvDetails1.ColumnHeadersVisible = false;
            dgvDetails1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDetails1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDetails1.GridColor = Color.Black;


            dgvDetails1.RowCount = 1;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Design_dgvDetails();
            Design_dgvDetails2();
            LoadUserControl();
            flagDesignTime = false;

        }





        private void dgvDetails_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (flagDesignTime == false)
            {
                int colCount = dgvDetails.ColumnCount;
                int i;
                for (i = 0; i < colCount; i++)
                {
                    dgvDetails1.Columns[i].Width = dgvDetails.Columns[i].Width;
                }

            }

        }

        private void dgvDetails1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (flagDesignTime == false)
            {
                int colCount = dgvDetails1.ColumnCount;
                int i;
                for (i = 0; i < colCount; i++)
                {
                    dgvDetails.Columns[i].Width = dgvDetails1.Columns[i].Width;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s1, s2;
            s1 = new Student();
            s1.Name = "Student 1";
            s1.RollNo = 1;
            s1.FatherNamer = "Father 1";

            MessageBox.Show(s1.Name + " " + s1.RollNo + " " + s1.FatherNamer);


            s2 = new Student();
            s2.Name = "Student 2";
            s2.RollNo = 2;
            s2.FatherNamer = "Father 2";

            MessageBox.Show(s2.Name + " " + s2.RollNo + " " + s2.FatherNamer);


            s1 = s2;

            MessageBox.Show(s1.Name + " " + s1.RollNo + " " + s1.FatherNamer);

            MessageBox.Show(s2.Name + " " + s2.RollNo + " " + s2.FatherNamer);


            s1.Name = "Student 1";
            s1.RollNo = 1;
            s1.FatherNamer = "Father 1";
            MessageBox.Show(s2.Name + " " + s2.RollNo + " " + s2.FatherNamer);




        }

        private void txtHeight_Enter(object sender, EventArgs e)
        {
            //txtHeight.SelectAll();
            BeginInvoke((Action)delegate
{
    txtHeight.SelectAll();
});

        }




    }



}
