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
    public partial class frmFoodItemMaster : Form
    {

        private frmFoodItemDetails frmInterface;

        public string Code { get; set; }
        public string FoodName { get; set; }

        public int IsLookup = 0; // if 0- Master, 1- Lookup

        public bool IsAdd = false;
        public bool IsEdit = false;


        public frmFoodItemMaster()
        {
            InitializeComponent();
        }

        private void DesignListView()
        {
            lvwFoodItem.Columns.Add("Code", 80, HorizontalAlignment.Left);
            lvwFoodItem.Columns.Add("Food Name", 240);
            lvwFoodItem.Columns.Add("Price", 80);
            lvwFoodItem.Columns.Add("Unit", 60);
            lvwFoodItem.Columns.Add("Discount(%)", 60);
            lvwFoodItem.Columns.Add("Type", 80);
            lvwFoodItem.Columns.Add("Category", 80);

           
            lvwFoodItem.FullRowSelect = true;
            lvwFoodItem.View = View.Details;
            //lvwState.GridLines = true;


            //listView1.SmallImageList = _smallImageList;
            //listView1.LargeImageList = _smallImageList;
            //listView1.StateImageList = _mediumImageList;


        }

        private void DisplayFoodItemList()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;


            try
            {
                str = "SELECT FoodItemMaster.Code, FoodItemMaster.FoodName, FoodItemMaster.Price, FoodItemMaster.UnitName, FoodItemMaster.Discount, FoodItemMaster.FoodType, FoodItemMaster.FoodCategory, FoodType.FoodTypeName, FoodCategory.CategoryName FROM (FoodType RIGHT JOIN FoodItemMaster ON FoodType.Code = FoodItemMaster.FoodType) LEFT JOIN FoodCategory ON FoodItemMaster.FoodCategory = FoodCategory.Code order by FoodItemMaster.Code";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                lvwFoodItem.Items.Clear();

                if (RecNo > 0)
                {
                    for (int i = 0; i < RecNo; i++)
                    {
                        ListViewItem lvi = new ListViewItem(Convert.ToString(dt.Rows[i]["Code"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["FoodName"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["Price"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["UnitName"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["Discount"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["FoodTypeName"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["CategoryName"]));
                        lvwFoodItem.Items.Add(lvi);
                    }
                    //select first record by default
                    lvwFoodItem.Items[0].Selected = true;
                    lvwFoodItem.Items[0].Focused = true;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SetProperty()
        {

            //if (lvwState.SelectedItems != null)
            //{               
            //   ListViewItem lvi = lvwState.SelectedItems[0];
            //    StateCode = lvi.SubItems[0].Text;
            //    StateName = lvi.SubItems[1].Text;
            //}
        }

        private void GetProperty()
        {


        }

        private void frmFoodItemMaster_Load(object sender, EventArgs e)
        {
            DesignListView();
            DisplayFoodItemList();
            SetProperty();
            if (GlobalFunction.glbUserType == GlobalFunction.NormalUser)
            {
                pnlControl.Enabled = false;                
            }
        }

        private void ProcessInterface()
        {
            LoadInterface();

            ShowForm();

            UnloadInterface();

        }

        private void LoadInterface()
        {
            if (frmInterface == null)
                frmInterface = new frmFoodItemDetails();

            if (IsEdit)
            {

                frmInterface.IsEdit = true;
                frmInterface.Code = Code;
                frmInterface.FoodName = FoodName;

            }
            else if (IsAdd)
            {
                frmInterface.IsAdd = true;
                frmInterface.Code = Code;
                frmInterface.FoodName = FoodName;
            }
        }

        private void UnloadInterface()
        {
            frmInterface.Close();
            frmInterface = null;
        }

        private void ShowForm()
        {
            DialogResult result;
            result = frmInterface.ShowDialog();
            if (result == DialogResult.OK)
            {
                DisplayFoodItemList();
            }
            else
            {
                //textBox4.Text = "";
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            IsAdd = true;
            IsEdit = false;
            Code = GlobalFunction.GetUniqueCode("FoodItemMaster");
            FoodName = "";
            ProcessInterface();  
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvwFoodItem.SelectedItems != null)
            {
                IsEdit = true;
                IsAdd = false;

                string str = "";

                ListViewItem lvi = lvwFoodItem.SelectedItems[0];
                Code = lvi.SubItems[0].Text;
                FoodName = lvi.SubItems[1].Text;

                ProcessInterface();
                //foreach (ListViewItem item in lvwState.SelectedItems)
                //{

                //    str += item.SubItems[0].Text + "   " + item.SubItems[1].Text + "   " + item.SubItems[2].Text + "\n";
                //}

                //MessageBox.Show(str);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string[] para;
            object[] values;
            string str1;

            object obj;


            if (lvwFoodItem.SelectedItems != null)
            {


                ListViewItem lvi = lvwFoodItem.SelectedItems[0];
                Code = lvi.SubItems[0].Text;
                FoodName = lvi.SubItems[1].Text;

                DialogResult dr = MessageBox.Show("Do You Want to Delete '" + Code + "  " + FoodName + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dr == DialogResult.OK)
                {
                    
                    str1 = "Delete * From FoodItemMaster where Code = @Code";
                    para = new string[] { "@Code" };
                    values = new object[] { Code };

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
                        DisplayFoodItemList();
                    }
                    else
                    {
                        MessageBox.Show("Error Occurs", "ERROR");
                    }

                }

            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwFoodItem.SelectedItems.Count > 0)
            {

                ListViewItem lvi = lvwFoodItem.SelectedItems[0];
                Code = lvi.SubItems[0].Text;
                FoodName = lvi.SubItems[1].Text;

                if (IsLookup == 1)
                {
                    this.DialogResult = DialogResult.OK;
                }

            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }
}
