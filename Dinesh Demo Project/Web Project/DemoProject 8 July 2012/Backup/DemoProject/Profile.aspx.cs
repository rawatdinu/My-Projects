
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
using System.Text;
using System.IO;
using System.Drawing;

namespace DemoProject
{
    public partial class Profile : System.Web.UI.Page
    {
        SqlConnection connection;
       

       

        protected void Page_Load(object sender, EventArgs e)
        {
              /*****************conncetion*************************/
            if (connection == null)
            {
                connection = new SqlConnection();
                connection.ConnectionString=ConfigurationManager.ConnectionStrings["con"].ConnectionString;
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
            if(Convert.ToString(Session["UserType"])!="JobSeeker")
            {
                Response.Redirect("~/Home.aspx");
                 return;
            }
            if (Convert.ToString(Session["UserType"]) == "Employer")
            {
                Response.Redirect("~/EmployerProfile.aspx");
                return;
            }
         
             if(Session["ChangePassswordMsg"]!=null)
             {
            lblStatus.Text = Session["ChangePassswordMsg"].ToString();
                 Session["ChangePassswordMsg"]=null;
             }
            
            
             if (!IsPostBack)
             {
                
                 Display();
                 DisplayResumeList();
                 DisplayEmployerList();
               
                 TabContainer1.ActiveTabIndex = 0;
               
             }
            

             
        }
        /*
    
        protected void GetJObCode()
        {
            int row = GridViewResume.Rows.Count;
           
            for (int i = 0; i < GridViewResume.Rows.Count - 1; i++)
            {
                JobCode[i] = GridViewResume.Rows[i].Cells[0].Text.Trim();
            }
        
        }
        */
        protected void DisplayResumeList()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da;
            DataSet ds = new DataSet();


            com.CommandText = "SELECT     UserCode, ResumeTitle, FileName, CONVERT(varchar, UploadDate, 106) AS UP FROM JobSeekerResume ORDER BY UploadDate DESC";


            com.Connection = connection;
            da = new SqlDataAdapter(com);
            da.Fill(ds, "Data");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            
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

                com.CommandText = "SELECT     RegistrationTable.UserCode, RegistrationTable.UserType, RegistrationTable.Email, JobSeekerPersonalDetails.FirstName, JobSeekerPersonalDetails.LastName,    CONVERT(varchar(12), JobSeekerPersonalDetails.DOB, 106) AS DOB, JobSeekerPersonalDetails.Gender, JobSeekerPersonalDetails.Address, JobSeekerPersonalDetails.State,  JobSeekerPersonalDetails.Country, JobSeekerPersonalDetails.Phone, JobSeekerPersonalDetails.Mobile,JobSeekerPersonalDetails.Photo, JobSeekerQualification.Degree,  JobSeekerQualification.PassingYear, JobSeekerQualification.Marks, JobSeekerExperience.ExperienceField, JobSeekerExperience.NoOfYears,  JobSeekerExperience.ExpDesc, JobSeekerExperience.Skills, JobSeekerExperience.SkillsDesc,  CONVERT(varchar(12), JobSeekerExperience.UpdateDate, 106) AS UpdateDate  FROM RegistrationTable INNER JOIN JobSeekerPersonalDetails ON RegistrationTable.UserCode = JobSeekerPersonalDetails.UserCode INNER JOIN JobSeekerQualification ON JobSeekerPersonalDetails.UserCode = JobSeekerQualification.UserCode INNER JOIN JobSeekerExperience ON JobSeekerQualification.UserCode = JobSeekerExperience.UserCode LEFT OUTER JOIN JobSeekerResume ON JobSeekerExperience.UserCode = JobSeekerResume.UserCode WHERE     (RegistrationTable.UserCode = @UserCode)";

                com.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                com.Connection = connection;
                da = new SqlDataAdapter(com);
                da.Fill(ds, "Data");


                int intRow = ds.Tables["Data"].Rows.Count;

                if (intRow > 0)
                {
                    for (int i = 0; i < intRow; i++)
                 
                    {
                        lblLastUpdated.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["UpdateDate"]);
                       /*********************Personal Details***************************/
                        
                        cellFirstName.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["FirstName"]);
                        cellLastName.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["LastName"]);
                        cellDOB.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["DOB"]);
                        cellGender.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Gender"]);
                        cellAddress.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Address"]);
                        cellState.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["State"]);
                        cellCountry.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Country"]);
                        cellPhone.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Phone"]);
                        cellMobile.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Mobile"]);


                        /*************Qualification*******************/
                        cellDegree.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Degree"]);
                         cellPassingYear.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["PassingYear"]);
                         cellMarks.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Marks"]);



                         /**********************Experience *********************/
                       
                           cellExpField.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["ExperienceField"]);
                         cellExpYear.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["NoOfYears"]);
                         cellExpDesc.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["ExpDesc"]);

                         /**********************Skills *********************/
                         cellSkills.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Skills"]);
                         cellSkillsDesc.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["SkillsDesc"]);

                         /**********************Photo *********************/
                         ViewState["Photo"] = Convert.ToString(ds.Tables["Data"].Rows[i]["Photo"]);

                         if (ViewState["Photo"] != null)
                         {
                             string path = Server.MapPath("images\\" + ViewState["Photo"].ToString());
                             FileInfo file = new FileInfo(path);
                             if (file.Exists)
                             {

                                 Image1.ImageUrl = "~/images/" + ViewState["Photo"].ToString();
                                 Image1.AlternateText = " Photo ";


                             }
                             else
                             {
                                 Image1.ImageUrl = "~/images/UserPhoto.jpg";
                                 Image1.AlternateText = " Photo ";

                             }

                         }
                         else
                         {
                             Image1.ImageUrl = "~/images/UserPhoto.jpg";
                             Image1.AlternateText = " Photo ";
                         
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


        public void PwdChangeMessage(string Msg)
        {
            lblStatus.Text = Msg;
        }

        protected void linkBtUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UpdateProfile.aspx");
        }
       

       

        protected void linkBtMyDesboard_Click(object sender, EventArgs e)
        {
            return;
        }

        protected void linkViewProfile_Click(object sender, EventArgs e)
        {
            return;
        }

        protected void linkBtChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }

      
        protected void linkUploadResume_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UploadResume.aspx");
            
        }
       

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            
            
            if (e.CommandName == "ViewResume")
            {
                Label lblfile = (Label)GridView1.Rows[index].FindControl("LabelFileName");
                ViewState["filenameResume"] = lblfile.Text.Trim();
                string str = Convert.ToString(ViewState["filenameResume"]);
               

                if (ViewState["filenameResume"] != null)
                {
                    string path = Server.MapPath("Resume\\" + Convert.ToString(ViewState["filenameResume"]));
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)
                    {
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
                        lblMsgResume.Text = "* Resume is not available";

                    }

                }
                else
                {
                    lblMsgResume.Text = "* Resume is not available";
                }

            }

            if (e.CommandName == "DeleteResume")
            {
                Label lblfile = (Label)GridView1.Rows[index].FindControl("LabelFileName");
                ViewState["filenameResume"] = lblfile.Text.Trim();
                string str = Convert.ToString(ViewState["filenameResume"]);
                SqlCommand com = new SqlCommand();
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                try
                {
                    if (File.Exists(Server.MapPath(("~/Resume/" + Convert.ToString(ViewState["filenameResume"])))))
                    {
                        File.Delete(Server.MapPath(("~/Resume/" + Convert.ToString(ViewState["filenameResume"]))));

                        com.CommandText = "DELETE FROM JobSeekerResume WHERE FileName=@FileName";
                        com.Parameters.Add("@FileName", SqlDbType.VarChar, 50).Value = Convert.ToString(ViewState["filenameResume"]);
                        com.Connection = connection;
                        com.ExecuteNonQuery();
                        lblMsgResume.Text = "* Resume is deleted sucessfully";
                        
                    }
                    else
                    {
                        lblMsgResume.Text = "* Resume is does not exist";
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    lblMsgResume.Text = "* Error occurs";
                }
                finally
                {
                    com.Dispose();
                    DisplayResumeList();
                    
                }

            }
            DisplayResumeList();
        }

        protected void DisplayEmployerList()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da;
            DataSet ds = new DataSet();


            com.CommandText = "SELECT     JobSeekerAppliedJob.JobID, EmployerDetails.UserCode AS EmployerCode, JobSeekerAppliedJob.JobSeekerUserCode, JobSeekerAppliedJob.EmployerView, CONVERT(varchar, JobSeekerAppliedJob.ViewDate, 106) AS ViewDate, EmployerSubmitJobs.JobTitle, EmployerSubmitJobs.Location, RegistrationTable.Email, EmployerDetails.CompanyName, EmployerDetails.Website, ISNULL(EmployerSubmitJobs.ExpMin, 0) AS ExpMin, ISNULL(EmployerSubmitJobs.ExpMax, 0) AS ExpMax, 'http://' + EmployerDetails.Website AS FullWebsite FROM  JobSeekerAppliedJob INNER JOIN EmployerSubmitJobs ON JobSeekerAppliedJob.JobID = EmployerSubmitJobs.JobID INNER JOIN RegistrationTable ON EmployerSubmitJobs.UserCode = RegistrationTable.UserCode INNER JOIN EmployerDetails ON RegistrationTable.UserCode = EmployerDetails.UserCode WHERE  (JobSeekerAppliedJob.EmployerView = 1) AND (JobSeekerAppliedJob.JobSeekerUserCode = @JobSeekerUserCode) ORDER BY JobSeekerAppliedJob.ViewDate DESC";

            com.Parameters.Add("@JobSeekerUserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);

            com.Connection = connection;
            da = new SqlDataAdapter(com);
            da.Fill(ds, "Data");
            GridView2.DataSource = ds;
            GridView2.DataBind();
        
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

          
            if (e.CommandName == "Remove")
            {
                Label lblfile = (Label)GridView2.Rows[index].FindControl("lblJobID");
             
                string str = lblfile.Text.Trim();
                SqlCommand com = new SqlCommand();
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

              
                com.CommandText = "UPDATE JobSeekerAppliedJob SET EmployerView = 0,ViewDate=null WHERE JobID = @JobID AND JobSeekerUserCode = @JobSeekerUserCode";
                com.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = str.Trim();
                com.Parameters.Add("@JobSeekerUserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                com.Connection = connection;
                com.ExecuteNonQuery();
                lblResultEmployer.Text = "* Employer is removed successfully";
                  
            
            }
            DisplayEmployerList();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            DisplayEmployerList();
        }

           

    }
}
