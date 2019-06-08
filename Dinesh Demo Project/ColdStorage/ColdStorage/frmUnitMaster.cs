using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ColdStorage.BLL;

namespace ColdStorage
{
    public partial class frmUnitMaster : Form
    {
        public frmUnitMaster()
        {
            InitializeComponent();
        }

        private void frmUnitMaster_Load(object sender, EventArgs e)
        {
            DesignMainGrid();
            FillGrid();
        }

        private void DesignMainGrid()
        {
            dgvMain.RowCount = 1;
            dgvMain.ColumnCount = 3;

            dgvMain.Columns[0].Name = "S.No";
            dgvMain.Columns[0].Width = 40;
            

            dgvMain.Columns[1].Name = "ID";
            dgvMain.Columns[1].Width = 100;
            

            dgvMain.Columns[2].Name = "Unit Name";
            dgvMain.Columns[2].Width = 200;

            dgvMain.RowHeadersVisible = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToResizeRows = false;
            dgvMain.AllowUserToResizeColumns = true;
            dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMain.ScrollBars = ScrollBars.Both;
            dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            GlobalFunction.SetGridStyle(dgvMain);

            
        }

        private void FillGrid()
        {
             UnitMaster objUM = new UnitMaster();
             List<UnitMaster> list = objUM.GetUnitMasterList();
         
            if ((list != null))
            {
                if (list.Count > 0)
                {

                    int i;

                    foreach (UnitMaster obj in list)
                    {
                        i = dgvMain.RowCount;

                        dgvMain.RowCount = i + 1;
                        dgvMain.Rows[i].Cells[0].Value = i + 1;

                        dgvMain.Rows[i].Cells[1].Value = obj.ID;
                        dgvMain.Rows[i].Cells[2].Value = obj.UnitName;
                      

                    }

                }
            }
        }
    }
}
