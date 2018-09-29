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

namespace DemoProject
{
    public partial class EditJobPost : System.Web.UI.Page
    {
        SqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*****************conncetion*************************/
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
               
            }
            if (!IsPostBack)
            {
                for (int i = 0; i < 31; i++)
                {
                    DropDownExpMin.Items.Add(i.ToString());
                    DropDownExpMax.Items.Add((i + 1).ToString());
                }

                Display();
            }
        }

        protected void Display()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {

                com.CommandText = "SELECT EmployerSubmitJobs.* FROM EmployerSubmitJobs WHERE (JobID = @JobID)";

                com.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["AppliedJobID"]);
                com.Connection = connection;
                da = new SqlDataAdapter(com);
                da.Fill(ds, "Data");


                if (ds.Tables["Data"].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++)
                    {     
                    
                        txtJobCode.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["CompanyJobCode"]);
                        txtJobTitle.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobTitle"]);
                        ddlJobType.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobType"]);
                        ddlJobCategory.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobCategory"]);
                        ddlJobSalary.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobSalary"]);
                      txtJobLocation.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Location"]);
                      DropDownExpMin.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["ExpMin"]);
                                             
                      DropDownExpMax.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["ExpMax"]);
                        txtSkills.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["KeySkills"]);
                        txtJobDesc1.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc1"]);
                        txtJobDesc2.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc2"]);
                        txtJobDesc3.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc3"]);
                        txtJobDesc4.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc4"]);
                        txtJobDesc5.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc5"]);
                       
                     

                    }

                }



            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

            finally
            {
                connection.Close();
                com.Dispose();

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
            SqlCommand comUPdate = new SqlCommand();
            try
            {
                comUPdate.CommandText = "UPDATE EmployerSubmitJobs SET CompanyJobCode = @CompanyJobCode, JobTitle = @JobTitle,JobType = @JobType,JobCategory = @JobCategory,JobSalary = @JobSalary,Location = @Location,ExpMin = @ExpMin,ExpMax = @ExpMax,KeySkills = @KeySkills, JobDesc1 = @JobDesc1,JobDesc2 = @JobDesc2,JobDesc3 = @JobDesc3,JobDesc4 = @JobDesc4,JobDesc5 = @JobDesc5 WHERE JobID = @JobID";
                
                comUPdate.Parameters.Add("@CompanyJobCode", SqlDbType.VarChar, 50).Value = txtJobCode.Text.Trim();
                comUPdate.Parameters.Add("@JobTitle", SqlDbType.VarChar, 50).Value = txtJobTitle.Text.Trim();
                comUPdate.Parameters.Add("@JobType", SqlDbType.VarChar, 50).Value = ddlJobType.SelectedItem.Text.Trim();
                comUPdate.Parameters.Add("@JobCategory", SqlDbType.VarChar, 50).Value = ddlJobCategory.SelectedItem.Text.Trim(); 
                comUPdate.Parameters.Add("@JobSalary", SqlDbType.VarChar, 50).Value =ddlJobSalary.SelectedItem.Text;
                comUPdate.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = txtJobLocation.Text.Trim();
                comUPdate.Parameters.Add("@ExpMin", SqlDbType.VarChar, 50).Value = DropDownExpMin.SelectedItem.Text.Trim();
                comUPdate.Parameters.Add("@ExpMax", SqlDbType.VarChar, 50).Value = DropDownExpMax.SelectedItem.Text.Trim();
                comUPdate.Parameters.Add("@KeySkills", SqlDbType.VarChar, 50).Value = txtSkills.Text.Trim();

                comUPdate.Parameters.Add("@JobDesc1", SqlDbType.VarChar, 50).Value = txtJobDesc1.Text.Trim();
                comUPdate.Parameters.Add("@JobDesc2", SqlDbType.VarChar, 50).Value = txtJobDesc2.Text.Trim();
                comUPdate.Parameters.Add("@JobDesc3", SqlDbType.VarChar, 50).Value = txtJobDesc3.Text.Trim();
                comUPdate.Parameters.Add("@JobDesc4", SqlDbType.VarChar, 50).Value = txtJobDesc4.Text.Trim();
                comUPdate.Parameters.Add("@JobDesc5", SqlDbType.VarChar, 50).Value = txtJobDesc5.Text.Trim();

                comUPdate.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["AppliedJobID"]);
                comUPdate.Connection = connection;
                comUPdate.ExecuteNonQuery();
                lblResult.Text = "* Job Post updated successfully";

            }
            catch
            {
                lblResult.Text = "* Error occurs";
            }
            finally 
            {
                comUPdate.Dispose();
                connection.Close();
            }


        }

       
        protected void DropDownExpMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownExpMax.Items.Clear();
            int index = Convert.ToInt32( DropDownExpMin.SelectedItem.Text);
            for (int i = index; i < 31; i++)
            {
                DropDownExpMax.Items.Add((i+1).ToString());
            }
        }

    }
}
