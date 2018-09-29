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
        private const int SNoWidth = 40;
        private const int CodeWidth = 60;
        private const int ItemNameWidth = 300;
        private const int RateWidth = 60;
        private const int QuantityWidth = 40;
        private const int AmountWidth = 60;
        private const int DiscountPercentageWidth = 60;
        private const int DiscountWidth = 60;
        private const int TotalAmountWidth = 80;
        private const int CheckBoxColumnWidth = 70;
        
        public frmSale()
        {
            InitializeComponent();
        }

        private void frmSale_Load(object sender, EventArgs e)
        {
            DesignListView();
            FillFoodCategory();
            DesignMainGrid();
            DesignSearchGrid();
            ClearControl();
            ControlStatus(true);
            DisplayData();

        }

        private void DesignListView()
        {

            //VEg
            lvwVegFoodItem.Columns.Add("Code", 60, HorizontalAlignment.Left);
            lvwVegFoodItem.Columns.Add("Food Name", 250);
            lvwVegFoodItem.Columns.Add("Price", 70);
            lvwVegFoodItem.Columns.Add("Unit", 70);
            lvwVegFoodItem.Columns.Add("Discount(%)", 70);
            


            lvwVegFoodItem.FullRowSelect = true;
            lvwVegFoodItem.View = View.SmallIcon;
            //lvwState.GridLines = true;


            //listView1.SmallImageList = _smallImageList;
            //listView1.LargeImageList = _smallImageList;
            //listView1.StateImageList = _mediumImageList;

            //Non-Veg
            lvwNonVegFoodItem.Columns.Add("Code", 60, HorizontalAlignment.Left);
            lvwNonVegFoodItem.Columns.Add("Food Name", 250);
            lvwNonVegFoodItem.Columns.Add("Price", 70);
            lvwNonVegFoodItem.Columns.Add("Unit", 70);
            lvwNonVegFoodItem.Columns.Add("Discount(%)", 70);
            

            lvwNonVegFoodItem.FullRowSelect = true;
            lvwNonVegFoodItem.View = View.SmallIcon;
        }

        private void FillFoodCategory()
        {
            cboFoodCategory.DataSource = null;
            cboFoodCategory.Items.Clear();

            DataTable dt = new DataTable();
            string str;
            int RecNo;
            try
            {

                str = "SELECT Code, CategoryName FROM FoodCategory order by Code";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                Dictionary<string, string> test = new Dictionary<string, string>();
                test.Add("All", "All");
                
                for(int i=0; i < RecNo; i++)
                {
                    test.Add(Convert.ToString(dt.Rows[i]["Code"]), Convert.ToString(dt.Rows[i]["CategoryName"]));
                }

                cboFoodCategory.DataSource = new BindingSource(test, null);
                cboFoodCategory.DisplayMember = "Value";
                cboFoodCategory.ValueMember = "Key";
                cboFoodCategory.SelectedIndex = 0;
            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }

            
        
        }

        private void DisplayFoodItemList(string foodCategory = "-1")
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;
            
            

            try
            {
                //Veg-List
                if (foodCategory == "-1")
                {
                    str = "SELECT Code, FoodName, Price, UnitName, Discount, FoodType, FoodCategory FROM FoodItemMaster WHERE (FoodType='TYP01' or FoodType='') Order by Code";
                    
                }
                else
                {
                    str = "SELECT Code, FoodName, Price, UnitName, Discount, FoodType, FoodCategory FROM FoodItemMaster where (FoodType='TYP01' or FoodType='') and FoodCategory='" + foodCategory + "' order by Code";
                }
                
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                lvwVegFoodItem.Items.Clear();

                if (RecNo > 0)
                {
                    for (int i = 0; i < RecNo; i++)
                    {
                        ListViewItem lvi = new ListViewItem(Convert.ToString(dt.Rows[i]["Code"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["FoodName"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["Price"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["UnitName"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["Discount"]));
                        
                        lvwVegFoodItem.Items.Add(lvi);
                    }
                    //select first record by default
                    lvwVegFoodItem.Items[0].Selected = true;
                    lvwVegFoodItem.Items[0].Focused = true;
                }


                //Non-Veg List
                
                if (foodCategory == "-1")
                {
                    str = "SELECT Code, FoodName, Price, UnitName, Discount, FoodType, FoodCategory FROM FoodItemMaster where (FoodType='TYP02' or FoodType='') order by Code";
                }
                else
                {
                    str = "SELECT Code, FoodName, Price, UnitName, Discount, FoodType, FoodCategory FROM FoodItemMaster where (FoodType='TYP02' or FoodType='') and FoodCategory='" + foodCategory + "' order by Code";
                }

                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                lvwNonVegFoodItem.Items.Clear();

                if (RecNo > 0)
                {
                    for (int i = 0; i < RecNo; i++)
                    {
                        ListViewItem lvi = new ListViewItem(Convert.ToString(dt.Rows[i]["Code"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["FoodName"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["Price"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["UnitName"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["Discount"]));
                        
                        lvwNonVegFoodItem.Items.Add(lvi);
                    }
                    //select first record by default
                    lvwNonVegFoodItem.Items[0].Selected = true;
                    lvwNonVegFoodItem.Items[0].Focused = true;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }

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
            txtTotalAmount.ReadOnly = status;

            dtpSaleDate.Enabled = !(status);

        }

        private void ClearControl()
        {

            txtTrasactionID.Text = "";
            dtpSaleDate.Value = DateTime.Now;
                        
            txtRemarks.Text = "";
            txtTotalAmount.Text = "";
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

        private void cboFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedValue = "";

            if (cboFoodCategory.SelectedIndex != -1)
            {
                selectedValue = ((KeyValuePair<string, string>)cboFoodCategory.SelectedItem).Key;
                if (cboFoodCategory.SelectedIndex == 0)
                {
                    DisplayFoodItemList();
                }
                else
                {
                    DisplayFoodItemList(selectedValue);            
                }
               
            }

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
                    DialogResult dr = MessageBox.Show("Do you want to save?", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.OK)
                    {
                        //Get Unique ID
                        txtTrasactionID.Text = GlobalFunction.GetUniqueCode("SaleMaster");

                        str1 = "Insert into SaleMaster (TransactionID, SaleDate, CustomerName, Remarks, TotalAmount, CreatedOn) values (@TransactionID, @SaleDate, @CustomerName, @Remarks, @TotalAmount, @CreatedOn)";
                        para = new string[] { "@TransactionID", "@SaleDate", "@CustomerName", "@Remarks", "@TotalAmount", "@CreatedOn" };
                        values = new object[] { txtTrasactionID.Text.Trim(), GlobalFunction.GetDateTimeWithoutMiliSecond(dtpSaleDate.Value), txtCustomerName.Text, txtRemarks.Text.Trim(),Convert.ToDouble(txtTotalAmount.Text),GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now) };
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
                            MessageBox.Show("Data is saved succesfully");
                            ControlStatus(true);
                            DisplayData(txtTrasactionID.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }
                    }
                }
                /******************************EDIT*****************************************/
                else if (IsEdit)
                {
                    DialogResult dr = MessageBox.Show("Do you want to update?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {

                        str1 = "Update  SaleMaster set SaleDate=@SaleDate, CustomerName=@CustomerName, Remarks=@Remarks, TotalAmount=@TotalAmount, LastModify=@LastModify Where TransactionID=@TransactionID";
                        para = new string[] { "@SaleDate", "@CustomerName", "@Remarks", "@TotalAmount", "@LastModify", "@TransactionID" };
                        values = new object[] { GlobalFunction.GetDateTimeWithoutMiliSecond(dtpSaleDate.Value), txtCustomerName.Text, txtRemarks.Text.Trim(), Convert.ToDouble(txtTotalAmount.Text), GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now), txtTrasactionID.Text.Trim() };
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
                            MessageBox.Show("Data is updated succesfully");
                            DisplayData(txtTrasactionID.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }

                        
                    }

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
                    str = "SELECT SaleMaster.TransactionID, SaleMaster.SaleDate, SaleMaster.CustomerName, SaleMaster.Remarks, SaleMaster.TotalAmount, SaleMasterDetails.ItemCode, FoodItemMaster.FoodName, SaleMasterDetails.Rate, SaleMasterDetails.Quantity, SaleMasterDetails.Amount, SaleMasterDetails.DiscountPerc, SaleMasterDetails.Discount, SaleMasterDetails.TotalAmount FROM (SaleMaster INNER JOIN SaleMasterDetails ON SaleMaster.TransactionID = SaleMasterDetails.TransactionID) INNER JOIN FoodItemMaster ON SaleMasterDetails.ItemCode = FoodItemMaster.Code WHERE (SaleMaster.TransactionID=(SELECT MAX(TransactionID) FROM SaleMaster))";
                    
                }
                else // show data according to transactionID
                {

                    str = "SELECT SaleMaster.TransactionID, SaleMaster.SaleDate, SaleMaster.CustomerName, SaleMaster.Remarks, SaleMaster.TotalAmount, SaleMasterDetails.ItemCode, FoodItemMaster.FoodName, SaleMasterDetails.Rate, SaleMasterDetails.Quantity, SaleMasterDetails.Amount, SaleMasterDetails.DiscountPerc, SaleMasterDetails.Discount, SaleMasterDetails.TotalAmount FROM (SaleMaster INNER JOIN SaleMasterDetails ON SaleMaster.TransactionID = SaleMasterDetails.TransactionID) INNER JOIN FoodItemMaster ON SaleMasterDetails.ItemCode = FoodItemMaster.Code WHERE  (SaleMaster.TransactionID='" + transactionID + "')";
                    
                }

                dt = DBService.GetDataTable(str);
                rowCount = dt.Rows.Count;
                if (rowCount > 0)
                {

                    txtTrasactionID.Text = Convert.ToString(dt.Rows[0]["TransactionID"]);
                    dtpSaleDate.Value = Convert.IsDBNull(dt.Rows[0]["SaleDate"]) ? DateTime.Now.Date : ((System.DateTime)(dt.Rows[0]["SaleDate"]));
                    txtCustomerName.Text = Convert.ToString(dt.Rows[0]["CustomerName"]);
                    txtRemarks.Text = Convert.ToString(dt.Rows[0]["Remarks"]);
                    txtTotalAmount.Text = Convert.ToString(dt.Rows[0]["SaleMaster.TotalAmount"]);
                    
                    

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
            }

            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message);
            }
        }

        private void lvwVegFoodItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (IsAdd || IsEdit)
            {
                if (lvwVegFoodItem.SelectedItems.Count > 0)
                {
                    if (lvwVegFoodItem.SelectedItems != null)
                    {
                       
                        string str = "";

                        ListViewItem lvi = lvwVegFoodItem.SelectedItems[0];
                        AddFoodItemToGrid(lvi);
                        //CityCode = lvi.SubItems[0].Text;
                        //CityName = lvi.SubItems[1].Text;
                        //ProcessInterface();
                        //foreach (ListViewItem item in lvwState.SelectedItems)
                        //{

                        //    str += item.SubItems[0].Text + "   " + item.SubItems[1].Text + "   " + item.SubItems[2].Text + "\n";
                        //}
                        //str = lvi.SubItems[0].Text + lvi.SubItems[1].Text;
                        //MessageBox.Show(str);
                    }
                }

            }

           
        }

        private void AddFoodItemToGrid(ListViewItem lvi)
        {
            //lvwVegFoodItem.Columns.Add("Code", 80, HorizontalAlignment.Left);
            //lvwVegFoodItem.Columns.Add("Food Name", 300);
            //lvwVegFoodItem.Columns.Add("Price", 80);
            //lvwVegFoodItem.Columns.Add("Unit", 80);
            //lvwVegFoodItem.Columns.Add("Discount(%)", 80);

            int i = dgvMain.RowCount;           
            dgvMain.RowCount = i + 1;

            dgvMain.Rows[i].Cells[SNo].Value = i + 1;
            dgvMain.Rows[i].Cells[Code].Value = Convert.ToString(lvi.SubItems[0].Text);
            dgvMain.Rows[i].Cells[ItemName].Value = Convert.ToString(lvi.SubItems[1].Text);
            dgvMain.Rows[i].Cells[Rate].Value = Convert.ToDouble(lvi.SubItems[2].Text);

            dgvMain.Rows[i].Cells[Quantity].Value = 1;

            dgvMain.Rows[i].Cells[DiscountPercentage].Value = Convert.ToDouble(lvi.SubItems[4].Text);

            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            double totalAmount = 0.0;

            if (IsAdd || IsEdit)
            {
                for (int i = 0; i < dgvMain.RowCount; i++)
                {

                                        
                    dgvMain.Rows[i].Cells[Amount].Value = Math.Round(Convert.ToDouble(dgvMain.Rows[i].Cells[Rate].Value) * Convert.ToDouble(dgvMain.Rows[i].Cells[Quantity].Value));

                    dgvMain.Rows[i].Cells[Discount].Value = Math.Round((Convert.ToDouble(dgvMain.Rows[i].Cells[Amount].Value) * Convert.ToDouble(dgvMain.Rows[i].Cells[DiscountPercentage].Value)) / 100);

                    dgvMain.Rows[i].Cells[TotalAmount].Value = Math.Round(Convert.ToDouble(dgvMain.Rows[i].Cells[Amount].Value) - Convert.ToDouble(dgvMain.Rows[i].Cells[Discount].Value));
                    totalAmount = totalAmount + Convert.ToDouble(dgvMain.Rows[i].Cells[TotalAmount].Value);

                }
            
            }
            txtTotalAmount.Text = Convert.ToString(totalAmount);
                        
        }

        private void lvwNonVegFoodItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (IsAdd || IsEdit)
            {
                if (lvwNonVegFoodItem.SelectedItems.Count > 0)
                {
                    if (lvwNonVegFoodItem.SelectedItems != null)
                    {

                        string str = "";

                        ListViewItem lvi = lvwNonVegFoodItem.SelectedItems[0];
                        AddFoodItemToGrid(lvi);
                        
                    }
                }

            }
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
                    }

                }
                else
                {
                    dgvSearch.RowCount = 0;
                }
                
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
            string transID = Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells[1].Value);
            DisplayData(transID);
            pnlSearch.SendToBack();
            pnlMain.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        




    }
}
