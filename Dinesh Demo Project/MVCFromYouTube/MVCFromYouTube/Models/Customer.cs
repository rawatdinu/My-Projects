using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFromYouTube.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public double Amount { get; set; }
    }
}