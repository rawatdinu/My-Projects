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
    public partial class frmStateMaster : Form
    {
        private frmStateDetails frmInterface;

        public string StateCode { get; set; }
        public string StateName { get; set; }
        public int IsLookup = 0; // if 0- Master, 1- Lookup

        public bool IsAdd = false;
        public bool IsEdit = false;
        

        public frmStateMaster()
        {
            InitializeComponent();
        }

        private void DesignListView()
        {
            lvwState.Columns.Add("State Code", 80, HorizontalAlignment.Left);
            lvwState.Columns.Add("State Name", 200);

            //lvwState.Columns.Add("Address", 120);
            //lvwState.Columns.Add("Email", 100);
            //lvwState.Columns.Add("Phone", 80);

            lvwState.FullRowSelect = true;
            lvwState.View = View.Details;
            //lvwState.GridLines = true;


            //listView1.SmallImageList = _smallImageList;
            //listView1.LargeImageList = _smallImageList;
            //listView1.StateImageList = _mediumImageList;


        }
        private void DisplayStateList()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;


            try
            {
                str = "SELECT StateCode, StateName FROM StateMaster ORDER BY StateCode";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                lvwState.Items.Clear();

                if (RecNo > 0)
                {
                    for(int i=0;i<RecNo;i++)
                    {
                        ListViewItem lvi = new ListViewItem(Convert.ToString(dt.Rows[i]["StateCode"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["StateName"]));
                        lvwState.Items.Add(lvi);
                    }
                    //select first recode by default
                    lvwState.Items[0].Selected = true;
                    lvwState.Items[0].Focused = true;                    
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
                frmInterface = new frmStateDetails();

            if (IsEdit)
            {
                
                frmInterface.IsEdit = true;
                frmInterface.StateCode = StateCode;
                frmInterface.StateName = StateName;
                
            }
            else if(IsAdd)
            {
                frmInterface.IsAdd = true;
                frmInterface.StateCode = StateCode;
                frmInterface.StateName = StateName;
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
                DisplayStateList();
            }
            else
            {
                //textBox4.Text = "";
            }
        }

        private void frmStateMaster_Load(object sender, EventArgs e)
        {
            
            DesignListView();
            DisplayStateList();
            SetProperty();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            IsAdd = true;
            IsEdit = false;
            StateCode = GlobalFunction.GetUniqueCode("StateMaster");
            StateName = "";
            ProcessInterface();    
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
           
            if (lvwState.SelectedItems != null)
            {
                IsEdit = true;
                IsAdd = false;

                string str = "";

                ListViewItem lvi = lvwState.SelectedItems[0];
                StateCode = lvi.SubItems[0].Text;
                StateName = lvi.SubItems[1].Text;

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


            if (lvwState.SelectedItems != null)
            {
               
                
                ListViewItem lvi = lvwState.SelectedItems[0];
                StateCode = lvi.SubItems[0].Text;
                StateName = lvi.SubItems[1].Text;

                DialogResult dr = MessageBox.Show("Do You Want to Delete '" + StateCode + "  " + StateName + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dr == DialogResult.OK)
                {
                    str1 = "Delete * From StateMaster where StateCode = @StateCode";
                    para = new string[] { "@StateCode" };
                    values = new object[] { StateCode };

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
                        DisplayStateList();
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

            if (lvwState.SelectedItems.Count > 0)
            {
                
                ListViewItem lvi = lvwState.SelectedItems[0];
                StateCode = lvi.SubItems[0].Text;
                StateName = lvi.SubItems[1].Text;

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
