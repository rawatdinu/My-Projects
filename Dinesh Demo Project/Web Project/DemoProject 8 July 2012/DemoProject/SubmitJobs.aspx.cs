using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DemoProject
{
    public partial class SubmitJobs : System.Web.UI.Page
    {
        SqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (connection == null)
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                connection.Open();
            }
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            /******************************************************/

            if (Session["UserCode"] == null)
            {
                Response.Redirect("~/Home.aspx");
                return;
            }
            if (Convert.ToString(Session["UserType"]) != "Employer")
            {
                Response.Redirect("~/Home.aspx");
                return;
            }
            linkSubmitJobs.Visible = false;

            if (!IsPostBack)
            {
                int i;
                for (i = 0; i < 31; i++)
                {
                    DropDownExpMin.Items.Add(Convert.ToString(i));
                    DropDownExpMax.Items.Add(Convert.ToString(i+1));
                }
                                    
              


            }

        }

        protected void linkBtMyDesboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployerProfile.aspx");
        }

        protected void linkViewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployerProfile.aspx");
        }

        protected void linkBtUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UpdateEmployerProfile.aspx");
        }

        protected void linkBtChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }

        protected void btnPostJob_Click(object sender, EventArgs e)
        {
           
            if (connection.State == ConnectionState.Closed)
                connection.Open();
          
            SqlCommand comSAVE = new SqlCommand();

            try
            {
               
                /**********************************Save Resume information*******************************************/
                comSAVE.CommandText = "INSERT INTO EmployerSubmitJobs (UserCode,JobID,CompanyJobCode,JobTitle,JobType,JobCategory,JobSalary,Location,ExpMin,ExpMax,KeySkills,JobDesc1,JobDesc2,JobDesc3,JobDesc4,JobDesc5,JobPostDate) VALUES (@UserCode,@JobID,@CompanyJobCode,@JobTitle,@JobType,@JobCategory,@JobSalary,@Location,@ExpMin,@ExpMax,@KeySkills,@JobDesc1,@JobDesc2,@JobDesc3,@JobDesc4,@JobDesc5,@JobPostDate)";

                comSAVE.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                comSAVE.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = GetCode();               
                comSAVE.Parameters.Add("@CompanyJobCode", SqlDbType.VarChar, 50).Value = txtJobCode.Text.Trim();
                comSAVE.Parameters.Add("@JobTitle", SqlDbType.VarChar, 100).Value = txtJobTitle.Text;

                if (ddlJobType.SelectedIndex == 0)
                {
                    comSAVE.Parameters.Add("@JobType", SqlDbType.VarChar, 50).Value ="";
                }
                else
                {
                    comSAVE.Parameters.Add("@JobType", SqlDbType.VarChar, 50).Value = ddlJobType.Text;
                }

                if (ddlJobCategory.SelectedIndex == 0)
                {
                    comSAVE.Parameters.Add("@JobCategory", SqlDbType.VarChar, 50).Value = "";
                }
                else
                {
                    comSAVE.Parameters.Add("@JobCategory", SqlDbType.VarChar, 50).Value = ddlJobCategory.Text;
                }

                if (ddlJobCategory.SelectedIndex == 0)
                {
                    comSAVE.Parameters.Add("@JobSalary", SqlDbType.VarChar, 50).Value = "";
                }
                else
                {
                    comSAVE.Parameters.Add("@JobSalary", SqlDbType.VarChar, 50).Value = ddlJobSalary.Text;
                }
                comSAVE.Parameters.Add("@Location", SqlDbType.VarChar, 100).Value = txtJobLocation.Text;
                comSAVE.Parameters.Add("@ExpMin", SqlDbType.VarChar, 50).Value = DropDownExpMin.Text;
                comSAVE.Parameters.Add("@ExpMax", SqlDbType.VarChar, 50).Value = DropDownExpMax.Text;
                comSAVE.Parameters.Add("@KeySkills", SqlDbType.VarChar, 200).Value = txtSkills.Text;

                comSAVE.Parameters.Add("@JobDesc1", SqlDbType.VarChar, 100).Value = txtJobDesc1.Text;
                comSAVE.Parameters.Add("@JobDesc2", SqlDbType.VarChar, 100).Value = txtJobDesc2.Text;
                comSAVE.Parameters.Add("@JobDesc3", SqlDbType.VarChar, 100).Value = txtJobDesc3.Text;
                comSAVE.Parameters.Add("@JobDesc4", SqlDbType.VarChar, 100).Value = txtJobDesc4.Text;
                comSAVE.Parameters.Add("@JobDesc5", SqlDbType.VarChar, 100).Value = txtJobDesc5.Text;
             
                
                comSAVE.Parameters.Add("@JobPostDate", SqlDbType.VarChar, 50).Value = DateTime.Now.ToString();

                comSAVE.Connection = connection;
                comSAVE.ExecuteNonQuery();
                lblResult.Text = "Job is submitted sucessfully";
                linkSubmitJobs.Visible = true;

            }
            catch (Exception ex)
            {
                Response.Write(ex);
              lblResult.Text = "* Error occurs";

            }
            finally
            {
               
                comSAVE.Dispose();

            }




        }
     

        protected void linkSubmitJobs_Click(object sender, EventArgs e)
        {
            txtJobCode.Text = String.Empty;
            txtJobTitle.Text = String.Empty;
            ddlJobType.SelectedIndex = 0;
            ddlJobCategory.SelectedIndex = 0;
            ddlJobSalary.SelectedIndex = 0;
            DropDownExpMin.SelectedIndex = 0;
            DropDownExpMax.SelectedIndex = 0;
            linkSubmitJobs.Visible = false;
        }

        protected void DropDownExpMin_TextChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(DropDownExpMin.Text);
            DropDownExpMax.Items.Clear();
            while (i < 31)
            {
                DropDownExpMax.Items.Add(Convert.ToString(i + 1));
                i++;
            }
        }

        protected string GetCode()
        {
            SqlCommand com = new SqlCommand();
            string CurrentDate;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            com.CommandText = "SELECT     REPLACE(CONVERT(varchar, GETDATE(), 112) + CONVERT(varchar(8), GETDATE(), 114), ':', '') AS FileName";
            com.Connection = connection;
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            CurrentDate = Convert.ToString(dr["FileName"]);
            string FileName = Convert.ToString(Session["UserCode"]) + CurrentDate;
            dr.Close();
            dr.Dispose();
            return FileName.Trim();
        
        
        }

    

      

    }
}
