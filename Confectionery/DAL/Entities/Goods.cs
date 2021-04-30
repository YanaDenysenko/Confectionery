using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    class Goods
    {
        public int id { get; set; }
        public string name { get; set; }
        public int categorie_id { get; set; }
        public int confectioner_id { get; set; }
    }
}
