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
    public partial class frmAdd : Form
    {
        public frmAdd()
        {
            InitializeComponent();
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            DesignMainGrid();
            DesignListGrid();
            panel1.BringToFront();
        }


        private void DesignMainGrid()
        {
            dgvMain.RowCount = 1;
            dgvMain.ColumnCount = 8;

            //dgvMain.Columns[0].Name = "S.No";
            //dgvMain.Columns[0].Width = SNoWidth;
            //dgvMain.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[0].Name = "HSN/SAC";
            dgvMain.Columns[0].Width = 100;

            dgvMain.Columns[1].Name = "Description";
            dgvMain.Columns[1].Width = 100;

            dgvMain.Columns[2].Name = "Unit";
            dgvMain.Columns[2].Width = 80;      //323
            dgvMain.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[3].Name = "Rate";
            dgvMain.Columns[3].Width = 100;
            dgvMain.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[4].Name = "Qty";
            dgvMain.Columns[4].Width = 80;
            dgvMain.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[5].Name = "Amount";
            dgvMain.Columns[5].Width = 100;      //323
            dgvMain.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[6].Name = "Amount";
            dgvMain.Columns[6].Width = 100;      //323
            dgvMain.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[7].Name = "IGST Amount";
            dgvMain.Columns[7].Width = 100;      //323
            dgvMain.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            



            dgvMain.RowHeadersVisible = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToResizeRows = false;
            dgvMain.AllowUserToResizeColumns = true;
            dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMain.ScrollBars = ScrollBars.Both;
            dgvMain.SelectionMode = DataGridViewSelectionMode.CellSelect;

           // GlobalFunction.SetGridStyle(dgvMain);

            //}
        }

         private void DesignListGrid()
        {
            dgvSearch.RowCount = 1;
            dgvSearch.ColumnCount = 8;


            dgvSearch.Columns[0].Name = "Type";
            dgvSearch.Columns[0].Width = 100;

            dgvSearch.Columns[1].Name = "HSN No";
            dgvSearch.Columns[1].Width = 100;

            dgvSearch.Columns[2].Name = "HSN code";
            dgvSearch.Columns[2].Width = 80;      //323
            dgvSearch.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSearch.Columns[3].Name = "SSN Name";
            dgvSearch.Columns[3].Width = 100;
            dgvSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSearch.Columns[4].Name = "QUC";
            dgvSearch.Columns[4].Width = 80;
            dgvSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSearch.Columns[5].Name = "CGST Tax";
            dgvSearch.Columns[5].Width = 100;      //323
            dgvSearch.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSearch.Columns[6].Name = "SGST Tax";
            dgvSearch.Columns[6].Width = 100;      //323
            dgvSearch.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSearch.Columns[7].Name = "IGST Tax";
            dgvSearch.Columns[7].Width = 100;      //323
            dgvSearch.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            



            dgvSearch.RowHeadersVisible = false;
            dgvSearch.AllowUserToDeleteRows = false;
            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.AllowUserToResizeRows = false;
            dgvSearch.AllowUserToResizeColumns = true;
           // dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSearch.ScrollBars = ScrollBars.Both;
            dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

           // GlobalFunction.SetGridStyle(dgvMain);

            //}
        }

        

        private void AddRowInGrid()
        {

            int i = dgvMain.RowCount;
            dgvMain.RowCount = i + 1;          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
            AddRowInGrid();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
            dgvMain.Rows[0].Cells[1].Value = txtHSN.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i = dgvSearch.RowCount;
            dgvSearch.RowCount = i + 1;       
        }

        private void dgvSearch_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtDescription.Text = Convert.ToString(dgvSearch.Rows[i].Cells[3].Value);

        }
    }
}
