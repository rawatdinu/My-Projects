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


        private const int SNoWidth = 60;
        private const int PartyIDWidth = 60;
        private const int PartyNameWidth = 250;
        private const int PersonNameWidth = 150;
        private const int AddressWidth = 400;

        private const int SNoIndex = 0;
        private const int PartyIDIndex = 1;
        private const int PartyNameIndex = 2;
        private const int AddressIndex = 3;

        private const int PersonNameIndex = 4;       
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
            dgvSearch.ColumnCount = 4;

            dgvSearch.Columns[0].Name = "S.No";
            dgvSearch.Columns[0].Width = SNoWidth;
            dgvSearch.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            dgvSearch.Columns[1].Name = "Party ID";
            dgvSearch.Columns[1].Width = PartyIDWidth;

            dgvSearch.Columns[2].Name = "Party Name";
            dgvSearch.Columns[2].Width = PartyNameWidth;


            dgvSearch.Columns[3].Name = "Address";
            dgvSearch.Columns[3].Width = AddressWidth;      //323

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
                //PartyMasterSelected.PersonName = Convert.ToString(dgvSearch.Rows[selectedIndex].Cells[PersonNameIndex].Value);
                PartyMasterSelected.Address = Convert.ToString(dgvSearch.Rows[selectedIndex].Cells[AddressIndex].Value);


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
                            dgvSearch.Rows[i].Cells[AddressIndex].Value = obj.Address;

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
