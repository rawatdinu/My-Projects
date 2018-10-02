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
    public partial class frmInventory : Form
    {
        private bool AddMode = false;
        private bool EditMode = false;
        private string _itemID = "";

        ItemMaster itemMaster;
        frmItemMaster frmInterface;


        //Constant
        //Grid colum index
        private const int SNo = 0;
        private const int ItemID = 1;
        private const int ItemName = 2;
        private const int QtyIn = 3;
        private const int QtyOut = 4;
        private const int BalanceUnit = 5;
        private const int Detail = 6;
        


        //column width
        private const int SNoWidth = 60;
        private const int ItemIDWidth = 150;
        private const int ItemNameWidth = 200;
        //private const int AuthorWidth = 200;
        //private const int EditionYearWidth = 60;
        //private const int EditionNoWidth = 60;
        private const int UnitWidth = 90;
        private const int DetailWidth = 90;

        public frmInventory()
        {
            InitializeComponent();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            DesignMainGrid();
        }

        private void DesignMainGrid()
        {
            dgvMain.RowCount = 1;
            dgvMain.ColumnCount = 7;

            dgvMain.Columns[0].Name = "S.No";
            dgvMain.Columns[0].Width = SNoWidth;
            dgvMain.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[1].Name = "ItemID";
            dgvMain.Columns[1].Width = ItemIDWidth;

            dgvMain.Columns[2].Name = "ItemName";
            dgvMain.Columns[2].Width = ItemNameWidth;


            dgvMain.Columns[3].Name = "Qty In";
            dgvMain.Columns[3].Width = UnitWidth;      //323
            dgvMain.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[4].Name = "Qty Out";
            dgvMain.Columns[4].Width = UnitWidth;      //323
            dgvMain.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[5].Name = "Balance";
            dgvMain.Columns[5].Width = UnitWidth;      //323
            dgvMain.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMain.Columns[6].Name = "Details";
            dgvMain.Columns[6].Width = DetailWidth;      //323
            dgvMain.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvMain.Columns[5].Name = "Amount";
            //dgvMain.Columns[5].Width = UnitWidth;      //323
            //dgvMain.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            dgvMain.RowHeadersVisible = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToResizeRows = false;
            dgvMain.AllowUserToResizeColumns = true;
            dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMain.ScrollBars = ScrollBars.Both;
            dgvMain.SelectionMode = DataGridViewSelectionMode.CellSelect;

            GlobalFunction.SetGridStyle(dgvMain);

            //}
        }
        private void ClearControl()
        {

            
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
            txtRemarks.Text = "";
            dgvMain.RowCount = 0;
        }

        public void ShowInventoryInGrid()
        {

            try
            {
                ClearControl();



     

                    //Inventory data
                Inventory objInventory = new Inventory();
                   List<Inventory> list = new List<Inventory>();
                   list = objInventory.GetInventoryList();
                   
                    if ((list != null))
                    {
                        if (list.Count > 0)
                        {

                            int i;

                            foreach (Inventory obj in list)
                            {

                                i = dgvMain.RowCount;

                                dgvMain.RowCount = i + 1;
                                dgvMain.Rows[i].Cells[SNo].Value = i + 1;

                                dgvMain.Rows[i].Cells[ItemID].Value = obj.ItemMaster.ItemID;
                                dgvMain.Rows[i].Cells[ItemName].Value = obj.ItemMaster.ItemName;
                                dgvMain.Rows[i].Cells[QtyIn].Value = obj.QtyIn;
                                dgvMain.Rows[i].Cells[QtyOut].Value = obj.QtyOut;
                                dgvMain.Rows[i].Cells[BalanceUnit].Value = obj.QtyIn - obj.QtyOut;
                                //dgvMain.Rows[i].Cells[Unit].Value = obj
                                //dgvMain.Rows[i].Cells[EditionNo].Value = obj.BookMaster.EditionNo;
                                //dgvMain.Rows[i].Cells[Unit].Value = obj.Unit;
                                //if (obj.Rate > 0)
                                //{
                                //    dgvMain.Rows[i].Cells[Rate].Value = obj.Rate;
                                //}
                                //if (obj.Amount > 0)
                                //{
                                //    dgvMain.Rows[i].Cells[Amount].Value = obj.Amount;
                                //}

                            }

                        }
                    }


                }
           

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            ShowInventoryInGrid();
        }


    }
}
