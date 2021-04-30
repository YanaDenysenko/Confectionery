using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    class Stock
    {
        public int vendor_code { get; set; }
        public int good_id { get; set; }
        public int amount { get; set; }
        public int price { get; set; }
    }
}
