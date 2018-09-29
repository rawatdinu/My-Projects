using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using desktopApp.DAL.DB;

namespace desktopApp.DAL
{
    public class tbUser
    {
        DBdesktopappDataContext db = new DBdesktopappDataContext();
        #region Properties
        public int Id
        {
            get;
            set;
        }
        private string _fName;
        public string FName
        {
            get { return _fName; }
            set { _fName = value; }
        }
        private string _lName;
        public string LName
        {
            get { return _lName; }
            set { _lName = value; }
        }
        public string UserName
        {
            get { return FName + " " + LName; }
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string CellPhone
        {
            get;
            set;
        }
        private string _emailId;
        public string EmailId
        {
            get;
            set;
        }
        private string _password;
        public string Password
        {
            get;
            set;
        }
        private bool _status;
        public bool Status
        {
            get;
            set;
        }
        public DateTime CreatedDate
        { get; set; }
        public DateTime ModifyDate
        { get; set; }
        public bool Isdeleted { get; set; }
        #endregion
        #region Public Method
        /// <summary>
        /// To convert the DB.tbluser object to tbluser object 
        /// </summary>
        /// <param name="u1"></param>
        /// <returns></returns>
        private tbUser Convert(tblUser u1)
        {
            if (u1 != null)
            {
                this.Id = u1.Id;
                this.FName = u1.FirstName;
                this.LName = u1.LastName;
                this.Password = u1.Password;
                this.ModifyDate = u1.ModifyDate.Value;
                this.CreatedDate = u1.CreatedDate.Value;
                this.EmailId = u1.EmailId;
                this.CellPhone = u1.CellPhoneNo;
                this.PhoneNumber = u1.PhoneNo;
                this.Status = u1.Status.Value;
                this.Isdeleted = u1.IsDeleted.Value;
                return this;
            }
            else { return null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<tbUser> GetUserDetail()
        {
            var user = (from t in db.tblUsers where t.Id != 1 && t.IsDeleted == false select t).ToList();
            user = user.OrderByDescending(o => o.CreatedDate).ToList();
            List<tbUser> list = new List<tbUser>();
            
            if (user != null)
            {
                foreach (var u in user)
                {
                    tbUser u1 = new tbUser();
                    u1.FName = u.FirstName;
                    u1.LName = u.LastName;
                    u1.EmailId = u.EmailId;
                    u1.CellPhone = u.CellPhoneNo;
                    u1.PhoneNumber = u.PhoneNo;
                    u1.Id = u.Id;
                    u1.Password = u.Password;
                    u1.Status = u.Status.Value;
                    if (u.CreatedDate != null)
                        u1.CreatedDate = u.CreatedDate.Value;
                    else
                        u1.CreatedDate = DateTime.Now;
                    if (u.ModifyDate != null)
                        u1.ModifyDate = u.ModifyDate.Value;
                    else
                        u1.ModifyDate = DateTime.Now;
                    list.Add(u1);
                }
                return list;
            }
            else
                return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int InsertUser(tbUser u)
        {
            tblUser u1 = new tblUser();
            tbUser c1 = GetUserDetail().Find(delegate(tbUser o) { return u.EmailId.Trim().Equals(o.EmailId.Trim()); });
            if (c1 != null && c1.Id != u.Id)
            {
                return 0;
            }
            else
            {
                u1.FirstName = u.FName;
                u1.LastName = u.LName;
                u1.EmailId = u.EmailId;
                u1.CellPhoneNo = u.CellPhone;
                u1.PhoneNo = u.PhoneNumber;
                u1.Id = u.Id;
                u1.Password = u.Password;
                u1.Status = u.Status;
                u1.CreatedDate = DateTime.Now;
                u1.ModifyDate = DateTime.Now;
                u1.IsDeleted = false;
                db.tblUsers.InsertOnSubmit(u1);
                db.SubmitChanges();
                return u1.Id;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public tbUser SelectUser(int userId)
        {
            if (userId > 0)
            {
                var uInfo = (from u in db.tblUsers where u.Id == userId select u).SingleOrDefault();
                if (uInfo != null)
                {
                    this.FName = uInfo.FirstName;
                    this.LName = uInfo.LastName;
                    this.EmailId = uInfo.EmailId;
                    this.CellPhone = uInfo.CellPhoneNo;
                    this.PhoneNumber = uInfo.PhoneNo;
                    this.Id = uInfo.Id;
                    this.Password = uInfo.Password;
                    this.Status = uInfo.Status.Value;
                    if (uInfo.CreatedDate != null)
                        this.CreatedDate = uInfo.CreatedDate.Value;
                    else
                        this.CreatedDate = DateTime.Now;
                    if (uInfo.ModifyDate != null)
                        this.ModifyDate = uInfo.ModifyDate.Value;
                    else
                        this.ModifyDate = DateTime.Now;
                    return this;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public bool UpdateUser(tbUser u)
        {
            tblUser u1 = new tblUser();
            var info = (from u2 in db.tblUsers where u2.Id == u.Id select u2).FirstOrDefault();
            tbUser c1 = GetUserDetail().Find(delegate(tbUser o) { return u.EmailId.Trim().Equals(o.EmailId.Trim()); });
            u1 = (tblUser)info;
            if (c1 != null && c1.Id != u.Id)
            {
                return false;
            }
            else
            {
                if (info != null)
                {
                    u1.Id = u.Id;
                    u1.FirstName = u.FName;
                    u1.LastName = u.LName;
                    u1.PhoneNo = u.PhoneNumber;
                    u1.CellPhoneNo = u.CellPhone;
                    u1.EmailId = u.EmailId;
                    //u1.CreatedDate = u.CreatedDate;
                    u1.ModifyDate = DateTime.Now;
                    u1.Password = u.Password;
                    u1.Status = u.Status;

                }
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public bool DeleteUser(int id)
        {
            tblUser u1 = new tblUser();
            
            
            var userDetail = (from det in db.tblUsers where det.Id == id select det).FirstOrDefault();
            
            if (userDetail != null)
            {
                u1 = (DB.tblUser)userDetail;
                u1.Id = id;
                u1.IsDeleted = true;
            }
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// To check whether the user provide the correct combination of user name and password or not
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Exists(string email, string password)
        {
            var user = from u in db.SP_Login(email, password) select u;
            SP_LoginResult userr = (SP_LoginResult)user.FirstOrDefault();

            if (userr != null && userr.Id > 0)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// To get user information by email id
        /// </summary>
        /// <param name="email">A valid email id is required for this function</param>
        /// <returns></returns>
        public string GetUserIdByEmail(string email)
        {
            var uinfo = (from u in db.tblUsers where u.EmailId.Equals(email) && u.IsDeleted == false select u.Id).First();
            if (uinfo > 0)
            {
                string uinf = uinfo.ToString();
                return uinf;
            }
            else
                return string.Empty;
        }
        #endregion
    }
}
