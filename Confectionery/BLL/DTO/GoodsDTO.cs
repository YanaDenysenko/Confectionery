using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class GoodsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategorieId { get; set; }
        public int ConfectionerId { get; set; }
    }
}
