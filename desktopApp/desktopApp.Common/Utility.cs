using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.IO;

namespace desktopApp.Common
{
    public class Utility
    {
        #region Contants
        public const string TicTacGoeAdminEmailId = "keyideas@keyideasglobal.com";
        public const string ForgetPasswordEmailSubject = "TicTacGoe - Forgot password";
        public const string TicketInformationEmailSubject = "TicTacGoe - Ticket Detail";
        private const string ViewFolder = "View/";
        public static string BaseURL = ConfigurationManager.AppSettings["BaseURL"];
        public static string VD = BaseURL + ConfigurationManager.AppSettings["VD"];
        public static string EmailIdExists = ConfigurationManager.AppSettings["EmailIdExists"];
        public static string BeforeLogin = ConfigurationManager.AppSettings["BeforeLogin"];
        public static string EmailRequired = Utility.GetConfigValue("EmailRequired");
        //public static string BaseURL = ConfigurationManager.AppSettings["BaseURL"];

        #endregion
        #region Email Functions
        public static string SendEMailForContactUs(string strMessageBody, string strToEmail, string strFromEmail, string strMailSubject, string strUserName)
        {
            System.Net.Mail.MailMessage objEmail = new System.Net.Mail.MailMessage();
            string status = string.Empty;

            try
            {
                if (strToEmail.Trim().Length > 0)
                {
                    objEmail.To.Add(strToEmail);
                }

                if (strFromEmail.Length > 0)
                {
                    objEmail.From = new System.Net.Mail.MailAddress(strFromEmail);
                }
                else
                {
                    objEmail.From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings["FromEmail"].ToString().Trim());
                }

                objEmail.Subject = strMailSubject;
                objEmail.IsBodyHtml = true;
                objEmail.Priority = System.Net.Mail.MailPriority.High;
                objEmail.BodyEncoding = Encoding.UTF8;
                objEmail.Body = strMessageBody;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = System.Configuration.ConfigurationManager.AppSettings["SMTPServer"].ToString().Trim();

                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["SMTPPort"].ToString().Trim()))
                {
                    smtp.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SMTPPort"].ToString().Trim());
                }
                smtp.UseDefaultCredentials = false;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["SMTPUserName"].ToString().Trim(), System.Configuration.ConfigurationManager.AppSettings["SMTPPassword"].ToString().Trim());
                smtp.EnableSsl = false;
                smtp.Send(objEmail);
                status = "success";
            }
            catch (Exception ex)
            {
                status = "Failure sending Mail due to : " + ex.Message.ToString();
                //MyLogger.Logger(ex.Message + "\r\n", " Error in sending Mail in : Utility.cs - SendEMailForContactUs()");
            }
            return status;
        }
        public static string SendEMail(string strMessageBody, string strToEmail, string strCCEmail, string strBCCEmail, string strFromEmail, string strMailSubject)
        {
            MailMessage objEmail = new MailMessage();
            string status = string.Empty;

            try
            {
                if (strToEmail.Trim().Length > 0)
                {
                    objEmail.To.Add(strToEmail);

                }

                if (strCCEmail.Length > 0)
                {
                    objEmail.CC.Add(strCCEmail);

                }
                else
                {
                    try
                    {
                        objEmail.CC.Add(System.Configuration.ConfigurationManager.AppSettings["SMTPCCEmail"].ToString().Trim());
                    }
                    catch (Exception ec)
                    {
                        ec.ToString();
                    }
                }
                if (strBCCEmail.Length > 0)
                {
                    objEmail.Bcc.Add(strBCCEmail);
                }
                else
                {
                    try
                    {
                        objEmail.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["BCCEmail"].ToString().Trim());
                    }
                    catch (Exception eb)
                    {
                        eb.ToString();
                    }
                }
                if (strFromEmail.Length > 0)
                {
                    objEmail.From = new System.Net.Mail.MailAddress(strFromEmail);
                }
                else
                {
                    objEmail.From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings["FromEmail"].ToString().Trim());
                }

                objEmail.Subject = strMailSubject;
                objEmail.IsBodyHtml = true;
                objEmail.Priority = MailPriority.High;
                objEmail.BodyEncoding = Encoding.UTF8;
                objEmail.Body = strMessageBody;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = System.Configuration.ConfigurationManager.AppSettings["SMTPServer"].ToString().Trim();
                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["SMTPPort"].ToString().Trim()))
                {
                    smtp.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SMTPPort"].ToString().Trim());
                }
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["SMTPUserName"].ToString().Trim(), System.Configuration.ConfigurationManager.AppSettings["SMTPPassword"].ToString().Trim());
                smtp.EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableSSL"].ToString().Trim());
                smtp.Send(objEmail);

                status = "success";
            }
            catch (Exception ex)
            {
                status = "Failure sending Mail due to : " + ex.Message.ToString() + "----" + ex.StackTrace;
                //MyLogger.Logger(ex.Message + "\r\n", " Error in sending Mail in : Utility.cs - SendEMail()");
            }
            return status;
        }
        public static string GetPasswordForgetBody(string email)
        {
            string str = "Hi, <br/><br/>";

            str = str + "Thanks for contact us. Please click on below link to reset your new password:" + Environment.NewLine + "<br/><br/>";
            str = str + "<b><a title='Click to reset your password' href='" + VD + ViewFolder + "ResetPassword.aspx?email=" + email + "'> Reset Password</a></b><br/>";

            str = str + Environment.NewLine + Environment.NewLine + "<br/>Thanks, <br/>";
            str = str + "TicTacGoe Team" + "<br/>";
            return str;
        }
        public static string GetTicketInformationBody(string Section, string SeatRow, string SeatColumn, string SeatNumber, string QRCode)
        {
            string str = "Hi, <br/><br/>";

            str = str + "This is the ticket detail you requested for. Please check the below information:" + Environment.NewLine + "<br/><br/>";
            str = str + "<b>Section</b> : " + Section + "<br/>";
            str = str + "<b>Seat Row</b> : " + SeatRow + "<br/>";
            str = str + "<b>Seat Column</b> : " + SeatColumn + "<br/>";
            str = str + "<b>Seat Number</b> : " + SeatNumber + "<br/>";
            str = str + "<b>Qrcode</b> : " + "<img src=\"" + QRCode + "\" height=\"200px\" width=\"300px\"/><br/>";


            str = str + Environment.NewLine + Environment.NewLine + "<br/>Thanks, <br/>";
            str = str + "TicTacGoe Team" + "<br/>";
            return str;
        }
        #endregion
        #region Get Configuration Value
        public static string GetConfigValue(string strKey)
        {
            string strKeyValue = string.Empty;
            try
            {
                strKeyValue = ConfigurationManager.AppSettings[strKey].ToString();
                return strKeyValue;
            }
            catch (Exception ex)
            {
                strKeyValue = ex.ToString();
            }
            return strKeyValue;
        }
        #endregion
    }
}
