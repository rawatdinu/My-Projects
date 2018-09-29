using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoProject.AppCode;
using System.Globalization;

namespace DemoProject
{
    public partial class frmItemWiseSale : Form
    {

        //Constant
        private const int SNo = 0;
        private const int ItemCode = 1;
        private const int ItemName = 2;        
        private const int Quantity = 3;
        private const int Amount = 4;        
        private const int Discount = 5;
        private const int TotalAmount = 6;


        private const int SNoWidth = 3;
        private const int ItemCodeWidth = 80;
        private const int ItemNameWidth = 300;
        private const int QuantityWidth = 80;
        private const int AmountWidth = 100;
        private const int DiscountWidth = 80;
        private const int TotalAmountWidth = 100;

       

        public frmItemWiseSale()
        {
            InitializeComponent();
        }

        private void frmItemWiseSale_Load(object sender, EventArgs e)
        {
            DesignSearchGrid();
            DisplayTrasactionDetails();
        }
        private void DesignSearchGrid()
        {


            dgvSearch.RowCount = 1;
            dgvSearch.ColumnCount = 7;

            dgvSearch.Columns[SNo].Name = "S.No";
            dgvSearch.Columns[SNo].Width = SNoWidth;
            dgvSearch.Columns[SNo].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvSearch.Columns[ItemCode].Name = "Item Code";
            dgvSearch.Columns[ItemCode].Width = ItemCodeWidth;


            dgvSearch.Columns[ItemName].Name = "Item Name";
            dgvSearch.Columns[ItemName].Width = ItemNameWidth;
            //dgvSearch.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            
            dgvSearch.Columns[Quantity].Name = "Quantity";
            dgvSearch.Columns[Quantity].Width = QuantityWidth;
            dgvSearch.Columns[Quantity].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvSearch.Columns[Amount].Name = "Amount";
            dgvSearch.Columns[Amount].Width = AmountWidth;
            dgvSearch.Columns[Amount].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            

            dgvSearch.Columns[Discount].Name = "Discount";
            dgvSearch.Columns[Discount].Width = DiscountWidth;
            dgvSearch.Columns[Discount].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSearch.Columns[TotalAmount].Name = "Total Amount";
            dgvSearch.Columns[TotalAmount].Width = TotalAmountWidth;
            dgvSearch.Columns[TotalAmount].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            dgvSearch.RowHeadersVisible = false;
            dgvSearch.AllowUserToDeleteRows = false;
            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.AllowUserToResizeRows = false;
            dgvSearch.AllowUserToResizeColumns = true;
            dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSearch.ScrollBars = ScrollBars.Both;
            dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Row height
            dgvSearch.RowTemplate.Height = 18;

            //GlobalFunction.SetGridStyle(dgvSearch);


        }

        private void DisplayTrasactionDetails(bool dateFilter = false)
        {

            DataTable dt = new DataTable();
            string str;
            int rowCount;
            double totalSale = 0.0;

            string fromDate = dtpFromDate.Value.ToString("MM/dd/yyyy");
            string toDate = dtpToDate.Value.AddDays(1).ToString("MM/dd/yyyy");

            if (!dateFilter)
            {
                //current date result by default
                fromDate = DateTime.Now.Date.ToString("MM/dd/yyyy");
                toDate = DateTime.Now.Date.AddDays(1).ToString("MM/dd/yyyy");
            }

            try
            {

                //if (dateFilter)// filder by date
                //{

                str = "SELECT  A.ItemCode,FoodItemMaster.FoodName, A.Quantity, A.Amount, A.Discount, A.TotalAmount FROM (SELECT SaleMasterDetails.ItemCode AS ItemCode, Sum(SaleMasterDetails.Quantity) AS Quantity, Sum(SaleMasterDetails.Amount) AS Amount, Sum(SaleMasterDetails.Discount) as Discount, Sum(SaleMasterDetails.TotalAmount) as TotalAmount   FROM SaleMaster INNER JOIN SaleMasterDetails ON SaleMaster.TransactionID = SaleMasterDetails.TransactionID WHERE (((SaleMaster.SaleDate)>=#1/1/2015# And (SaleMaster.SaleDate)<=#12/12/2016#)) GROUP BY SaleMasterDetails.ItemCode) as A  INNER JOIN FoodItemMaster  ON A.ItemCode = FoodItemMaster.Code Order by A.ItemCode";

                //}
                //else // Default
                //{
                //    str = "SELECT TransactionID, CustomerName, TotalAmount, SaleDate, Remarks FROM SaleMaster ORDER BY TransactionID";
                //}

                dt = DBService.GetDataTable(str);
                rowCount = dt.Rows.Count;
                if (rowCount > 0)
                {



                    for (int i = 0; i < rowCount; i++)
                    {
                        
                        //share details                        
                        //dgvSearch.RowCount += 1;
                        dgvSearch.RowCount = i + 1;
                        dgvSearch.Rows[i].Cells[SNo].Value = i + 1;
                        dgvSearch.Rows[i].Cells[ItemCode].Value = Convert.ToString(dt.Rows[i]["ItemCode"]);
                        dgvSearch.Rows[i].Cells[ItemName].Value = Convert.ToString(dt.Rows[i]["FoodName"]);
                        dgvSearch.Rows[i].Cells[Quantity].Value = Convert.ToDouble(dt.Rows[i]["Quantity"]);

                        dgvSearch.Rows[i].Cells[Amount].Value = Convert.ToDouble(dt.Rows[i]["Amount"]);
                        dgvSearch.Rows[i].Cells[Discount].Value = Convert.ToDouble(dt.Rows[i]["Discount"]);
                        dgvSearch.Rows[i].Cells[TotalAmount].Value = Convert.ToDouble(dt.Rows[i]["TotalAmount"]);

                        totalSale = totalSale + Convert.ToDouble(dgvSearch.Rows[i].Cells[TotalAmount].Value);
                    }

                }
                else
                {
                    dgvSearch.RowCount = 0;
                }
                //lblTotalSale.Text = Convert.ToString(totalSale);
                lblTotalSale.Text = GlobalFunction.GetCurrencyFormat(totalSale,false,true);
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }

        }
        
    }
}
