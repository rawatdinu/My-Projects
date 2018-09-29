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

namespace DemoProject
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection connection ;
       
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
           
            if (Session["UserCode"] != null)
            {
                //Response.Write("<script language='javascript'>alert('Plz Log out first');</script>");
               
                Response.Redirect("~/Home.aspx");
                
                return;
                
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Class1 obj = new Class1();
         
            if (obj.IsUserExist(txtEmailID.Text.Trim()) == true)
            {
                lblResult.Text = "* User already exit";
                return;                
            }
            if (connection.State == ConnectionState.Closed)
                connection.Open();
           
            string UserCode = obj.GetCode("Code");
            if (UserCode == "-1")
            {
                lblResult.Text = "Error Occurs";
                return;
            }
             
            SqlTransaction Trans1 = connection.BeginTransaction();
           
                SqlCommand comSave = new SqlCommand();
                SqlCommand comSAVEDetails = new SqlCommand();
                SqlCommand comSAVEQuali = new SqlCommand();
                SqlCommand ComSaveExpSkill = new SqlCommand();
               
                SqlCommand cmdCode = new SqlCommand();
      

                try
                {


                    comSave.CommandText = "Insert into RegistrationTable (UserCode,UserType ,Email,Pwd) values(@UserCode,@UserType,@Email,@Pwd)";

                    comSave.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = UserCode;
                    if (rdoUserType.SelectedItem.Text == "JobSeeker")
                    {
                        comSave.Parameters.Add("@UserType", SqlDbType.VarChar, 50).Value = "JobSeeker";
                        // User Category code for Job Seeker 002
                    }
                   else
                    {
                        comSave.Parameters.Add("@UserType", SqlDbType.VarChar, 50).Value = "Employer";
                        // User Category code for employer 003
                    }

                  
                    comSave.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmailID.Text;
                    comSave.Parameters.Add("@Pwd", SqlDbType.VarChar, 50).Value = txtpwd.Text;
                  
             
                    comSave.Transaction = Trans1;
                    comSave.Connection = connection;
                    comSave.ExecuteNonQuery();

                    /****************************************Job Seeker/Employer***********************************************************/
                    if (rdoUserType.SelectedItem.Text == "JobSeeker")
                    {
                        /***********Save Personal Detais table* JobSeekerPersonalDetails*********/

                        comSAVEDetails.CommandText = "Insert into JobSeekerPersonalDetails (UserCode) values(@UserCode)";
                        comSAVEDetails.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = UserCode;
                       
                        comSAVEDetails.Transaction = Trans1;
                        comSAVEDetails.Connection = connection;
                        comSAVEDetails.ExecuteNonQuery();

                        /***********Save UserCode and Email into JobSeekerQualification **********/

                        comSAVEQuali.CommandText = "Insert into JobSeekerQualification (UserCode) values(@UserCode)";
                        comSAVEQuali.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = UserCode;
                       
                        comSAVEQuali.Transaction = Trans1;
                        comSAVEQuali.Connection = connection;
                        comSAVEQuali.ExecuteNonQuery();

                        /***********Save UserCode and Email into JobSeekerExperience **********/

                        ComSaveExpSkill.CommandText = "Insert into JobSeekerExperience (UserCode) values(@UserCode)";
                        ComSaveExpSkill.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = UserCode;
                       
                        ComSaveExpSkill.Transaction = Trans1;
                        ComSaveExpSkill.Connection = connection;
                        ComSaveExpSkill.ExecuteNonQuery();
                      
                    }
                        /***************************Employer Detaisl*************************/
                    else
                    {
                        comSAVEDetails.CommandText = "INSERT INTO EmployerDetails (UserCode)  VALUES (@UserCode )";
                        comSAVEDetails.Parameters.Add("@UserCode", SqlDbType.VarChar, 50).Value = UserCode;
                     
                        comSAVEDetails.Transaction = Trans1;
                        comSAVEDetails.Connection = connection;
                        comSAVEDetails.ExecuteNonQuery();

                       
                    }


                    /* Update code generater*/
                                       
                    cmdCode.CommandText = "Update CodeGenerator set CurrentValue = CurrentValue + 1 where (Head = 'Code') ";
                    cmdCode.Transaction = Trans1;
                    cmdCode.Connection = connection;
                    cmdCode.ExecuteNonQuery();
                    Trans1.Commit();
                    Session["UserCode"] = UserCode;
                   

                    if (rdoUserType.SelectedItem.Text == "JobSeeker")
                    {

                        Session["UserType"] = "JobSeeker";
                        Response.Redirect("~/Profile.aspx",false);
                        // Go to Job Seeker profile
                    }
                    else if (rdoUserType.SelectedItem.Text == "Employer")
                    {
                        Session["UserType"] = "Employer";
                        Response.Redirect("~/EmployerProfile.aspx", false);
                        // Go to Employer Profile
                    }
                    else
                    {
                        lblResult.Text = "* Error occurs";
                        
                    }
                 
                }


                catch (Exception ex)
                {

                    Response.Write(ex);
                   
                    Trans1.Rollback();
                    lblResult.Text = "Error occurs";

                 
                }
                finally 
                
                {
                    comSave.Dispose();                   
                    connection.Close();
                    cmdCode.Dispose();
                    connection.Close();
                    
                }
               
            }          

      /*

        private bool IsUserExist(string EmailId)        
        {

            SqlCommand command = new SqlCommand();
          
            if(connection.State==ConnectionState.Closed)
              connection.Open();
            
            command.CommandText = "SELECT  Email FROM  RegistrationTable WHERE (Email = @EmailId)";
            command.Parameters.Add("@EmailId", SqlDbType.VarChar, 50).Value = txtEmailID.Text.Trim();
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Dispose();
                connection.Close();
                return true;
            }
            else
            {
                dr.Dispose();
                connection.Close();
                return false;
            }
          
           
        }  
        */

       
    }
}
