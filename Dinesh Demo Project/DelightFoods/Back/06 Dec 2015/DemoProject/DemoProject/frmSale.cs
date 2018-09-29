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

namespace DemoProject
{
    public partial class frmSale : Form
    {
        private bool IsEdit = false;
        private bool IsAdd = false;
        private string _validationMessege = "";
        private int _hostID;



        //Constant
        private const int SNo = 0;
        private const int Code = 1;
        private const int ItemName = 2;
        private const int Rate = 3;
        private const int Quantity = 4;
        private const int Amount = 5;
        private const int DiscountPercentage = 6;
        private const int Discount = 7;
        private const int TotalAmount = 8;
        private const int CheckBoxColumn = 9;

        

        //column width
        private const int SNoWidth = 30;
        private const int CodeWidth = 60;
        private const int ItemNameWidth = 180;
        private const int RateWidth = 40;
        private const int QuantityWidth = 30;
        private const int AmountWidth = 50;
        private const int DiscountPercentageWidth = 40;
        private const int DiscountWidth = 60;
        private const int TotalAmountWidth = 80;
        private const int CheckBoxColumnWidth = 40;
        
        public frmSale()
        {
            InitializeComponent();
        }

        private void frmSale_Load(object sender, EventArgs e)
        {
            
            
            DesignMainGrid();
            DesignSearchGrid();
            ClearControl();
            ControlStatus(true);
            DisplayData();
            //New code
            LoadFoodCategory();

        }
        

        private void LoadFoodCategory()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;

            
            this.flowPnlCategory.Controls.Clear();

           
            try
            {

                str = "SELECT Code, CategoryName FROM FoodCategory order by Code";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                /**********************************/
                Button bt = new Button();
                //Design Category Buttion                                
                DesignCategoryButton(ref bt);
                //
                FoodCategory foodCategory = new FoodCategory();
                foodCategory.Code = "Veg";
                foodCategory.CategoryName = "Veg";
                bt.Tag = foodCategory;

                //Category Data
                bt.Name = foodCategory.Code;
                bt.Text = foodCategory.CategoryName;
                bt.Click += new System.EventHandler(CategoryButton_Click);
                this.flowPnlCategory.Controls.Add(bt);

                //Nov Veg Button
                bt = new Button();
                //Design Category Buttion
                DesignCategoryButton(ref bt);
                //
                foodCategory = new FoodCategory();
                foodCategory.Code = "Non-Veg";
                foodCategory.CategoryName = "Non-Veg";
                bt.Tag = foodCategory;

                //Category Data
                bt.Name = foodCategory.Code;
                bt.Text = foodCategory.CategoryName;
                bt.Click += new System.EventHandler(CategoryButton_Click);
                this.flowPnlCategory.Controls.Add(bt);
                /**********************************/

                for (int i = 0; i < RecNo; i++)
                {
                    bt = new Button();
                    //Design Category Buttion
                    DesignCategoryButton(ref bt);
                    //
                    foodCategory = new FoodCategory(); 
                    foodCategory.Code = Convert.ToString(dt.Rows[i]["Code"]);
                    foodCategory.CategoryName = Convert.ToString(dt.Rows[i]["CategoryName"]);
                    bt.Tag = foodCategory;

                    //Category Data
                    bt.Name = foodCategory.Code;
                    bt.Text = foodCategory.CategoryName;

                    bt.Click += new System.EventHandler(CategoryButton_Click);
                    this.flowPnlCategory.Controls.Add(bt);

                }               
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        }

        private void DesignCategoryButton(ref Button bt)
        {
            int width = 75;
            int height = 75;
            bt.Size = new System.Drawing.Size(width, height);    
            //font
            bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));            
            //Color
        
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {

            string categoryCode = ((Button)sender).Name;
            LoadFoodItem(categoryCode);

            //MessageBox.Show(str);
        }

        private void LoadFoodItem(string foodCategoryCode)
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;

            this.flowPnlFoodItem.Controls.Clear();

            try
            {
                
                if (foodCategoryCode == "Veg")//Veg
                {
                    str = "SELECT Code, FoodName, Price, UnitName, Discount, FoodType, FoodCategory FROM FoodItemMaster WHERE FoodType='TYP01' Order by Code";

                }
                else if (foodCategoryCode == "Non-Veg")//Nov-Veg
                {
                    str = "SELECT Code, FoodName, Price, UnitName, Discount, FoodType, FoodCategory FROM FoodItemMaster WHERE FoodType='TYP02' Order by Code";
                    
                }
                else//According to food category
                {
                    str = "SELECT Code, FoodName, Price, UnitName, Discount, FoodType, FoodCategory FROM FoodItemMaster where  FoodCategory='" + foodCategoryCode + "' order by Code";
                }
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                for (int i = 0; i < RecNo; i++)
                {
                    Button bt = new Button();
                    //Design Food Item
                    DesignFoodItemButton(ref bt);
                    //
                    FoodItem foodItem = new FoodItem();
                    foodItem.Code = Convert.ToString(dt.Rows[i]["Code"]);
                    foodItem.FoodName = Convert.ToString(dt.Rows[i]["FoodName"]);
                    foodItem.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                    foodItem.UnitName = Convert.ToString(dt.Rows[i]["UnitName"]);
                    foodItem.DiscountPerc = Convert.ToDouble(dt.Rows[i]["Discount"]);
                    bt.Tag = foodItem;

                    //Food Item Data
                    bt.Name = foodItem.Code;
                    bt.Text = foodItem.FoodName;

                    bt.Click += new System.EventHandler(FoodItemButton_Click);
                    this.flowPnlFoodItem.Controls.Add(bt);

                }  

                
            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        }

        private void DesignFoodItemButton(ref Button bt)
        {
            int width = 75;
            int height = 75;
            bt.Size = new System.Drawing.Size(width, height);
            //font
            bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //Color

        }

        private void FoodItemButton_Click(object sender, EventArgs e)
        {

            if (IsAdd || IsEdit)
            {
                FoodItem fooditem  = (FoodItem)((Button)sender).Tag;

                if(!IsItemAlreadyAdded(fooditem.Code))
                {
                    AddFoodItemToGrid(fooditem);
                }
                CalculateTotalAmount();
            }
                        
        }

        private bool IsItemAlreadyAdded(string itemCode)
        {
            bool result = false;
            int rowCount = dgvMain.RowCount;

            for (int i = 0; i < rowCount; i++)
            {
                if (Convert.ToString(dgvMain.Rows[i].Cells[Code].Value) == itemCode)
                { 
                    //update qunatity
                    dgvMain.Rows[i].Cells[Quantity].Value = Convert.ToInt32(dgvMain.Rows[i].Cells[Quantity].Value) + 1;
                    result = true;
                    break;
                }
            }
            return result;        
        }

        private void AddFoodItemToGrid(FoodItem foodItem)
        {

            int i = dgvMain.RowCount;
            dgvMain.RowCount = i + 1;

            dgvMain.Rows[i].Cells[SNo].Value = i + 1;
            dgvMain.Rows[i].Cells[Code].Value = foodItem.Code;
            dgvMain.Rows[i].Cells[ItemName].Value = foodItem.FoodName;
            dgvMain.Rows[i].Cells[Rate].Value = foodItem.Price;

            dgvMain.Rows[i].Cells[Quantity].Value = 1;

            dgvMain.Rows[i].Cells[DiscountPercentage].Value = foodItem.DiscountPerc;

           
        
        }

      
        private void ControlStatus(bool status)
        {
            btnAdd.Enabled = status;
            btnEdit.Enabled = status;
            cmdSearch.Enabled = status;
            btnSave.Enabled = !(status);
            btnCancel.Enabled = !(status);
            cmdRemoveItem.Enabled = !(status);
            txtTrasactionID.ReadOnly = true;

            txtCustomerName.ReadOnly = status;
            txtRemarks.ReadOnly = status;
            
            dtpSaleDate.Enabled = !(status);

            if (GlobalFunction.glbUserType == GlobalFunction.NormalUser)
            {
                btnEdit.Enabled = false;
                cmdSearch.Enabled = false;
                dtpSaleDate.Enabled = false;
                pnlTodaySale.Visible = false;
            }
            
        }

        private void ClearControl()
        {

            txtTrasactionID.Text = "";
            dtpSaleDate.Value = DateTime.Now;
                        
            txtRemarks.Text = "";
            lblTotalAmount.Text = "0";
            lblTotalQuantity.Text = "0";
            lblTotalItem.Text = "0";            
            dgvMain.RowCount = 0;
            

        }
        private void DesignMainGrid()
        {
       

            dgvMain.RowCount = 1;
            dgvMain.ColumnCount = 9;

            dgvMain.Columns[0].Name = "S.No";
            dgvMain.Columns[0].Width = SNoWidth;
            dgvMain.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
    
            dgvMain.Columns[1].Name = "Code";
            dgvMain.Columns[1].Width = CodeWidth;
            dgvMain.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvMain.Columns[1].Visible = false;

            dgvMain.Columns[2].Name = "Item Name";
            dgvMain.Columns[2].Width = ItemNameWidth;
            dgvMain.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            //Calculation
            dgvMain.Columns[3].Name = "Rate";
            dgvMain.Columns[3].Width = RateWidth;
            dgvMain.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
 
            dgvMain.Columns[4].Name = "Qty";
            dgvMain.Columns[4].Width = QuantityWidth;
            dgvMain.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvMain.Columns[5].Name = "Amount";
            dgvMain.Columns[5].Width = AmountWidth;
            dgvMain.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvMain.Columns[6].Name = "Dis(%)";
            dgvMain.Columns[6].Width = DiscountPercentageWidth;      //323
            dgvMain.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvMain.Columns[7].Name = "Discount";
            dgvMain.Columns[7].Width = DiscountWidth;
            dgvMain.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvMain.Columns[8].Name = "Total Amt";
            dgvMain.Columns[8].Width = TotalAmountWidth;
            dgvMain.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.HeaderText = "Select";
            chkCol.Width = CheckBoxColumnWidth;
            chkCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvMain.Columns.Add(chkCol);
            dgvMain.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

           

            dgvMain.RowHeadersVisible = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToResizeRows = false;
            dgvMain.AllowUserToResizeColumns = true;
            dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMain.ScrollBars = ScrollBars.Both;
            dgvMain.SelectionMode = DataGridViewSelectionMode.CellSelect;


            GlobalFunction.SetGridStyle(dgvMain);

            //if (GlobalFunction.glbUserType == GlobalFunction.SuperUser)
            //{
            //    dgvMain.Columns[1].Visible = true;   //ID
            //    dgvMain.Columns[2].Visible = true;
            //}
            //else
            //{
            //    dgvMain.Columns[1].Visible = false;
            //    dgvMain.Columns[2].Visible = false;
            //}
         

        }

        private void DesignSearchGrid()
        {


            dgvSearch.RowCount = 1;
            dgvSearch.ColumnCount = 6;

            dgvSearch.Columns[0].Name = "S.No";
            dgvSearch.Columns[0].Width = 40;
            dgvSearch.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            

            dgvSearch.Columns[1].Name = "Trans ID";
            dgvSearch.Columns[1].Width = 80;
            

            dgvSearch.Columns[2].Name = "Customer Name";
            dgvSearch.Columns[2].Width = 200;
            //dgvSearch.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            //Calculation
            dgvSearch.Columns[3].Name = "Amount";
            dgvSearch.Columns[3].Width = 100;
            dgvSearch.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            

            dgvSearch.Columns[4].Name = "Sale Date";
            dgvSearch.Columns[4].Width = 100;
            dgvSearch.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSearch.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvSearch.Columns[5].Name = "Remarks";
            dgvSearch.Columns[5].Width = 200;
            
            

            dgvSearch.RowHeadersVisible = false;
            dgvSearch.AllowUserToDeleteRows = false;
            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.AllowUserToResizeRows = false;
            dgvSearch.AllowUserToResizeColumns = true;
            dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSearch.ScrollBars = ScrollBars.Both;
            dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            GlobalFunction.SetGridStyle(dgvSearch);


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                                   
                IsAdd = true;
                IsEdit = false;
                ClearControl();
                ControlStatus(false);
                txtTrasactionID.Text = GlobalFunction.GetUniqueCode("SaleMaster");
                                           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            IsAdd = false;
            ControlStatus(false);
            txtCustomerName.Focus();

        }
        bool ValidateData()
        {
            _validationMessege = "";
            bool result = true;
            
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                Save();
            }
        }

        private void Save()
        {
            string querry = "";
            string[] para;
            object[] values;
            List<Transaction> transList = new List<Transaction>();

            string str1;
            object obj;
            int rowCount;

            double totalAmount = 0.0;
            



            try
            {
                if (IsAdd)
                {
                    //DialogResult dr = MessageBox.Show("Do you want to save?", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    //if (dr == DialogResult.OK)
                    //{
                        //Get Unique ID
                        txtTrasactionID.Text = GlobalFunction.GetUniqueCode("SaleMaster");

                        str1 = "Insert into SaleMaster (TransactionID, SaleDate, CustomerName, Remarks, TotalAmount, TotalQty, TotalItem, CreatedOn) values (@TransactionID, @SaleDate, @CustomerName, @Remarks, @TotalAmount, @TotalQty, @TotalItem, @CreatedOn)";
                        para = new string[] { "@TransactionID", "@SaleDate", "@CustomerName", "@Remarks", "@TotalAmount", "@TotalQty", "@TotalItem", "@CreatedOn" };
                        values = new object[] { txtTrasactionID.Text.Trim(), GlobalFunction.GetDateTimeWithoutMiliSecond(dtpSaleDate.Value), txtCustomerName.Text, txtRemarks.Text.Trim(), Convert.ToDouble(lblTotalAmount.Text), Convert.ToInt32(lblTotalQuantity.Text), Convert.ToInt32(lblTotalItem.Text), GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now) };
                        transList.Add(new Transaction(str1, para, values));

                        //Save details
                        rowCount = dgvMain.RowCount;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            str1 = "Insert into SaleMasterDetails (TransactionID, ItemCode, Rate,Quantity, Amount, DiscountPerc, Discount, TotalAmount) values (@TransactionID, @ItemCode, @Rate,@Quantity, @Amount, @DiscountPerc, @Discount, @TotalAmount)";
                            para = new string[] { "@TransactionID", "@ItemCode", "@Rate", "@Quantity", "@Amount", "@DiscountPerc", "@Discount", "@TotalAmount" };
                            values = new object[] { txtTrasactionID.Text.Trim(), Convert.ToString(dgvMain.Rows[rowIndex].Cells[Code].Value), Convert.ToDouble(dgvMain.Rows[rowIndex].Cells[Rate].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Quantity].Value), Convert.ToDouble(dgvMain.Rows[rowIndex].Cells[Amount].Value), Convert.ToDouble(dgvMain.Rows[rowIndex].Cells[DiscountPercentage].Value), Convert.ToDouble(dgvMain.Rows[rowIndex].Cells[Discount].Value), Convert.ToDouble(dgvMain.Rows[rowIndex].Cells[TotalAmount].Value) };

                            transList.Add(new Transaction(str1, para, values));
                        }

                        // UPdate counter
                        str1 = "Update UniqueCodeMaster set CurrentNo=CurrentNo + IncrementBy where TableName='SaleMaster'";
                        para = new string[] { };
                        values = new object[] { };
                        transList.Add(new Transaction(str1, para, values));

                        obj = DBService.ExecuteTransaction(transList);
                        if (obj != null)
                        {
                            IsAdd = false;
                           // MessageBox.Show("Data is saved succesfully");
                            ControlStatus(true);
                            DisplayData(txtTrasactionID.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }
                    //}
                }
                /******************************EDIT*****************************************/
                else if (IsEdit)
                {
                    //DialogResult dr = MessageBox.Show("Do you want to update?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    //if (dr == DialogResult.OK)
                    //{

                    str1 = "Update  SaleMaster set SaleDate=@SaleDate, CustomerName=@CustomerName, Remarks=@Remarks, TotalAmount=@TotalAmount, TotalQty=@TotalQty, TotalItem=@TotalItem, LastModify=@LastModify Where TransactionID=@TransactionID";
                        para = new string[] { "@SaleDate", "@CustomerName", "@Remarks", "@TotalAmount","@TotalQty", "@TotalItem", "@LastModify", "@TransactionID" };
                        values = new object[] { GlobalFunction.GetDateTimeWithoutMiliSecond(dtpSaleDate.Value), txtCustomerName.Text, txtRemarks.Text.Trim(), Convert.ToDouble(lblTotalAmount.Text), Convert.ToInt32(lblTotalQuantity.Text), Convert.ToInt32(lblTotalItem.Text), GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now), txtTrasactionID.Text.Trim() };
                        transList.Add(new Transaction(str1, para, values));

                        str1 = "Delete * from SaleMasterDetails where TransactionID=@TransactionID";
                        para = new string[] { "@TransactionID" };
                        values = new object[] { txtTrasactionID.Text.Trim() };
                        transList.Add(new Transaction(str1, para, values));

                        //Save details
                        rowCount = dgvMain.RowCount;
                        for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                        {
                            str1 = "Insert into SaleMasterDetails (TransactionID, ItemCode, Rate,Quantity, Amount, DiscountPerc, Discount, TotalAmount) values (@TransactionID, @ItemCode, @Rate,@Quantity, @Amount, @DiscountPerc, @Discount, @TotalAmount)";
                            para = new string[] { "@TransactionID", "@ItemCode", "@Rate", "@Quantity", "@Amount", "@DiscountPerc", "@Discount", "@TotalAmount" };
                            values = new object[] { txtTrasactionID.Text.Trim(), Convert.ToString(dgvMain.Rows[rowIndex].Cells[Code].Value), Convert.ToDouble(dgvMain.Rows[rowIndex].Cells[Rate].Value), Convert.ToInt32(dgvMain.Rows[rowIndex].Cells[Quantity].Value), Convert.ToDouble(dgvMain.Rows[rowIndex].Cells[Amount].Value), Convert.ToDouble(dgvMain.Rows[rowIndex].Cells[DiscountPercentage].Value), Convert.ToDouble(dgvMain.Rows[rowIndex].Cells[Discount].Value), Convert.ToDouble(dgvMain.Rows[rowIndex].Cells[TotalAmount].Value) };

                            transList.Add(new Transaction(str1, para, values));
                        }

                        obj = DBService.ExecuteTransaction(transList);
                        if (obj != null)
                        {
                            IsEdit = false;
                            ControlStatus(true);
                            //MessageBox.Show("Data is updated succesfully");
                            DisplayData(txtTrasactionID.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }

                        
                    //}

                }
                else
                {
                    ControlStatus(true);
                    IsAdd = false;
                    IsEdit = false;
                }
                               

            }
            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }

        }

        public void DisplayData(string transactionID = "-1")
        {
            DataTable dt = new DataTable();
            string str;
            int rowCount;
            

            try
            {
                ClearControl();

                if (transactionID == "-1")// show last record by default
                {
                    str = "SELECT SaleMaster.TransactionID, SaleMaster.SaleDate, SaleMaster.CustomerName, SaleMaster.Remarks, SaleMaster.TotalAmount, SaleMaster.TotalQty, SaleMaster.TotalItem,  SaleMasterDetails.ItemCode, FoodItemMaster.FoodName, SaleMasterDetails.Rate, SaleMasterDetails.Quantity, SaleMasterDetails.Amount, SaleMasterDetails.DiscountPerc, SaleMasterDetails.Discount, SaleMasterDetails.TotalAmount FROM (SaleMaster INNER JOIN SaleMasterDetails ON SaleMaster.TransactionID = SaleMasterDetails.TransactionID) INNER JOIN FoodItemMaster ON SaleMasterDetails.ItemCode = FoodItemMaster.Code WHERE (SaleMaster.TransactionID=(SELECT MAX(TransactionID) FROM SaleMaster)) Order by SaleMasterDetails.ID";
                    
                }
                else // show data according to transactionID
                {

                    str = "SELECT SaleMaster.TransactionID, SaleMaster.SaleDate, SaleMaster.CustomerName, SaleMaster.Remarks, SaleMaster.TotalAmount, SaleMaster.TotalQty, SaleMaster.TotalItem,  SaleMasterDetails.ItemCode, FoodItemMaster.FoodName, SaleMasterDetails.Rate, SaleMasterDetails.Quantity, SaleMasterDetails.Amount, SaleMasterDetails.DiscountPerc, SaleMasterDetails.Discount, SaleMasterDetails.TotalAmount FROM (SaleMaster INNER JOIN SaleMasterDetails ON SaleMaster.TransactionID = SaleMasterDetails.TransactionID) INNER JOIN FoodItemMaster ON SaleMasterDetails.ItemCode = FoodItemMaster.Code WHERE  (SaleMaster.TransactionID='" + transactionID + "') Order by SaleMasterDetails.ID";
                    
                }

                dt = DBService.GetDataTable(str);
                rowCount = dt.Rows.Count;
                if (rowCount > 0)
                {

                    txtTrasactionID.Text = Convert.ToString(dt.Rows[0]["TransactionID"]);
                    dtpSaleDate.Value = Convert.IsDBNull(dt.Rows[0]["SaleDate"]) ? DateTime.Now.Date : ((System.DateTime)(dt.Rows[0]["SaleDate"]));
                    txtCustomerName.Text = Convert.ToString(dt.Rows[0]["CustomerName"]);
                    txtRemarks.Text = Convert.ToString(dt.Rows[0]["Remarks"]);
                    lblTotalAmount.Text = Convert.ToString(dt.Rows[0]["SaleMaster.TotalAmount"]);
                    lblTotalQuantity.Text = Convert.ToString(dt.Rows[0]["TotalQty"]);
                    lblTotalItem.Text = Convert.ToString(dt.Rows[0]["TotalItem"]);
                    
                    

                    for (int i = 0; i < rowCount; i++)
                    {

                        //share details                        
                        //dgvMain.RowCount += 1;
                        dgvMain.RowCount = i + 1;
                        dgvMain.Rows[i].Cells[SNo].Value = i + 1;
                        dgvMain.Rows[i].Cells[Code].Value = Convert.ToString(dt.Rows[i]["ItemCode"]);
                        dgvMain.Rows[i].Cells[ItemName].Value = Convert.ToString(dt.Rows[i]["FoodName"]);
                        dgvMain.Rows[i].Cells[Rate].Value = Convert.ToDouble(dt.Rows[i]["Rate"]);

                        dgvMain.Rows[i].Cells[Quantity].Value = Convert.IsDBNull(dt.Rows[i]["Quantity"]) ? 0 : dt.Rows[i]["Quantity"];
                        dgvMain.Rows[i].Cells[Amount].Value = Convert.ToDouble(dt.Rows[i]["Amount"]);
                        dgvMain.Rows[i].Cells[DiscountPercentage].Value = Convert.ToDouble(dt.Rows[i]["DiscountPerc"]);
                        dgvMain.Rows[i].Cells[Discount].Value = Convert.ToDouble(dt.Rows[i]["Discount"]);
                        dgvMain.Rows[i].Cells[TotalAmount].Value = Convert.ToDouble(dt.Rows[i]["SaleMasterDetails.TotalAmount"]);

                        
                    }

                }
                else
                {
                    dgvMain.RowCount = 0;
                }

               ControlStatus(true);

                /*Calculatio today sale*/
               string fromDate = DateTime.Now.ToString("MM/dd/yyyy");
               string toDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");

               str = "SELECT SUM(TotalAmount) as TodaySale  FROM SaleMaster WHERE (SaleDate>=#" + fromDate + "# And SaleDate<=#" + toDate + "#)";

               dt = DBService.GetDataTable(str);
               rowCount = dt.Rows.Count;
               if (rowCount > 0)
               {
                   lblTodaySale.Text = Convert.ToString(dt.Rows[0]["TodaySale"]);
               }                
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        }

    
        private void CalculateTotalAmount()
        {
            double totalAmount = 0.0;
            int totalQuantity = 0;

            if (IsAdd || IsEdit)
            {
                for (int i = 0; i < dgvMain.RowCount; i++)
                {

                                        
                    dgvMain.Rows[i].Cells[Amount].Value = Math.Round(Convert.ToDouble(dgvMain.Rows[i].Cells[Rate].Value) * Convert.ToDouble(dgvMain.Rows[i].Cells[Quantity].Value));

                    dgvMain.Rows[i].Cells[Discount].Value = Math.Round((Convert.ToDouble(dgvMain.Rows[i].Cells[Amount].Value) * Convert.ToDouble(dgvMain.Rows[i].Cells[DiscountPercentage].Value)) / 100);

                    dgvMain.Rows[i].Cells[TotalAmount].Value = Math.Round(Convert.ToDouble(dgvMain.Rows[i].Cells[Amount].Value) - Convert.ToDouble(dgvMain.Rows[i].Cells[Discount].Value));
                    totalAmount = totalAmount + Convert.ToDouble(dgvMain.Rows[i].Cells[TotalAmount].Value);
                    totalQuantity = totalQuantity + Convert.ToInt32(dgvMain.Rows[i].Cells[Quantity].Value);
                }
            
            }
            lblTotalAmount.Text = Convert.ToString(totalAmount);
            lblTotalQuantity.Text =Convert.ToString( totalQuantity);
            lblTotalItem.Text = Convert.ToString(dgvMain.RowCount);
                        
        }

        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if ((IsAdd || IsEdit))
            {
                if (colIndex == Quantity || colIndex == DiscountPercentage)
                {
                    CalculateTotalAmount();

                }
            }
        }

        private void dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if ((IsAdd || IsEdit))
            {
                // Qunatiy and Discount%,
                if (colIndex == Quantity || colIndex == DiscountPercentage)
                {
                    dgvMain.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
                else
                {
                    dgvMain.EditMode = DataGridViewEditMode.EditProgrammatically;
                }

            }
        }

        private bool _defaultChkstatus = true;
        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();
            try
            {
                if (IsAdd || IsEdit)
                {
                    if (e.ColumnIndex == CheckBoxColumn)
                    {
                        if (rowIndex != -1) // check/uncheck perticuler record
                        {
                            chk = (DataGridViewCheckBoxCell)dgvMain.CurrentCell;
                            if (Convert.ToBoolean(chk.Value))
                            {
                                chk.Value = false;
                            }
                            else
                            {
                                chk.Value = true;
                            }
                        }
                        else //check/uncheck all records header click
                        {
                            if (_defaultChkstatus)
                            {
                                SetActiveAll(dgvMain, CheckBoxColumn, false);
                                _defaultChkstatus = false;
                            }
                            else
                            {
                                SetActiveAll(dgvMain, CheckBoxColumn, true);
                                _defaultChkstatus = true;
                            }
                        }
                    }
                
                }
                

               
            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        }

        private void SetActiveAll(DataGridView dgv, int chkColumnIndex, bool isActive)
        {

            int rowcount = dgv.RowCount;
            DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();
            try
            {
                for (int i = 0; i < rowcount; i++)
                {
                    chk = (DataGridViewCheckBoxCell)dgv.Rows[i].Cells[chkColumnIndex];
                    chk.Value = isActive;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        }
      
        private void cmdRemoveItem_Click(object sender, EventArgs e)
        {
            if (IsAdd || IsEdit)
            {
                int rowcount = dgvMain.RowCount;
                DataGridViewCheckBoxCell chk = new DataGridViewCheckBoxCell();
                try
                {
                    for (int i = 0; i < rowcount; )
                    {
                        chk = (DataGridViewCheckBoxCell)dgvMain.Rows[i].Cells[CheckBoxColumn];
                        if (chk.Value != null)
                        {
                            if ((bool)chk.Value == true)
                            {
                                dgvMain.Rows.RemoveAt(i);
                                i = 0;
                                rowcount = dgvMain.RowCount;
                            }
                            else
                            {
                                i++;
                            }

                        }
                        else
                        {
                            i++;
                        }
                        
                    }
                    SetDataGridViewSerialNo();
                    CalculateTotalAmount();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
                }
            
            }
        }

        private void SetDataGridViewSerialNo()
        {

            for (int i = 0; i < dgvMain.RowCount; i++)
            {                                
                dgvMain.Rows[i].Cells[SNo].Value = i + 1;
            }
        }

        private void cmdSearchGrid_Click(object sender, EventArgs e)
        {
            DisplayTrasactionDetails(true);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {            
                DisplayTrasactionDetails();
                pnlMain.SendToBack();
                pnlSearch.BringToFront();            
        }

        private void DisplayTrasactionDetails(bool dateFilter = false)
        {

            DataTable dt = new DataTable();
            string str;
            int rowCount;
            double totalSearchSale = 0.0;

            string fromDate = dtpFromDate.Value.ToString("MM/dd/yyyy");
            string toDate = dtpToDate.Value.AddDays(1).ToString("MM/dd/yyyy"); 

            try
            {

                if (dateFilter)// filder by date
                {
                     
                     str = "SELECT TransactionID, CustomerName, TotalAmount, SaleDate, Remarks FROM SaleMaster WHERE (SaleDate>=#" + fromDate + "# And SaleDate<=#" + toDate + "#) ORDER BY TransactionID";

                }
                else // Default
                {
                    str = "SELECT TransactionID, CustomerName, TotalAmount, SaleDate, Remarks FROM SaleMaster ORDER BY TransactionID";
                }

                dt = DBService.GetDataTable(str);
                rowCount = dt.Rows.Count;
                if (rowCount > 0)
                {

                   

                    for (int i = 0; i < rowCount; i++)
                    {
                        
                        //share details                        
                        //dgvSearch.RowCount += 1;
                        dgvSearch.RowCount = i + 1;
                        dgvSearch.Rows[i].Cells[0].Value = i + 1;
                        dgvSearch.Rows[i].Cells[1].Value = Convert.ToString(dt.Rows[i]["TransactionID"]);
                        dgvSearch.Rows[i].Cells[2].Value = Convert.ToString(dt.Rows[i]["CustomerName"]);
                        dgvSearch.Rows[i].Cells[3].Value = Convert.ToDouble(dt.Rows[i]["TotalAmount"]);

                        dgvSearch.Rows[i].Cells[4].Value = Convert.IsDBNull(dt.Rows[i]["SaleDate"]) ? DateTime.Now.Date : ((System.DateTime)(dt.Rows[i]["SaleDate"]));
                        
                        dgvSearch.Rows[i].Cells[5].Value = Convert.ToString(dt.Rows[i]["Remarks"]);

                        totalSearchSale = totalSearchSale + Convert.ToDouble(dgvSearch.Rows[i].Cells[3].Value);
                    }

                }
                else
                {
                    dgvSearch.RowCount = 0;
                }
                lblTotalSearchSale.Text = Convert.ToString(totalSearchSale);
            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            pnlSearch.SendToBack();
            pnlMain.BringToFront();
        }

      
        private void dgvSearch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string transID = Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells[1].Value);
                DisplayData(transID);
                pnlSearch.SendToBack();
                pnlMain.BringToFront();
            }            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                DisplayData();
            }
            else if(IsEdit)
            {
                DisplayData(txtTrasactionID.Text);
            }
            IsEdit = false;
            IsAdd = false;
            ControlStatus(true);
        }








    }


    #region CustomClass
    public class FoodItem
    {
        public string Code { get; set; }
        public string FoodName { get; set; }
        public double Price { get; set; }
        public string UnitName { get; set; }        
        public double DiscountPerc { get; set; }


        public override string ToString()
        {
            return FoodName + "[" + Convert.ToString(Price) + "]";

            // return base.ToString();
        }

    }

    public class FoodCategory
    {
        public string CategoryName { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }

    }

    #endregion
}
