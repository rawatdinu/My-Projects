using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using VillageMeeting.AppCode;
using System.Drawing;

namespace VillageMeeting
{
  public  class GlobalFunction
    {
        #region Members

       public static string glbUserName;
      public static string  glbUserType;
      public static  string GlobalUserControlTest="";

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
            dt = DBService.GetDataTable(str,para,values);

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
                SuperUser =Convert.ToString (dt.Rows[0]["UserType"]);
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
            int temWidth=0,tempHeight=0;
            string[] tempSize;
            string str = "Select WinSize from WinSetting";
            tempSize = Convert.ToString(DBService.ExecuteScalar(str)).Split(',');
            temWidth = Convert.ToInt32( tempSize[0]);
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
        #endregion
    }


}
