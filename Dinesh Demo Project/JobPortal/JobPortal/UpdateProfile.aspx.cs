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
    public partial class UpdateProfile : System.Web.UI.Page
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
          
            if (!IsPostBack)
            {
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

                com.CommandText = "SELECT     RegistrationTable.Email, RegistrationTable.UserType, JobSeekerPersonalDetails.FirstName, JobSeekerPersonalDetails.LastName, CONVERT(varchar(12), JobSeekerPersonalDetails.DOB, 103) AS DOB , JobSeekerPersonalDetails.Gender, JobSeekerPersonalDetails.Address, JobSeekerPersonalDetails.State, JobSeekerPersonalDetails.Country, JobSeekerPersonalDetails.Phone, JobSeekerPersonalDetails.Mobile,JobSeekerPersonalDetails.Photo, JobSeekerQualification.Degree, JobSeekerQualification.PassingYear, JobSeekerQualification.Marks, JobSeekerExperience.ExperienceField, JobSeekerExperience.NoOfYears,   JobSeekerExperience.ExpDesc, JobSeekerExperience.Skills, JobSeekerExperience.SkillsDesc, RegistrationTable.UserCode FROM RegistrationTable INNER JOIN JobSeekerPersonalDetails ON RegistrationTable.UserCode = JobSeekerPersonalDetails.UserCode INNER JOIN JobSeekerQualification ON JobSeekerPersonalDetails.UserCode = JobSeekerQualification.UserCode INNER JOIN  JobSeekerExperience ON JobSeekerQualification.UserCode = JobSeekerExperience.UserCode WHERE     (RegistrationTable.UserCode = @UserCode)";

                com.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                com.Connection = connection;
                da = new SqlDataAdapter(com);
                da.Fill(ds, "Data");




                if (ds.Tables["Data"].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables["Data"].Rows.Count; i++)
                    {
                        /*************PErsonal details*******************/
                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["FirstName"]) == "")
                        {
                            lblUserName.Text = "My Details";
                        }
                        else
                        {
                            lblUserName.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["FirstName"]) + "'s Details";
                        }
                       
                        txtFirstName.Text = Convert .ToString(ds.Tables["Data"].Rows[i]["FirstName"]);
                        txtLastName.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["LastName"]);
                        txtDOB.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["DOB"]);

                        lblEamilId.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Email"]);

                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["Gender"])=="")
                        {
                            ddlistGender.SelectedIndex = -1;
                        }
                            else
                        {
                            ddlistGender.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Gender"]);
                        }
                       
                        txtAddress.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Address"]);
                        txtState.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["State"]);

                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["Country"]) == "")
                        {
                            ddlistCountry.SelectedIndex = -1;
                        }

                        else
                        {
                            ddlistCountry.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Country"]);
                        }
                            

                        txtPhone.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Phone"]);
                        txtMobile.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Mobile"]);
                        ViewState["Photo"] = Convert.ToString(ds.Tables["Data"].Rows[i]["Photo"]);

                        /*************Qualification*******************/
                        txtDegree.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Degree"]);

                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["PassingYear"]) == "")
                        {
                            ddlistPassingYear.SelectedIndex = -1;
                        }

                        else
                        {
                            ddlistPassingYear.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["PassingYear"]);
                        }

                       
                        txtMarks.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Marks"]);

                     

                        /**********************Experience *********************/
                        if (Convert.ToString(ds.Tables["Data"].Rows[i]["ExperienceField"]) == "")
                        {
                            ddlExpField.SelectedIndex = -1;
                        }

                        else
                        {
                            ddlExpField.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["ExperienceField"]);
                        }

                        txtExpYears.Text = (Convert.ToString(ds.Tables["Data"].Rows[i]["NoOfYears"])) == "" ? "0" : Convert.ToString(ds.Tables["Data"].Rows[i]["NoOfYears"]);
                            txtExpDesc.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["ExpDesc"]);
                          
                        /**********************Skills *********************/
                            txtSkills.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["Skills"]);
                            txtSkillsDesc.Text = Convert.ToString(ds.Tables["Data"].Rows[i]["SkillsDesc"]);

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
       
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand();
            string curDate;
           
            SqlCommand ComSAVEDetail = new SqlCommand();
            SqlCommand ComSAVEQuali = new SqlCommand();
            SqlCommand ComSAVEExpSkill = new SqlCommand();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
           
            SqlTransaction Trans1 = connection.BeginTransaction();

            /*********************Leap year Valid date****************************/

            string strDate = txtDOB.Text.Trim();
            string day;
            string month;
            string year;
            day = strDate.Substring(0, 2);
            month = strDate.Substring(3, 2);
            year = strDate.Substring(6, 4);
            strDate = month + "/" + day + "/" + year;
 
            /***************************************UPload Profile Photo****************************************************/
            com.CommandText = "SELECT     REPLACE(CONVERT(varchar, GETDATE(), 112) + CONVERT(varchar(8), GETDATE(), 114), ':', '') AS FileName";
            com.Transaction = Trans1;
            com.Connection = connection;
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            curDate = Convert.ToString(dr["FileName"]);
            string FileName = Convert.ToString(Session["UserCode"]) + curDate;
            dr.Close();
            dr.Dispose();
           
            if (FileUploadPhoto.HasFile)
            {
                string imagePath = Server.MapPath("images\\");
                string ext = Path.GetExtension(FileUploadPhoto.FileName);
                if (ext.ToLower() == ".gif" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg")
                {
                    //  string filenam = Guid.NewGuid().ToString();
                    FileUploadPhoto.PostedFile.SaveAs(imagePath + FileName + ext);

                    ViewState["Photo"] = FileName + ext;

                }
                else
                {
                    lblResult.Text = "Wrong file type for Logo";
                    return;
                }
            }
              

            /***********************************************************************************************/

            try
            {
                

                /*    Ssave personal details */
                ComSAVEDetail.CommandText = "UPDATE JobSeekerPersonalDetails SET FirstName =@FirstName,LastName = @LastName, DOB = @DOB, Gender = @Gender, Address = @Address, State = @State ,Country =@Country ,Phone = @Phone ,Mobile = @Mobile,Photo=@Photo WHERE (UserCode = @UserCode)";

               
                ComSAVEDetail.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = txtFirstName.Text.Trim();
                ComSAVEDetail.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = txtLastName.Text.Trim();
                ComSAVEDetail.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = strDate;

                if (ddlistGender.SelectedIndex == 0)
                {
                    ComSAVEDetail.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = "";
                }
                else
                {
                    ComSAVEDetail.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = ddlistGender.SelectedItem.Text;
                }
               
                ComSAVEDetail.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = txtAddress.Text.Trim();
                ComSAVEDetail.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = txtState.Text.Trim();

                if (ddlistCountry.SelectedIndex == 0)
                {
                    ComSAVEDetail.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = "";
                }

                else
                {
                    ComSAVEDetail.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = ddlistCountry.SelectedItem.Text;
                }

             
                ComSAVEDetail.Parameters.Add("@Phone", SqlDbType.VarChar, 50).Value = txtPhone.Text.Trim();
                ComSAVEDetail.Parameters.Add("@Mobile", SqlDbType.VarChar, 50).Value = txtMobile.Text.Trim();
                ComSAVEDetail.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);
                ComSAVEDetail.Parameters.Add("@Photo", SqlDbType.VarChar, 50).Value = Convert.ToString(ViewState["Photo"]);


                ComSAVEDetail.Transaction = Trans1;
                ComSAVEDetail.Connection = connection;
                ComSAVEDetail.ExecuteNonQuery();

                /**************Save Qualification*****************/

                ComSAVEQuali.CommandText = "UPDATE JobSeekerQualification SET Degree =@Degree,PassingYear= @PassingYear, Marks = @Marks  WHERE (UserCode = @UserCode)";

                ComSAVEQuali.Parameters.Add("@Degree", SqlDbType.VarChar, 50).Value = txtDegree.Text.Trim();

                if (ddlistCountry.SelectedIndex == 0)
                {
                    ComSAVEQuali.Parameters.Add("@PassingYear", SqlDbType.VarChar, 50).Value = "";
                }

                else
                {
                    ComSAVEQuali.Parameters.Add("@PassingYear", SqlDbType.VarChar, 50).Value = ddlistPassingYear.Text;
                }

               
                ComSAVEQuali.Parameters.Add("@Marks", SqlDbType.VarChar, 50).Value = txtMarks.Text.Trim();

                ComSAVEQuali.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);

                ComSAVEQuali.Transaction = Trans1;
                ComSAVEQuali.Connection = connection;
                ComSAVEQuali.ExecuteNonQuery();


                /**************Save Experience Skills*****************/

                ComSAVEExpSkill.CommandText = "UPDATE JobSeekerExperience SET ExperienceField = @ExperienceField,NoOfYears = @NoOfYears ,ExpDesc = @ExpDesc,Skills = @Skills ,SkillsDesc = @SkillsDesc ,UpdateDate = @UpdateDate WHERE  (UserCode = @UserCode)";

                if(ddlExpField.SelectedIndex==0)
                {
                     ComSAVEExpSkill.Parameters.Add("@ExperienceField", SqlDbType.VarChar, 50).Value = "";
                }
                else
                {
                    ComSAVEExpSkill.Parameters.Add("@ExperienceField", SqlDbType.VarChar, 50).Value = ddlExpField.SelectedItem.Text;
                }
               
                ComSAVEExpSkill.Parameters.Add("@NoOfYears", SqlDbType.VarChar, 50).Value = txtExpYears.Text.Trim();
                ComSAVEExpSkill.Parameters.Add("@ExpDesc", SqlDbType.VarChar, 50).Value = txtExpDesc.Text;
                ComSAVEExpSkill.Parameters.Add("@Skills", SqlDbType.VarChar, 50).Value = txtSkills.Text.Trim();
                ComSAVEExpSkill.Parameters.Add("@SkillsDesc", SqlDbType.VarChar, 50).Value = txtSkillsDesc.Text;
                ComSAVEExpSkill.Parameters.Add("@UpdateDate", SqlDbType.VarChar, 50).Value = DateTime.Now.Date;

                ComSAVEExpSkill.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["UserCode"]);

                ComSAVEExpSkill.Transaction = Trans1;
                ComSAVEExpSkill.Connection = connection;
                ComSAVEExpSkill.ExecuteNonQuery();

                Trans1.Commit();
                /*  Redirect to Profile page of user*/
                Response.Redirect("~/Profile.aspx",false);

            }

            catch (Exception ex)
            {
                Response.Write(ex);
                Trans1.Rollback();
                if (File.Exists(Server.MapPath(("~/images/" + ViewState["Photo"]))))
                    File.Delete(Server.MapPath(("~/images/" + ViewState["Photo"])));


                lblResult.Text = "* Error occure";
            }

            finally
            {
                connection.Close();
                ComSAVEDetail.Dispose();
                ComSAVEQuali.Dispose();
                ComSAVEExpSkill.Dispose();
            
            
            }
           
            
        }

      

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void linkViewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void linkBtMyDesboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void linkBtChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }
                   
       
    }
}
