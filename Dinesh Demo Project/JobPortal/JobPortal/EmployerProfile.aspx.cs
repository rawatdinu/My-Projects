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
    public partial class EmployerProfile : System.Web.UI.Page
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
            if (Convert.ToString(Session["UserType"]) == "JobSeeker")
            {
                Response.Redirect("~/Profile.aspx");
                
            }

           
            if (!IsPostBack)
            {
                Display();
                DisplayJobPost();
                TabContainer1.ActiveTabIndex = 0;
            }
            Session["AppliedJobID"] = null;
           
           

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

                    com.CommandText = "SELECT     RegistrationTable.UserCode, RegistrationTable.UserType, RegistrationTable.Email, EmployerDetails.FirstName, EmployerDetails.LastName, EmployerDetails.CompanyName, EmployerDetails.Staff, EmployerDetails.CompanyAddress, EmployerDetails.State, EmployerDetails.Country, EmployerDetails.Phone,EmployerDetails.AlternateNo, EmployerDetails.AlternateEmail, EmployerDetails.Website, EmployerDetails.FacebookID, EmployerDetails.TwitterID,EmployerDetails.Logo FROM EmployerDetails INNER JOIN RegistrationTable ON EmployerDetails.UserCode = RegistrationTable.UserCode WHERE     (RegistrationTable.UserCode = @UserCode)";

                    com.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                    com.Connection = connection;
                    da = new SqlDataAdapter(com);
                    da.Fill(ds, "Data");


                    int intRow = ds.Tables["Data"].Rows.Count;

                    if (intRow > 0)
                    {
                        for (int i = 0; i < intRow; i++)
                        {
                            lblCompanyName.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["CompanyName"]);
                            /*********************Personal Details***************************/

                            cellPersonInCharge.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["FirstName"]) +" "+ Convert.ToString(ds.Tables["Data"].Rows[i]["LastName"]);

                            cellStaff.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Staff"]);
                            cellAddress.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["CompanyAddress"]);
                            cellState.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["State"]);
                            cellCountry.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Country"]);
                            if (Convert.ToString(ds.Tables["Data"].Rows[i]["AlternateNo"]) == "")
                            {
                                cellPhone.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Phone"]);
                            }
                            else
                            {
                                cellPhone.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Phone"]) + ", " + Convert.ToString(ds.Tables["Data"].Rows[i]["AlternateNo"]);
                            }

                            if (Convert.ToString(ds.Tables["Data"].Rows[i]["AlternateEmail"]) == "")
                            {
                                cellEmail.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Email"]);
                            }
                            else
                            {
                                cellEmail.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Email"]) + ", " + Convert.ToString(ds.Tables["Data"].Rows[i]["AlternateEmail"]);
                            }
                           
                        
                           
                             

                            /*************Website and social media*******************/
                            cellWebsite.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Website"]);
                            cellFacebook.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["FacebookID"]);
                            cellTwitter.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["TwitterID"]);



                          /***********************Logo of company***************************************/
                            ViewState["Logo"] = Convert.ToString(ds.Tables["Data"].Rows[i]["Logo"]);

                            if (ViewState["Logo"] != null)
                            {
                                string path = Server.MapPath("images\\" + ViewState["Logo"].ToString());
                                FileInfo file = new FileInfo(path);
                                if (file.Exists)
                                {

                                    Image1.ImageUrl = "~/images/" + ViewState["Logo"].ToString();
                                    Image1.AlternateText = " Logo ";


                                }
                                else
                                {
                                    Image1.ImageUrl = "~/images/CompanyLogo.jpg";
                                    Image1.AlternateText = " Logo ";

                                }

                            }
                            else
                            {
                                Image1.ImageUrl = "~/images/CompanyLogo.jpg";
                                Image1.AlternateText = " Logo ";

                            }



                        }

                    }

                    /**********************Display MOre than ONe Resume *********************/
                    //ViewState["ResumeName"] = Convert.ToString(ds.Tables["Data"].Rows[i]["Photo"]);






                    /*********************************************/

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

        protected void DisplayJobPost()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                com.CommandText = "SELECT     EmployerSubmitJobs.JobID, EmployerSubmitJobs.JobType, EmployerSubmitJobs.CompanyJobCode, EmployerSubmitJobs.JobTitle, EmployerDetails.CompanyName, EmployerDetails.Website, EmployerSubmitJobs.Location, CONVERT(varchar, EmployerSubmitJobs.JobPostDate, 106) AS PostDate,  ISNULL(A.Num, 0) AS Num FROM EmployerSubmitJobs INNER JOIN RegistrationTable ON EmployerSubmitJobs.UserCode = RegistrationTable.UserCode INNER JOIN EmployerDetails ON RegistrationTable.UserCode = EmployerDetails.UserCode LEFT OUTER JOIN (SELECT     JobID, COUNT(JobSeekerUserCode) AS Num FROM  JobSeekerAppliedJob GROUP BY JobID) AS A ON EmployerSubmitJobs.JobID = A.JobID WHERE (EmployerSubmitJobs.UserCode = @UserCode)And(EmployerSubmitJobs.IsActive = 1) ORDER BY EmployerSubmitJobs.JobPostDate DESC";

/*
                com.CommandText = "SELECT     EmployerSubmitJobs.JobID, EmployerSubmitJobs.JobType,EmployerSubmitJobs.CompanyJobCode, EmployerSubmitJobs.JobTitle, EmployerDetails.CompanyName, EmployerDetails.Website, EmployerSubmitJobs.Location, CONVERT(varchar, EmployerSubmitJobs.JobPostDate, 106) AS PostDate FROM EmployerSubmitJobs INNER JOIN RegistrationTable ON EmployerSubmitJobs.UserCode = RegistrationTable.UserCode INNER JOIN EmployerDetails ON RegistrationTable.UserCode = EmployerDetails.UserCode WHERE (EmployerSubmitJobs.UserCode = @UserCode) ORDER BY EmployerSubmitJobs.JobPostDate DESC";
                */
                com.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);

                com.Connection = connection;
                da = new SqlDataAdapter(com);
                da.Fill(ds, "Data");

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write(ex);
               
            }

            finally
            {
                connection.Close();
                com.Dispose();
                da.Dispose();
                ds.Clear();
                ds.Dispose();
            
            }


           
        
        }
        
       

        protected void linkBtUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UpdateEmployerProfile.aspx");
        }

        protected void linkBtChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }

        protected void linkSubmitJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SubmitJobs.aspx");
        }
        /*
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.Item.ItemIndex);
            // string str = e.Item.FindControl("lblJobType").Controls[index].ToString();
            Label JobCode = (Label)e.Item.FindControl("lblJobID");
            string x = JobCode.Text;
            if (e.CommandName=="ViewCandidate")
            {
           
            }
            if (e.CommandName == "EditJobPost")
            {
               
            }
            if (e.CommandName == "DeleteJobPost")
            {
               
            }


              
        }
        */
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
           
           
            if (e.CommandName == "ViewCandidate")
            {
                Label lblfile = (Label)GridView1.Rows[index].FindControl("lblJobID");
                Session["AppliedJobID"] = lblfile.Text.Trim();
                Response.Redirect("~/ViewCandidate.aspx");
            }
            if (e.CommandName == "EditJobPost")
            {
                Label lblfile = (Label)GridView1.Rows[index].FindControl("lblJobID");
                Session["AppliedJobID"] = lblfile.Text.Trim();
                Response.Redirect("~/EditJobPost.aspx");
            
            }

            if (e.CommandName == "DeleteJobPost")
            {
                Label lblfile = (Label)GridView1.Rows[index].FindControl("lblJobID");
                Session["AppliedJobID"] = lblfile.Text.Trim();
                SqlCommand com = new SqlCommand();
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                try
                {
                    com.CommandText = "UPDATE EmployerSubmitJobs SET IsActive = 0 WHERE JobID=@JobID";
                    com.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["AppliedJobID"]);
                    com.Connection = connection;
                    com.ExecuteNonQuery();
                    lblResult.Text = "* Posted job deleted successfully";
                    
                
                }
                catch(Exception ex)
                {
                    Response.Write(ex);
                    lblResult.Text = "* Error Occurs";
                }
                finally
                {
                com.Dispose();
                Session["AppliedJobID"] = null;
                DisplayJobPost();
                }
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DisplayJobPost();
           
        }


    }
}
