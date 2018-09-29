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
    public partial class frmFoodItemDetails : Form
    {

        public string Code { get; set; }
        public string FoodName { get; set; }

        public bool IsAdd = false;
        public bool IsEdit = false;

        private string _FoodTypeID = "";
        private string _FoodCategoryID = "";

        
        
        public frmFoodItemDetails()
        {
            InitializeComponent();
        }

        private void SetProperty()
        {

            Code = txtCode.Text;
            FoodName = txtFoodName.Text;
          
        }

        private void GetProperty()
        {
            txtCode.Text = Code;
            txtFoodName.Text = FoodName;            
        }

        private void ClearControls()
        {
            txtCode.Text = "";
            txtFoodName.Text = "";
            txtPrice.Text = "";
            txtUnitName.Text = "";
            txtDiscount.Text = "";            
        }

        private void frmFoodItemDetails_Load(object sender, EventArgs e)
        {

            GetProperty();
            FillFoodType();
            FillFoodCategory();
            if (IsEdit)
            {
                Display(Code);
            }
        }

        private void FillFoodType()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;
            try
            {
                str = "SELECT Code, FoodTypeName FROM FoodType order by Code";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                if (RecNo > 0)
                {
                    cboFoodType.DataSource = dt;
                    cboFoodType.DisplayMember = "FoodTypeName";
                    cboFoodType.ValueMember = "Code";
                    cboFoodType.SelectedIndex = -1;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFoodCategory()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;
            try
            {

                str = "SELECT Code, CategoryName FROM FoodCategory order by Code";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                if (RecNo > 0)
                {
                    cboFoodCategory.DataSource = dt;
                    cboFoodCategory.DisplayMember = "CategoryName";
                    cboFoodCategory.ValueMember = "Code";
                    cboFoodCategory.SelectedIndex = -1;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void Display(string code)
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;

            string foodtype = "";
            string foodcategory = "";

            try
            {
                str = "SELECT Code, FoodName, Price, UnitName, Discount, FoodType, FoodCategory FROM FoodItemMaster Where Code ='" + code + "'";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                if (RecNo > 0)
                {
                    Code = txtCode.Text = Convert.ToString(dt.Rows[0]["Code"]);
                    txtFoodName.Text = Convert.ToString(dt.Rows[0]["FoodName"]);
                    txtPrice.Text = Convert.ToString(dt.Rows[0]["Price"]); ;
                    txtUnitName.Text = Convert.ToString(dt.Rows[0]["UnitName"]); 
                    txtDiscount.Text = Convert.ToString(dt.Rows[0]["Discount"]);
                    foodtype = Convert.ToString(dt.Rows[0]["FoodType"]).Trim();
                    foodcategory = Convert.ToString(dt.Rows[0]["FoodCategory"]).Trim();

                    if (foodtype == "")
                    {
                        cboFoodType.SelectedIndex = -1;
                    }
                    else
                    {
                        cboFoodType.SelectedValue = foodtype;
                    }

                    if (foodcategory == "")
                    {
                        cboFoodCategory.SelectedIndex = -1;
                    }
                    else
                    {
                        cboFoodCategory.SelectedValue = foodcategory;
                    }


                    txtFoodName.Focus();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SetProperty();
            Save();
            this.DialogResult = DialogResult.OK;

        }

        private void Save()
        {

            string[] para;
            object[] values;
            string str1;

            List<Transaction> transList = new List<Transaction>();

            object obj;

            try
            {
                if (IsAdd)
                {
                    DialogResult dr = MessageBox.Show("Do You Want to Save Data ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {


                        Code = GlobalFunction.GetUniqueCode("FoodItemMaster");

                        			
                        /*Master Table**/
                        //str1 = "INSERT INTO ShareMaster(ShareHolderName,Address,PhoneNo,IsActive,CreatedOn) VALUES (@ShareHolderName,@Address,@PhoneNo,@IsActive,@CreatedOn)";
                        str1 = "INSERT INTO FoodItemMaster(Code, FoodName, Price, UnitName, Discount, FoodType, FoodCategory, CreatedOn) VALUES (@Code, @FoodName, @Price, @UnitName, @Discount, @FoodType, @FoodCategory, @CreatedOn)";

                        para = new string[] { "@Code", "@FoodName", "@Price", "@UnitName", "@Discount",  "@FoodType", "@FoodCategory","@CreatedOn" };
                        values = new object[] { Code, FoodName, Convert.ToDouble(txtPrice.Text), txtUnitName.Text, Convert.ToDouble(txtDiscount.Text), Convert.ToString(cboFoodType.SelectedValue), Convert.ToString(cboFoodCategory.SelectedValue),GlobalFunction.GetDateTimeWithoutMiliSecond(System.DateTime.Now) };

                        transList.Add(new Transaction(str1, para, values));


                        // UPdate counter
                        str1 = "Update UniqueCodeMaster set CurrentNo=CurrentNo + IncrementBy where TableName='FoodItemMaster'";
                        para = new string[] { };
                        values = new object[] { };

                        transList.Add(new Transaction(str1, para, values));

                        obj = DBService.ExecuteTransaction(transList);
                        if (obj != null)
                        {
                            IsEdit = false;
                            //MessageBox.Show("Record saved succesfully");
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
                    DialogResult dr = MessageBox.Show("Do You Want to Update '" + txtCode.Text + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {

                        str1 = "Update FoodItemMaster set FoodName=@FoodName, Price=@Price, UnitName = @UnitName, Discount = @Discount, FoodType=@FoodType, FoodCategory=@FoodCategory, LastModify=@LastModify  Where Code = @Code";
                        para = new string[] { "@FoodName", "@Price", "@UnitName", "@Discount", "@FoodType", "@FoodCategory", "@LastModify", "@Code" };
                        values = new object[] { txtFoodName.Text, Convert.ToDouble(txtPrice.Text), txtUnitName.Text, Convert.ToDouble(txtDiscount.Text), Convert.ToString(cboFoodType.SelectedValue), Convert.ToString(cboFoodCategory.SelectedValue), GlobalFunction.GetDateTimeWithoutMiliSecond(DateTime.Now), txtCode.Text };

                        //oleParam = new OleDbParameter[]
                        // {

                        //    new OleDbParameter("@ShareHolderName",GetProperName(txtName.Text)),
                        //     new  OleDbParameter("@Address",txtAddress.Text.Trim()),
                        //     new  OleDbParameter("@PhoneNo",txtPhone.Text.Trim()),
                        //     new  OleDbParameter("@IsActive", 1),
                        //     new  OleDbParameter("@UpdatedOn",DateTime.Now.Date),
                        //     new OleDbParameter("@ID",ID)
                        // };

                        obj = DBService.ExecuteNonQuerry(str1, para, values);
                        if (obj != null)
                        {
                            IsEdit = false;
                            //MessageBox.Show("Share Hoder is Updated succesfully");
                            //ControlStatus(true);
                            //DispayData();
                            //DispayData2();
                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void ClearControl()
        {
            txtFoodName.Text = "";
            txtPrice.Text = "";
            txtUnitName.Text = "";
            txtDiscount.Text = "";
            cboFoodType.SelectedIndex = -1;
            cboFoodCategory.SelectedIndex = -1;
            
        
        }

    }
}
