using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.EF
{
    public class ConfectioneryContext : DbContext
    {
        public DbSet<Entities.Stock> Stocks { get; set; }
        public DbSet<Entities.Goods> Goodss { get; set; }
        public DbSet<Entities.Categories> Categoriess { get; set; }
        public ConfectioneryContext(DbContextOptions options) : base(options)
        {

        }
    }
}
