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
    public partial class frmPartyMasterLookup : Form
    {
        public PartyMaster PartyMasterSelected;

        //width
        private const int SNoWidth = 40;
        private const int PartyIDWidth = 60;
        private const int PartyNameWidth = 250;
        private const int PersonNameWidth = 150;
        private const int AddressWidth = 400;
        private const int ContactNoWidth = 60;
        private const int MobileWidth = 60;
        private const int EmailWidth = 60;
        private const int RemarksWidth = 100;
        //Index
        private const int SNoIndex = 0;
        private const int PartyIDIndex = 1;
        private const int PartyNameIndex = 2;
        private const int PersonNameIndex = 3;
        private const int AddressIndex = 4;
        private const int ContactNoIndex = 5;
        private const int MobileIndex = 6;
        private const int EmailIndex = 7;
        private const int RemarksIndex = 8;



        public frmPartyMasterLookup()
        {
            InitializeComponent();
        }
        private void frmPartyMasterLookup_Load(object sender, EventArgs e)
        {
            DesignSearchGrid();
            FillSearchGrid();
        }
        private void DesignSearchGrid()
        {
            dgvSearch.RowCount = 1;
            dgvSearch.ColumnCount = 9;

            dgvSearch.Columns[0].Name = "S.No";
            dgvSearch.Columns[0].Width = SNoWidth;
            dgvSearch.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            dgvSearch.Columns[1].Name = "Party ID";
            dgvSearch.Columns[1].Width = PartyIDWidth;

            dgvSearch.Columns[2].Name = "Party Name";
            dgvSearch.Columns[2].Width = PartyNameWidth;

            dgvSearch.Columns[3].Name = "Person Name";
            dgvSearch.Columns[3].Width = PersonNameWidth;

            dgvSearch.Columns[4].Name = "Address";
            dgvSearch.Columns[4].Width = AddressWidth;

            dgvSearch.Columns[5].Name = "Contact";
            dgvSearch.Columns[5].Width = ContactNoWidth;

            dgvSearch.Columns[6].Name = "Mobile";
            dgvSearch.Columns[6].Width = MobileWidth;

            dgvSearch.Columns[7].Name = "Email";
            dgvSearch.Columns[7].Width = EmailWidth;

            dgvSearch.Columns[8].Name = "Remarks";
            dgvSearch.Columns[8].Width = RemarksWidth;



            dgvSearch.RowHeadersVisible = false;
            dgvSearch.AllowUserToDeleteRows = false;
            dgvSearch.AllowUserToAddRows = false;
            dgvSearch.AllowUserToResizeRows = false;
            dgvSearch.AllowUserToResizeColumns = true;
            dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSearch.ScrollBars = ScrollBars.Both;
            dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            GlobalFunction.ApplyMasterGrid(dgvSearch);

        }


        private void cmdCancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            PartyMasterSelected = new PartyMaster();
            int selectedIndex = dgvSearch.SelectedRows[0].Index;

            if (selectedIndex != -1)
            {

                PartyMasterSelected.PartyID = Convert.ToString(dgvSearch.Rows[selectedIndex].Cells[PartyIDIndex].Value);
                PartyMasterSelected.PartyName = Convert.ToString(dgvSearch.Rows[selectedIndex].Cells[PartyNameIndex].Value);
                PartyMasterSelected.PersonName = Convert.ToString(dgvSearch.Rows[selectedIndex].Cells[PersonNameIndex].Value);
                PartyMasterSelected.Address = Convert.ToString(dgvSearch.Rows[selectedIndex].Cells[AddressIndex].Value);
                PartyMasterSelected.ContactNo = Convert.ToString(dgvSearch.Rows[selectedIndex].Cells[ContactNoIndex].Value);
                PartyMasterSelected.Mobile = Convert.ToString(dgvSearch.Rows[selectedIndex].Cells[MobileIndex].Value);
                PartyMasterSelected.EamilAddress = Convert.ToString(dgvSearch.Rows[selectedIndex].Cells[EmailIndex].Value);
                PartyMasterSelected.Remarks = Convert.ToString(dgvSearch.Rows[selectedIndex].Cells[RemarksIndex].Value);

            }
            else
            {
                PartyMasterSelected = null;                
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
                PartyMaster objMaster = new PartyMaster();

                List<PartyMaster> list = objMaster.GetPartyMasterList();

                if ((list != null))
                {
                    if (list.Count > 0)
                    {

                        int i;

                        foreach (PartyMaster obj in list)
                        {
                            i = dgvSearch.RowCount;

                            dgvSearch.RowCount = i + 1;
                            dgvSearch.Rows[i].Cells[SNoIndex].Value = i + 1;

                            dgvSearch.Rows[i].Cells[PartyIDIndex].Value = obj.PartyID;
                            dgvSearch.Rows[i].Cells[PartyNameIndex].Value = obj.PartyName;
                            dgvSearch.Rows[i].Cells[PersonNameIndex].Value = obj.PersonName;
                            dgvSearch.Rows[i].Cells[AddressIndex].Value = obj.Address;
                            dgvSearch.Rows[i].Cells[ContactNoIndex].Value = obj.ContactNo;
                            dgvSearch.Rows[i].Cells[MobileIndex].Value = obj.Mobile;
                            dgvSearch.Rows[i].Cells[EmailIndex].Value = obj.EamilAddress;
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




        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
