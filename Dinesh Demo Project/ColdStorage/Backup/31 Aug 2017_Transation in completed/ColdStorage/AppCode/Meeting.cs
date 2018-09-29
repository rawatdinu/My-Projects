using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using ColdStorage.AppCode;
using System.Drawing;

namespace ColdStorage.AppCode
{
    public class Meeting
    {
        public static int CapitalFee = 0;
        public static int MinEMI = 0;
        public static int Interest = 0;
        public static int SpclInterest = 0;
        public static int LoanLimit = 0;
        public static int Penality = 0;
        public static int SpecialLoanScheme = 0;

        public static void SetMeetingAmount()
        {
            DataTable dt = new DataTable();
            string str;
            int RecNo;
            try
            {
                str = "SELECT ID, Capital, MinEMI, Interest, SpcInterest, LoanLimit, Penalty,SpclLoanScheme FROM CapitalLoanSetting Where ID=(SELECT Max( ID) FROM CapitalLoanSetting)";
                dt = DBService.GetDataTable(str);
                RecNo = dt.Rows.Count;

                if (RecNo > 0)
                {

                    CapitalFee = Convert.ToInt32(Convert.IsDBNull(dt.Rows[0]["Capital"]) ? "0" : dt.Rows[0]["Capital"]);
                    MinEMI = Convert.ToInt32(Convert.IsDBNull(dt.Rows[0]["MinEMI"]) ? "0" : dt.Rows[0]["MinEMI"]);
                    Interest = Convert.ToInt32(Convert.IsDBNull(dt.Rows[0]["Interest"]) ? "0" : dt.Rows[0]["Interest"]);
                    SpclInterest = Convert.ToInt32(Convert.IsDBNull(dt.Rows[0]["SpcInterest"]) ? "0" : dt.Rows[0]["SpcInterest"]);
                    LoanLimit = Convert.ToInt32(Convert.IsDBNull(dt.Rows[0]["LoanLimit"]) ? "0" : dt.Rows[0]["LoanLimit"]);
                    Penality = Convert.ToInt32(Convert.IsDBNull(dt.Rows[0]["Penalty"]) ? "0" : dt.Rows[0]["Penalty"]);
                    SpecialLoanScheme = Convert.ToInt32(Convert.IsDBNull(dt.Rows[0]["SpclLoanScheme"]) ? "0" : dt.Rows[0]["SpclLoanScheme"]);


                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

    }

   




}
