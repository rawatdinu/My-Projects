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
using System.Collections.Generic;

namespace DemoProject
{
    public partial class ApplyWithoutRegistration : System.Web.UI.Page
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
            if (Session["UserCode"] != null)
            {
                Response.Redirect("~/Home.aspx");
            }

            if (!IsPostBack)
            {
                List<string> list = new List<string>();
                for(int i=0;i<31;i++)
                {
                    list.Add(i.ToString());
                }
                DropDownListExp.Items.Add("---Select---");
               foreach(string item in list)
               {
               DropDownListExp.Items.Add(new ListItem(item));
               }
            
            }


        }

        protected void ButtonApply_Click(object sender, EventArgs e)
        {

            Class1 obj = new Class1();

            if ( obj.IsUserExist(txtEmailAddress.Text.Trim()) == true)
            {
                lblResult.Text = "* Your are registered user, please login to apply";
             return;
            }
            if (IsAlreadyApply() == true)
            { 
                 lblResult.Text = "* Your have already applied for this job";
            return;
            }
             
            if(connection.State== ConnectionState.Closed)
                { 
                   connection.Open();
                }
           
        
            SqlCommand comSave = new SqlCommand();
            SqlCommand comCode = new SqlCommand();
            Class1 Obj = new Class1();
            if( (Obj.GetCode("File")=="-1") || (Obj.UniqueCode()=="-1"))
            {
                lblResult.Text="Error Occurs";
               return;
            }
           String FileName = Obj.GetCode("File")+ Obj.UniqueCode();
           
            /************************************Save File Code**********************************************************/
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

                        lblResult.Text = "* Wrong file type for resume";
                        return;

                    }
                }
                else
                {
                    lblResult.Text = "* Wrong file type for resume";
                        return;
                }

                 /**********************************************************************************************/
           SqlTransaction Trans1 = connection.BeginTransaction();
          
            try
            {
                
                comSave.CommandText = "INSERT INTO UnRegisterJobSeeker (Name,Experience,JobID,EmailAddress,ContactNo,City,State,Country,Resume,AppliedDate) VALUES (@Name,@Experience,@JobID,@EmailAddress,@ContactNo,@City,@State,@Country,@Resume,@AppliedDate)";

                comSave.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value =txtName.Text.Trim();

                if (DropDownListExp.SelectedIndex == 0)
                {
                    comSave.Parameters.Add("@Experience", SqlDbType.VarChar, 50).Value = "";
                }
                else
                {
                    comSave.Parameters.Add("@Experience", SqlDbType.VarChar, 50).Value = DropDownListExp.Text.Trim();
                }
                
                 comSave.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["JobID"]);
                 comSave.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = txtEmailAddress.Text.Trim();
                 comSave.Parameters.Add("@ContactNo", SqlDbType.VarChar, 50).Value = txtContactNo.Text.Trim();
                 comSave.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = txtCity.Text.Trim();
                 comSave.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = txtState.Text.Trim();
                 comSave.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = txtCountry.Text.Trim();

                 comSave.Parameters.Add("@Resume", SqlDbType.VarChar, 50).Value = Convert.ToString(ViewState["Resume"]);
                 comSave.Parameters.Add("@AppliedDate", SqlDbType.VarChar, 50).Value = DateTime.Now.Date;
                
                comSave.Transaction = Trans1;
                comSave.Connection=connection;
                comSave.ExecuteNonQuery();


                   comCode.CommandText = "Update CodeGenerator set CurrentValue = CurrentValue + 1 where (Head = 'File')";
                   comCode.Transaction = Trans1;
                   comCode.Connection = connection;
                   comCode.ExecuteNonQuery();
                   Trans1.Commit();
                lblResult.Text="* You have successfully applied for selected job";
              
            }


            catch (Exception ex)
            {
                Trans1.Rollback();
                if (File.Exists(Server.MapPath(("~/Resume/" + Convert.ToString(ViewState["Resume"])))))
                    File.Delete(Server.MapPath(("~/Resume/" + Convert.ToString(ViewState["Resume"]))));
                lblResult.Text = "Error occurs";
                
            }
            finally
            {
                comSave.Dispose();
                comCode.Dispose();
                connection.Close();
               
            }

        }
        /*
        private bool IsUserExist(string EmailId)
        {

            SqlCommand command = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            if (connection.State == ConnectionState.Closed)
                connection.Open();

        
                command.CommandText = "SELECT  Email FROM  RegistrationTable WHERE (Email = @EmailId)";
                command.Parameters.Add("@EmailId", SqlDbType.VarChar, 50).Value = txtEmailAddress.Text.Trim();
                command.Connection = connection;
                da = new SqlDataAdapter(command);
                da.Fill(ds, "RegisteredUser");

                if (ds.Tables["RegisteredUser"].Rows.Count > 0)
                {
                    
                    return true;
                }
                else
                {
                    return false;
                   
                }
            
        

        }
          */

        protected bool IsAlreadyApply()
        {
             
                SqlCommand com = new SqlCommand();
                SqlDataAdapter da;
                DataSet ds = new DataSet();

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

              
                   com.CommandText = "SELECT EmailAddress, JobID FROM UnRegisterJobSeeker WHERE(EmailAddress = @EmailAddress) AND (JobID = @JobID)";
                        com.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = txtEmailAddress.Text.Trim();
                        com.Parameters.Add("@JobID", SqlDbType.VarChar, 50).Value = Convert.ToString(Session["JobID"]);
                        com.Connection = connection;
                        da = new SqlDataAdapter(com);
                        da.Fill(ds, "UnRegisteredUser");
                        if (ds.Tables["UnRegisteredUser"].Rows.Count > 0)
                        {
                           
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                   
               
             

            } 
        
        }
    }

