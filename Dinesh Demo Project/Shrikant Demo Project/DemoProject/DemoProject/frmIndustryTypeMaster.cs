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
    public partial class frmIndustryTypeMaster : Form
    {
        private frmIndustryTypeDetails frmInterface;

        public string IndustryCode { get; set; }
        public string IndustryName { get; set; }
        public int IsLookup = 0; // if 0- Master, 1- Lookup

        public bool IsAdd = false;
        public bool IsEdit = false;

        public frmIndustryTypeMaster()
        {
            InitializeComponent();
        }

        private void DesignListView()
        {
            lvwIndustry.Columns.Add("Industry Code", 80, HorizontalAlignment.Left);
            lvwIndustry.Columns.Add("Industry Name", 200);

          

            lvwIndustry.FullRowSelect = true;
            lvwIndustry.View = View.Details;
          


        }
        private void DisplayIndustryList()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;


            try
            {
                str = "SELECT IndustryCode, IndustryName FROM IndustryTypeMaster ORDER BY IndustryCode";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                lvwIndustry.Items.Clear();

                if (RecNo > 0)
                {
                    for (int i = 0; i < RecNo; i++)
                    {
                        ListViewItem lvi = new ListViewItem(Convert.ToString(dt.Rows[i]["IndustryCode"]));
                        lvi.SubItems.Add(Convert.ToString(dt.Rows[i]["IndustryName"]));
                        lvwIndustry.Items.Add(lvi);
                    }
                    //select first recode by default
                    lvwIndustry.Items[0].Selected = true;
                    lvwIndustry.Items[0].Focused = true;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SetProperty()
        {

          
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
                frmInterface = new frmIndustryTypeDetails();

            if (IsEdit)
            {

                frmInterface.IsEdit = true;
                frmInterface.IndustryCode = IndustryCode;
                frmInterface.IndustryName = IndustryName;

            }
            else if (IsAdd)
            {
                frmInterface.IsAdd = true;
                frmInterface.IndustryCode = IndustryCode;
                frmInterface.IndustryName = IndustryName;
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
                DisplayIndustryList();
            }
            else
            {
                //textBox4.Text = "";
            }
        }

        private void frmIndustryTypeMaster_Load(object sender, EventArgs e)
        {
            DesignListView();
            DisplayIndustryList();
            SetProperty();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            IsAdd = true;
            IsEdit = false;
            IndustryCode = GlobalFunction.GetUniqueCode("IndustryTypeMaster");
            IndustryName = "";
            ProcessInterface();  
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvwIndustry.SelectedItems.Count > 0)
            {
                IsEdit = true;
                IsAdd = false;

                string str = "";

                ListViewItem lvi = lvwIndustry.SelectedItems[0];
                IndustryCode = lvi.SubItems[0].Text;
                IndustryName = lvi.SubItems[1].Text;

                ProcessInterface();
               
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string[] para;
            object[] values;
            string str1;

            object obj;


            if (lvwIndustry.SelectedItems.Count > 0)
            {


                ListViewItem lvi = lvwIndustry.SelectedItems[0];
                IndustryCode = lvi.SubItems[0].Text;
                IndustryName = lvi.SubItems[1].Text;

                DialogResult dr = MessageBox.Show("Do You Want to Delete '" + IndustryCode + "  " + IndustryName + "'", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dr == DialogResult.OK)
                {
                    str1 = "Delete * From IndustryTypeMaster where IndustryCode = @IndustryCode";
                    para = new string[] { "@IndustryCode" };
                    values = new object[] { IndustryCode };

                   

                    obj = DBService.ExecuteNonQuerry(str1, para, values);
                    if (obj != null)
                    {
                        DisplayIndustryList();
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
            if (lvwIndustry.SelectedItems.Count > 0)
            {

                ListViewItem lvi = lvwIndustry.SelectedItems[0];
                IndustryCode = lvi.SubItems[0].Text;
                IndustryName = lvi.SubItems[1].Text;

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
