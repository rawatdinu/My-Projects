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
    public partial class UploadResume : System.Web.UI.Page
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
                
            }
            if (Convert.ToString(Session["UserType"]) != "JobSeeker")
            {
                Response.Redirect("~/Home.aspx");
               
            }

        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            string curDate;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
           
            SqlCommand comSAVE = new SqlCommand();

            try
            {
                Class1 obj = new Class1();
                if(obj.UniqueCode()=="-1")
                {
                    lblResult.Text = "Error";
                    return;
                }
                    
                string FileName = Convert.ToString(Session["UserCode"]) + obj.UniqueCode();
             
                /**********************************Upload file*************************************************************/
                if (FileUploadResume.HasFile)
                {
                    string ext = Path.GetExtension(FileUploadResume.FileName);
                    string resumePath = Server.MapPath("Resume\\");
                    if (ext.ToLower() == ".txt" || ext.ToLower() == ".doc" || ext.ToLower() == ".docx" || ext.ToLower() == ".pdf")
                    {
                        //FileUpload2.FileName.Replace(FileUpload2.FileName, );
                        FileUploadResume.PostedFile.SaveAs(resumePath + FileName + ext);
                        // = FileUpload2.FileName.ToString();            
                      
                        ViewState["Resume"] = FileName + ext;
                    }
                    else
                    {

                        lblResult.Text = "Wrong file type for resume";
                        return;

                    }
                }
                else
                {
                    return;
                }

                /**********************************Save Resume information*******************************************/
                comSAVE.CommandText = "INSERT INTO JobSeekerResume (UserCode ,ResumeTitle ,FileName ,UploadDate) VALUES (@UserCode , @ResumeTitle ,@FileName, @UploadDate)";
                comSAVE.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                comSAVE.Parameters.Add("@ResumeTitle", SqlDbType.VarChar, 100).Value = txtTitle.Text.Trim();
                comSAVE.Parameters.Add("@FileName", SqlDbType.VarChar, 50).Value = Convert.ToString(ViewState["Resume"]);
                comSAVE.Parameters.Add("@UploadDate", SqlDbType.VarChar, 50).Value = DateTime.Now.Date.ToString();

                comSAVE.Connection = connection;
                comSAVE.ExecuteNonQuery();
                lblResult.Text = "* Resume has uploded successfully";
                
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                /*************delete exissting file is exist***************/
                if (File.Exists(Server.MapPath(("~/Resume/" + Convert.ToString(ViewState["Resume"])))))
                    File.Delete(Server.MapPath(("~/Resume/" + Convert.ToString(ViewState["Resume"]))));
                lblResult.Text = "* Error occurs";               
            }
            finally
            {
              comSAVE.Dispose();
            
            }
          
        }
      
        protected void linkBtMyDesboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void linkViewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void linkBtUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UpdateProfile.aspx");
        }

        protected void linkBtChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

      
      


    }
}
