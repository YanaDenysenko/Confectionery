using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL.EF;
using System.Linq;

namespace DAL.Repositories.Impl
{
    class GoodsRepository
    {
    }
    public class GoodsRepository : BaseRepository<Goods>, Interfaces.IGoodsRepository
    {
        internal GoodsRepository(ConfectioneryContext context) : base(context)
        {

        }
    }
}

