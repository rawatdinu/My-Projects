using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BLL
{
   public class BooksMaster
    {
        public string BookID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Author { get; set; }
        public string Publication { get; set; }
        public int EditionNo { get; set; }
        public int EditionYear { get; set; }
        public int Price { get; set; }

    }
}
