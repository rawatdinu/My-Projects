using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using ColdStorage.DAL;
using ColdStorage.AppCode;
using ColdStorage.BLL;



namespace ColdStorage
{
    public class GlobalFunction
    {
        #region Members

        public static string glbUserName;
        public static string glbUserType;
        public static string GlobalUserControlTest = "";

        public static string SuperUser = "";
        public static string NormalUser = "";


        # endregion

        # region Functions

        /************************Login***********************/
        public static bool IsValidUser(string UserID, string pwd)
        {
            string[] para;
            object[] values;
            string getUserID;
            string getPassword;
            OleDbParameter[] oleParam;
            DataTable dt = new DataTable();
            bool result = false;

            string str = "SELECT UserID, Password, UserName, UserType FROM LoginMaster WHERE UserID= @UserID AND Password = @Password";
            para = new string[] { "@UserID", "@Password" };
            values = new object[] { UserID, pwd };
            //oleParam = new OleDbParameter[]
            //             {
            //                  new OleDbParameter("@UserID",UserID),                          
            //                 new  OleDbParameter("@Password",pwd)
            //             };
            dt = DBService.GetDataTable(str, para, values);

            if (dt.Rows.Count > 0)
            {
                getUserID = Convert.ToString(dt.Rows[0]["UserID"]);
                getPassword = Convert.ToString(dt.Rows[0]["Password"]);
                glbUserName = Convert.ToString(dt.Rows[0]["UserName"]);
                glbUserType = Convert.ToString(dt.Rows[0]["UserType"]);

                if (UserID.Equals(getUserID, StringComparison.Ordinal) && pwd.Equals(getPassword, StringComparison.Ordinal))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            else
            {
                result = false;
            }

            return result;

        }
        public static void GetUserTypes()
        {
            int RecNo;
            DataTable dt = new DataTable();
            string str = "SELECT * FROM UserType";
            dt = DBService.GetDataTable(str);
            RecNo = dt.Rows.Count;
            if (RecNo > 0)
            {
                SuperUser = Convert.ToString(dt.Rows[0]["UserType"]);
                NormalUser = Convert.ToString(dt.Rows[1]["UserType"]);

            }

        }

        public static bool IsInteger(string str)
        {
            bool blnRes = false;
            int num1;
            blnRes = int.TryParse(str, out num1);

            return blnRes;
        }


        public static bool IsMultipleOf(int Num, int Value)
        {
            bool blnRes = false;
            if (Num % Value == 0)
            {
                blnRes = true;
            }
            return blnRes;
        }


        public static Size GetWindowSize()
        {
            int temWidth = 0, tempHeight = 0;
            string[] tempSize;
            string str = "Select WinSize from WinSetting";
            tempSize = Convert.ToString(DBService.ExecuteScalar(str)).Split(',');
            temWidth = Convert.ToInt32(tempSize[0]);
            tempHeight = Convert.ToInt32(tempSize[1]);
            return new Size(temWidth, tempHeight);
        }

        public static bool IsShareHasTransaction(int SID)
        {
            bool blnRes = false;





            return blnRes;


        }



        # endregion

        #region Grid Style Common to All
        public static void SetGridStyle(DataGridView dgv)
        {

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Regular);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.Black;
        }

        public static void ApplyMasterGrid(DataGridView dgv)
        {
            
            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ForeColor = Color.Black;
            DataGridViewCellStyle style =
                dgv.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.FromArgb(103, 58, 183);
            style.ForeColor = Color.White;
            style.Font = new Font(dgv.Font, FontStyle.Regular);

            //dgv.ColumnHeadersDefaultCellStyle = style;
                        
            dgv.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.GridColor = SystemColors.ActiveBorder;
            dgv.BackgroundColor = Color.White;

//            dgv.Dock = DockStyle.Fill;        
        
        }

        public static void AddActionButtonToGrid(DataGridView dgv)
        {
            //Edit
            DataGridViewImageColumn colEdit = new DataGridViewImageColumn();
            Image imgEdit = Properties.Resources.edit;
            //imgView.Width = 32;
            //imgView.Height = 32;
            colEdit.Image = imgEdit;
            dgv.Columns.Insert(0,colEdit); // insert at 0 index
            //dgv.Columns.Add(colEdit);  
            colEdit.HeaderText = "";
            colEdit.Name = "Edit";
            colEdit.ImageLayout = DataGridViewImageCellLayout.Normal;
            colEdit.Width = 40;

            //View
            DataGridViewImageColumn colView = new DataGridViewImageColumn();
            Image imgView = Properties.Resources.view;
            //imgView.Width = 32;
            //imgView.Height = 32;
            colView.Image = imgView;
            dgv.Columns.Insert(1,colView);

            //dgv.Columns.Add(colView);
            colView.HeaderText = "";
            colView.Name = "View";
            colView.ImageLayout = DataGridViewImageCellLayout.Normal;
            colView.Width = 40;

            //View
            DataGridViewImageColumn colDelete = new DataGridViewImageColumn();
            Image imgDelete = Properties.Resources.delete;
            //imgView.Width = 32;
            //imgView.Height = 32;
            colDelete.Image = imgDelete;
            dgv.Columns.Insert(2,colDelete);
            //dgv.Columns.Add(colDelete);
            colDelete.HeaderText = "";
            colDelete.Name = "Delete";
            colDelete.ImageLayout = DataGridViewImageCellLayout.Normal;
            colDelete.Width = 40;


        }

        public static void AddCheckBoxToGrid(DataGridView dgv, CheckBox checkbox)
        {
            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.HeaderText = "";            
            chkCol.Width = 40;
            chkCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Insert(0, chkCol);

            
            checkbox.Size = new System.Drawing.Size(15, 15);
            checkbox.BackColor = Color.Transparent;

            // Reset properties
            checkbox.Padding = new Padding(0);
            checkbox.Margin = new Padding(0);
            checkbox.Text = "";

            // Add checkbox to datagrid cell
            dgv.Controls.Add(checkbox);
            DataGridViewHeaderCell header = dgv.Columns[chkCol.Index].HeaderCell;
            ////checkbox.Location = new Point(
            ////    header.ContentBounds.Left + (header.ContentBounds.Right - header.ContentBounds.Left + checkbox.Size.Width) / 2,
            ////    header.ContentBounds.Top + (header.ContentBounds.Bottom - header.ContentBounds.Top + checkbox.Size.Height) / 2
            ////);
            checkbox.Location = new Point(
                header.ContentBounds.Left + (header.ContentBounds.Right - header.ContentBounds.Left + (chkCol.HeaderCell.Size.Width - checkbox.Size.Width)) / 2,
                header.ContentBounds.Top + (header.ContentBounds.Bottom - header.ContentBounds.Top + (chkCol.HeaderCell.Size.Height - checkbox.Size.Height)) / 2
            );
        }                
        #endregion


        #region DateTime
        public static DateTime GetDateTimeWithoutMiliSecond(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }

        #endregion

        #region UniqueId

        public static string GetUniqueNo(string tableName, string prefix, int length)
        {
            string str1;
            int TempID;
            string meetingNo = "";

            try
            {
                str1 = "SELECT  count(*) as tempID FROM " + tableName;
                TempID = Convert.ToInt32(DBService.ExecuteScalar(str1));

                TempID = TempID + 1;

                meetingNo = prefix + Convert.ToString(TempID).PadLeft(length, '0');
                return meetingNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                meetingNo = "-1";
                return meetingNo;
            }

        }

        public static string GetUniqueCode(string tableName)
        {

            string prefix = "";
            string suffix = "";
            int currentNo;
            int incrementBy;
            int max;
            int length;
            char peddingChar;

            DataTable dt;

            string str1;
            int TempID;
            string uniqueCode = "";

            try
            {


                //str1 = "SELECT  count(*) as tempID FROM " + tableName;



                dt = GlobalFunctionDAL.GetUniqueCodeForTable(tableName);
                if (dt.Rows.Count > 0)
                {

                    prefix = Convert.ToString(dt.Rows[0]["Prefix"]);
                    suffix = Convert.ToString(dt.Rows[0]["Suffix"]);
                    currentNo = Convert.ToInt32(dt.Rows[0]["CurrentNo"]);
                    incrementBy = Convert.ToInt32(dt.Rows[0]["IncrementBy"]);
                    max = Convert.ToInt32(dt.Rows[0]["Max"]);
                    length = Convert.ToInt32(dt.Rows[0]["Length"]);
                    peddingChar = Convert.ToChar(dt.Rows[0]["PeddingChar"]);
                    if (currentNo < max)
                    {
                        uniqueCode = prefix + ((currentNo + incrementBy) + suffix).PadLeft(length, peddingChar);
                    }
                    else
                    {
                        MessageBox.Show("Cannot Generate New Unique Record");
                        uniqueCode = "-1";
                    }

                }
                else
                {
                    return "-1";
                }

                return uniqueCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                uniqueCode = "-1";
                return uniqueCode;
            }

        }

        public static bool UpdateUniqueCode(string tableName)
        {

            bool result = false;
            try
            {

                result = GlobalFunctionDAL.UpdateUniqueCodeForTable(tableName);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }

        }

        public static String GetUniqueIDTimeStamp()
        {
            string id = "";
            id = DateTime.Now.ToString("ddMMyyyyHHmmss");
            return id;
        }

        #endregion

        #region FormLookup

        public static object ShowLookUpForm(string formName)
        {
            object obj;

            try
            {
                switch (formName)
                {

                    case "frmPartyMaster":
                        frmPartyMaster objLookup = new frmPartyMaster();
                        objLookup.IsLookUpMode = true;

                        DialogResult result;

                        result = objLookup.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            //retun party master ojnect
                            PartyMaster partyMaster = new PartyMaster();
                            obj = partyMaster.GetPartyMasterDetails(objLookup.PartyID);
                        }
                        else
                        {
                            //retun null
                            obj = null;
                        }
                        return obj;

                    default:
                        obj = null;
                        return obj;
                        
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion
    }


}
