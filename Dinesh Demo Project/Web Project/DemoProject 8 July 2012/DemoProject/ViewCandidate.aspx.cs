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
    public partial class ViewCandidate : System.Web.UI.Page
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
            }
            if (Convert.ToString(Session["UserType"]) != "Employer")
            {
                Response.Redirect("~/Home.aspx");
            }

            if (!IsPostBack)
            {
                DisplayJob();
                Display();
            
            }

        }
        protected void DisplayJob()
        {

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
           
                com.CommandText = "SELECT JobTitle, JobSalary, ExpMin, ExpMax, JobID FROM EmployerSubmitJobs WHERE (JobID = @JobID)";

                com.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["AppliedJobID"]);
                com.Connection = connection;
                da = new SqlDataAdapter(com);
                da.Fill(ds, "Data");

                if (ds.Tables["Data"].Rows.Count > 0)
                {
                  


                        lblTitle.Text = Convert.ToString(ds.Tables["Data"].Rows[0]["JobTitle"]);
                        lblExperience.Text = Convert.ToString(ds.Tables["Data"].Rows[0]["ExpMin"]) + "-" + Convert.ToString(ds.Tables["Data"].Rows[0]["ExpMax"])+" Years";

                     
                        lblSalary.Text = Convert.ToString(ds.Tables["Data"].Rows[0]["JobSalary"])+" Rs.";

                  

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
           
                com.CommandText = "SELECT     JobSeekerAppliedJob.JobID, JobSeekerAppliedJob.FileResume, CONVERT(varchar, JobSeekerAppliedJob.AppliedDate, 106) AS AppliedOn,  RegistrationTable.UserCode, RegistrationTable.Email, JobSeekerPersonalDetails.FirstName, JobSeekerPersonalDetails.LastName,  JobSeekerPersonalDetails.Gender, JobSeekerQualification.Degree, JobSeekerQualification.PassingYear, JobSeekerExperience.ExperienceField,  JobSeekerExperience.NoOfYears, JobSeekerPersonalDetails.Phone, CONVERT(varchar, JobSeekerExperience.UpdateDate, 106) AS UpdateDate FROM         JobSeekerExperience INNER JOIN JobSeekerAppliedJob INNER JOIN EmployerSubmitJobs ON JobSeekerAppliedJob.JobID = EmployerSubmitJobs.JobID INNER JOIN RegistrationTable ON JobSeekerAppliedJob.JobSeekerUserCode = RegistrationTable.UserCode INNER JOIN JobSeekerPersonalDetails ON RegistrationTable.UserCode = JobSeekerPersonalDetails.UserCode INNER JOIN JobSeekerQualification ON JobSeekerPersonalDetails.UserCode = JobSeekerQualification.UserCode ON  JobSeekerExperience.UserCode = JobSeekerPersonalDetails.UserCode WHERE (JobSeekerAppliedJob.JobID = @JobID) ORDER BY JobSeekerAppliedJob.AppliedDate";

                com.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["AppliedJobID"]);
                com.Connection = connection;
                da = new SqlDataAdapter(com);
                da.Fill(ds, "Data");
                GridView1.DataSource = ds;
                GridView1.DataBind();
            
            
               

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
          
            if (e.CommandName == "ViewResume")
            {
             Label lblUserCode = (Label)GridView1.Rows[index].FindControl("lblUserCode");
            Label lblFileName = (Label)GridView1.Rows[index].FindControl("lblFileResume");
            ViewState["filenameResume"] = lblFileName.Text.Trim();
            ViewState["tempUserCode"] = lblUserCode.Text.Trim();
          
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                if (ViewState["filenameResume"] != null)
                {
                    string path = Server.MapPath("Resume\\" + Convert.ToString(ViewState["filenameResume"]));
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)
                    {
                        /****************************Profile View by Employer*******************************/
                        SqlCommand com = new SqlCommand();
                        com.CommandText = "UPDATE JobSeekerAppliedJob SET EmployerView = 1,ViewDate=@ViewDate WHERE JobID = @JobID and JobSeekerUserCode = @JobSeekerUserCode";
                        com.Parameters.Add("@ViewDate", SqlDbType.VarChar, 50).Value = DateTime.Now.Date;
                        com.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["AppliedJobID"]);
                        com.Parameters.Add("@JobSeekerUserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(ViewState["tempUserCode"]);
                        com.Connection = connection;
                        com.ExecuteNonQuery();
                        /********************************************************************************************/
                        Response.Clear();
                        Response.ClearHeaders();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                        Response.AddHeader("Content-Length", file.Length.ToString());

                        Session["ResumeName"] = "Resume/" + Convert.ToString(ViewState["filenameResume"]);
                        string ext = Path.GetExtension(path);
                        if (ext == ".pdf")
                        {
                            Response.ContentType = "application/pdf";
                            Response.Redirect("~/Frame.aspx");
                        }
                        else
                        {
                            Response.ContentType = "application/octet-stream";
                            Response.WriteFile(file.FullName);
                            Response.Redirect("~/Frame.aspx");
                            // Response.End();
                        }
                      

                    }
                    else
                    {
                        lblResult.Visible = true;
                        lblResult.Text = "* Resume is not available";

                    }

                }
                else
                {
                    lblResult.Visible = true;
                    lblResult.Text = "* Resume is not available";

                }

            }

            if (e.CommandName == "ViewProfile")
            {
               
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Display();
        }

    }
}
