using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BLL
{
    public class Account

    {
        public string ID { get; set; }
        public string AccountHolderName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Category { get; set; } // Category of user
    }
}
