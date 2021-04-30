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
    class StockRepository
    {
    }
    public class StockRepository : BaseRepository<Stock>, Interfaces.IStockRepository
    {
        internal StockRepository(ConfectioneryContext context) : base(context)
        {

        }
    }
}