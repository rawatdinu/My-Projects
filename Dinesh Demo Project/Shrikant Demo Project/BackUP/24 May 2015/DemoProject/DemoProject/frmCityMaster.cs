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
    public partial class frmCityMaster : Form
    {

        private frmCityDetail frmInterface;

        public string CityCode { get; set; }
        public string CityName { get; set; }

        
        public string StateName { get; set; }

        
        
        

        public int IsLookup = 0; // if 0- Master, 1- Lookup

        public bool IsAdd = false;
        public bool IsEdit = false;


        private void DesignListView()
        {
            lvwCity.Columns.Add("City Code", 80, HorizontalAlignment.Left);
            lvwCity.Columns.Add("City Name", 150,HorizontalAlignment.Left);
            lvwCity.Columns.Add("State Name", 150, HorizontalAlignment.Left);

          

            lvwCity.FullRowSelect = true;
            lvwCity.View = View.Details;
            //lvwState.GridLines = true;


            //listView1.SmallImageList = _smallImageList;
            //listView1.LargeImageList = _smallImageList;
            //listView1.StateImageList = _mediumImageList;

        }

        private void DisplayCityList()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;


            try
            {
                str = "SELECT CityMaster.CityCode, CityMaster.CityName, CityMaster.StateCode, StateMaster.StateName FROM CityMaster INNER JOIN StateMaster ON CityMaster.StateCode = StateMaster.StateCode";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                lvwCity.Items.Clear();

                if (RecNo > 0)
                {
                    for (int i = 0; i < RecNo; i++)
                    {
                        ListViewItem lvi = new ListViewItem(Convert.ToString(dt.Rows[i]["CityCode"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["CityName"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["StateName"]));
                        lvwCity.Items.Add(lvi);
                    }
                    //select first recode by default
                    lvwCity.Items[0].Selected = true;
                    lvwCity.Items[0].Focused = true;
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

        private void ProcessInterface()
        {
            LoadInterface();

            ShowForm();

            UnloadInterface();

        }

        private void LoadInterface()
        {
            if (frmInterface == null)
                frmInterface = new frmCityDetail();

            if (IsEdit)
            {

                frmInterface.IsEdit = true;
                frmInterface.CityCode = CityCode;
               

            }
            else if (IsAdd)
            {
                frmInterface.IsAdd = true;
                frmInterface.CityCode = CityCode;              
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
                DisplayCityList();

            }
            else
            {
                //textBox4.Text = "";
            }
        }

        public frmCityMaster()
        {
            InitializeComponent();
        }

        private void frmCityMaster_Load(object sender, EventArgs e)
        {
            DesignListView();
            DisplayCityList();
            SetProperty();

        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            IsAdd = true;
            IsEdit = false;
            CityCode = GlobalFunction.GetUniqueCode("CityMaster");
            CityName = "";
           

            ProcessInterface();  
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
           if (lvwCity.SelectedItems.Count > 0)
          {
              if (lvwCity.SelectedItems != null)
              {
                  IsEdit = true;
                  IsAdd = false;

                  string str = "";

                  ListViewItem lvi = lvwCity.SelectedItems[0];
                  CityCode = lvi.SubItems[0].Text;
                  CityName = lvi.SubItems[1].Text;
                  ProcessInterface();
                  //foreach (ListViewItem item in lvwState.SelectedItems)
                  //{

                  //    str += item.SubItems[0].Text + "   " + item.SubItems[1].Text + "   " + item.SubItems[2].Text + "\n";
                  //}

                  //MessageBox.Show(str);
              }
          }
            
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string[] para;
            object[] values;
            string str1;

            object obj;

            if (lvwCity.SelectedItems.Count > 0)
            {
                if (lvwCity.SelectedItems != null)
                {


                    ListViewItem lvi = lvwCity.SelectedItems[0];
                    CityCode = lvi.SubItems[0].Text;
                    CityName = lvi.SubItems[1].Text;

                    DialogResult dr = MessageBox.Show("Do You Want to Delete '" + CityCode + "  " + CityName + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {
                        str1 = "Delete * From CityMaster where CityCode = @CityCode";
                        para = new string[] { "@CityCode" };
                        values = new object[] { CityCode };

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
                            DisplayCityList();
                        }
                        else
                        {
                            MessageBox.Show("Error Occurs", "ERROR");
                        }
                    }
                }            
            }                        
        }




    }
}
