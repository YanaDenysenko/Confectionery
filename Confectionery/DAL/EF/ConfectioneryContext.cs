using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class ConfectioneryContext : DbContext
    {
        public ConfectioneryContext(DbContextOptions options) : base(options)
        {

        }
    }
}
