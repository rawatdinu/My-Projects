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
    public partial class CompanyProfile : System.Web.UI.Page
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

            if (Convert.ToString(Session["UserType"]) != "JobSeeker")
            {
                JobSeeker(false);
               
            }
            else 
            {
                JobSeeker(true);

            }
            if ((Session["UserCode"]) != null)
            {
                Panel2.Visible = true;
            }
            else
            {
                Panel2.Visible = false;
            }

            if (Session["JobID"] == null)
            {
                Response.Redirect("~/JobSearch.aspx");
            }

            if (!IsPostBack)
            {
                Display();
            }
            

        }
        protected void FillCombo()
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

                com.CommandText = "SELECT     FileName, ResumeTitle, UserCode, UploadDate FROM JobSeekerResume WHERE     (UserCode = @UserCode) ORDER BY UploadDate DESC";

                com.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                com.Connection = connection;
                da = new SqlDataAdapter(com);
                da.Fill(ds, "Data");

                if (ds.Tables["Data"].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++)
                    {
                        DropDownListResume.Items.Add(Convert.ToString(ds.Tables["Data"].Rows[i]["FileName"]));
                        DropDownListResume.Items.Add(Convert.ToString(ds.Tables["Data"].Rows[i]["ResumeTitle"]));
                       

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

                com.CommandText = "SELECT     RegistrationTable.UserCode, EmployerSubmitJobs.JobID, EmployerSubmitJobs.JobTitle, EmployerSubmitJobs.JobDesc1, EmployerSubmitJobs.JobDesc2, EmployerSubmitJobs.JobDesc3, EmployerSubmitJobs.JobDesc4, EmployerSubmitJobs.JobDesc5, EmployerSubmitJobs.ExpMin, EmployerSubmitJobs.ExpMax, EmployerSubmitJobs.JobSalary, RegistrationTable.Email, EmployerDetails.AlternateEmail, EmployerDetails.Phone, EmployerDetails.AlternateNo, EmployerSubmitJobs.KeySkills, EmployerDetails.Logo,EmployerDetails.Website FROM EmployerSubmitJobs INNER JOIN RegistrationTable ON EmployerSubmitJobs.UserCode = RegistrationTable.UserCode INNER JOIN EmployerDetails ON RegistrationTable.UserCode = EmployerDetails.UserCode WHERE     (RegistrationTable.UserCode = @UserCode) OR (EmployerSubmitJobs.JobID = @JobID)";

                com.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                com.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["JobID"]);
                com.Connection = connection;
                da = new SqlDataAdapter(com);
                da.Fill(ds, "Data");

                if (ds.Tables["Data"].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++)
                    {
                        lblTitle.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobTitle"]);

                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc1"]) != "")
                        {
                            BulletedList1.Items.Add(Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc1"]));
                        }
                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc2"]) != "")
                        {
                            BulletedList1.Items.Add(Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc2"]));
                        }
                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc3"]) != "")
                        {
                            BulletedList1.Items.Add(Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc3"]));
                        }
                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc4"]) != "")
                        {
                            BulletedList1.Items.Add(Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc4"]));
                        }
                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc5"]) != "")
                        {
                            BulletedList1.Items.Add(Convert.ToString(ds.Tables["Data"].Rows[i]["JobDesc5"]));
                        }


                        lblExp.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["ExpMin"]) + "-" + Convert.ToString(ds.Tables["Data"].Rows[i]["ExpMax"])+" Years";

                       

                        lblSalary.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["JobSalary"]);
                        lblEmail.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Email"]) + ", " + Convert.ToString(ds.Tables["Data"].Rows[i]["AlternateEmail"]);
                        lblPhone.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Phone"]) + ", " + Convert.ToString(ds.Tables["Data"].Rows[i]["AlternateNo"]);

                        lblSkills.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["KeySkills"]);

                     HyperLinkweb.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Website"]);
                      
                        HyperLinkweb.NavigateUrl = "http://" + Convert.ToString(ds.Tables["Data"].Rows[i]["Website"]);

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

        protected void JobSeeker(bool status)
        {
            linkApply.Visible = status;
            linkLoginToApply.Visible = !(status);
            LinkApplyWithoutRegistration.Visible = !(status);
            LinkNewUser.Visible = !(status);
            Panel3.Visible = false;
        
        }

        protected void LinkNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistrationForm.aspx");
        }

        protected void linkApply_Click(object sender, EventArgs e)
        {
            if (IsUserExist() == true)
            {
                lblResult.Text = "* You have already apply for this job";
                return;
            }
            SqlCommand comSAVE = new SqlCommand();
            SqlCommand com = new SqlCommand();
            string FileResume;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            try
            {
                /*******************************JobSeeker Resume**********************************************/
                com.CommandText = "SELECT     TOP (1) UserCode, FileName, UploadDate FROM JobSeekerResume WHERE (UserCode = @UserCode) ORDER BY UploadDate DESC";
                com.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                com.Connection = connection;
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    FileResume = Convert.ToString(dr["FileName"]);
                }
                else
                {
                    FileResume = "";
                }
                dr.Close();
                dr.Dispose();
                /***************************************************************************************/


                comSAVE.CommandText = "INSERT INTO JobSeekerAppliedJob (JobID,JobSeekerUserCode,AppliedDate,FileResume) VALUES (@JobID,@JobSeekerUserCode,@AppliedDate,@FileResume)";

                comSAVE.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["JobID"]);
                comSAVE.Parameters.Add("@JobSeekerUserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                comSAVE.Parameters.Add("@AppliedDate", SqlDbType.VarChar, 50).Value = DateTime.Now.Date;
                comSAVE.Parameters.Add("@FileResume", SqlDbType.VarChar, 50).Value = FileResume;
               
                comSAVE.Connection = connection;
                comSAVE.ExecuteNonQuery();
                lblResult.Text = "* Applied for job successfully";

            }
            catch(Exception ex)
            {
                Response.Write(ex);
                lblResult.Text = "* Error occurs";
            }
            finally 
            {
                comSAVE.Dispose();
                com.Dispose();

            }


        }

        private bool IsUserExist()
        {

            SqlCommand command = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            if (connection.State == ConnectionState.Closed)
                connection.Open();
          
                command.CommandText = "SELECT JobSeekerUserCode,JobID FROM JobSeekerAppliedJob WHERE (JobSeekerUserCode = @UserCode) AND (JobID = @JobID)";
                command.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                command.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["JobID"]);
                command.Connection = connection;
                da = new SqlDataAdapter(command);
                da.Fill(ds, "Data");
                if (ds.Tables["Data"].Rows.Count > 0)
                    return true;
                else
                    return false;

        } 

        protected void linkLoginToApply_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["UserType"]) == "Employer")
            {
                lblResult.Text = "* Employer cannot apply";
                return;
            }
            else
            {
                Response.Redirect("~/LoginToApply.aspx");
            }
        }

        protected void LinkApplyWithoutRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ApplyWithoutRegistration.aspx");
        }


    }
}
