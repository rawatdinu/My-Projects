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
    public partial class frmItemMasterLookup : Form
    {
        //width
        private const int SNoWidth = 60;
        private const int ItemIDWidth = 120;
        private const int ItemNameWidth = 300;
        private const int RemarksWidth = 300;
        //index
        private const int CheckBoxIndex = 0;
        private const int SNoIndex = 1;
        private const int ItemIDIndex = 2;
        private const int ItemNameIndex = 3;
        private const int RemarksIndex = 4;

        public List<ItemMaster> SelectedItemList;

        public frmItemMasterLookup()
        {
            InitializeComponent();
        }
        private void frmItemMasterLookup_Load(object sender, EventArgs e)
        {
            DesignSearchGrid();
            DesignSelectedGrid();
            FillSearchGrid();
        }
        private void DesignSearchGrid()
        {
            dgvSearch.RowCount = 1;
            dgvSearch.ColumnCount = 4;

            dgvSearch.Columns[0].Name = "S.No";
            dgvSearch.Columns[0].Width = SNoWidth;
            dgvSearch.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            dgvSearch.Columns[1].Name = "Item ID";
            dgvSearch.Columns[1].Width = ItemIDWidth;

            dgvSearch.Columns[2].Name = "Item Name";
            dgvSearch.Columns[2].Width = ItemNameWidth;


            dgvSearch.Columns[3].Name = "Remarks";
            dgvSearch.Columns[3].Width = RemarksWidth;      //323

            dgvSearch.RowHeadersVisible = false;
            dgvSearch.AllowUserToDeleteRows = false;
            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.AllowUserToResizeRows = false;
            dgvSearch.AllowUserToResizeColumns = true;
            dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSearch.ScrollBars = ScrollBars.Both;
            dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //GlobalFunction.SetGridStyle(dgvSearch);
            CheckBox chkSearch = new CheckBox();
            chkSearch.Name = "Search";
            chkSearch.CheckedChanged += new EventHandler(chkSearch_CheckedChanged);
            GlobalFunction.AddCheckBoxToGrid(dgvSearch, chkSearch);
            //GlobalFunction.AddActionButtonToGrid(dgvSearch);
            GlobalFunction.ApplyMasterGrid(dgvSearch);

        }

        void chkSearch_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            CheckBox chk = (CheckBox)sender;
            SelectUnSelectAllSearchGrid(chk.Checked);

                
        }

        private void DesignSelectedGrid()
        {
            dgvSelected.RowCount = 1;
            dgvSelected.ColumnCount = 4;

            dgvSelected.Columns[0].Name = "S.No";
            dgvSelected.Columns[0].Width = SNoWidth;
            dgvSelected.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            dgvSelected.Columns[1].Name = "Item ID";
            dgvSelected.Columns[1].Width = ItemIDWidth;

            dgvSelected.Columns[2].Name = "Item Name";
            dgvSelected.Columns[2].Width = ItemNameWidth;


            dgvSelected.Columns[3].Name = "Remarks";
            dgvSelected.Columns[3].Width = RemarksWidth;      //323

            dgvSelected.RowHeadersVisible = false;
            dgvSelected.AllowUserToDeleteRows = false;
            dgvSelected.AllowUserToAddRows = false;
            dgvSelected.AllowUserToResizeRows = false;
            dgvSelected.AllowUserToResizeColumns = true;
            dgvSelected.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSelected.ScrollBars = ScrollBars.Both;
            dgvSelected.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //GlobalFunction.SetGridStyle(dgvSearch);
            CheckBox chkSelected = new CheckBox();
            chkSelected.Name = "Selected";
            chkSelected.CheckedChanged += new EventHandler(chkSelected_CheckedChanged);
            GlobalFunction.AddCheckBoxToGrid(dgvSelected, chkSelected);
            //GlobalFunction.AddActionButtonToGrid(dgvSelected);
            GlobalFunction.ApplyMasterGrid(dgvSelected);
        }

        void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            CheckBox chk = (CheckBox)sender;
            SelectUnSelectAllSelectedGrid(chk.Checked);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedItemList = new List<ItemMaster>();

            ItemMaster itemMaster;

            int rowcount = dgvSelected.RowCount;
            string itemCode;

            if (rowcount > 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    itemCode = Convert.ToString(dgvSelected.Rows[i].Cells[ItemIDIndex].Value);
                    itemMaster = new ItemMaster();
                    SelectedItemList.Add(itemMaster.GetItemMasterDetails(itemCode));
                }
            }
            else
            {
                SelectedItemList = null;
            }
            

            this.DialogResult = DialogResult.OK;
        }

        private void FillSearchGrid()
        {
            try
            {

                //
                dgvSearch.RowCount = 0;
                //Master Data
                ItemMaster objMaster = new ItemMaster();

                List<ItemMaster> list = objMaster.GetItemMasterList();

                if ((list != null))
                {
                    if (list.Count > 0)
                    {

                        int i;

                        foreach (ItemMaster obj in list)
                        {
                            i = dgvSearch.RowCount;

                            dgvSearch.RowCount = i + 1;
                            dgvSearch.Rows[i].Cells[SNoIndex].Value = i + 1;

                            dgvSearch.Rows[i].Cells[ItemIDIndex].Value = obj.ItemID;
                            dgvSearch.Rows[i].Cells[ItemNameIndex].Value = obj.ItemName;
                            dgvSearch.Rows[i].Cells[RemarksIndex].Value = obj.Remarks;

                        }

                    }
                }



            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }


        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();

            DataGridViewCheckBoxCell chkSelected = new DataGridViewCheckBoxCell();
            int newRowIndex;

            try
            {
                //ID = Convert.ToInt32(dgvSearch.Rows[dgvSearch.CurrentRow.Index].Cells[1].Value);
                if (e.ColumnIndex == 0 && rowIndex != -1)
                {
                    chk = (DataGridViewCheckBoxCell)dgvSearch.CurrentCell;
                    if (Convert.ToBoolean(chk.Value))
                    {
                        chk.Value = false;
                    }
                    else
                    {
                        

                        chk.Value = true;


                        dgvSelected.RowCount = dgvSelected.RowCount + 1;
                        newRowIndex = dgvSelected.RowCount - 1 ;
                        chkSelected = (DataGridViewCheckBoxCell)dgvSelected.Rows[newRowIndex].Cells[CheckBoxIndex];

                        chkSelected.Value = true;


                        dgvSelected.Rows[newRowIndex].Cells[SNoIndex].Value = dgvSelected.RowCount;

                        dgvSelected.Rows[newRowIndex].Cells[ItemIDIndex].Value = dgvSearch.Rows[rowIndex].Cells[ItemIDIndex].Value;
                        dgvSelected.Rows[newRowIndex].Cells[ItemNameIndex].Value = dgvSearch.Rows[rowIndex].Cells[ItemNameIndex].Value;
                        dgvSelected.Rows[newRowIndex].Cells[RemarksIndex].Value = dgvSearch.Rows[rowIndex].Cells[RemarksIndex].Value;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectUnSelectAllSearchGrid(bool check)
        {
            foreach (DataGridViewRow row in dgvSearch.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell) row.Cells[0];
                chk.Value = check;
                //chk.Value = (chk.Value == null) ? false : check;
            }
        
        }

        private void SelectUnSelectAllSelectedGrid(bool check)
        {
            foreach (DataGridViewRow row in dgvSelected.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = check;
            }

        }

        private void dgvSelected_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();
            try
            {
                //ID = Convert.ToInt32(dgvSearch.Rows[dgvSearch.CurrentRow.Index].Cells[1].Value);
                if (e.ColumnIndex == 0 && rowIndex != -1)
                {
                    dgvSelected.Rows.RemoveAt(dgvSelected.CurrentCell.RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
