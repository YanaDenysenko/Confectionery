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
    class CategoriesRepository
    {
    }
    public class CategoriesRepository : BaseRepository<Categories>, Interfaces.ICategoriesRepository
    {
        internal CategoriesRepository(ConfectioneryContext context) : base(context)
        {

        }
    }
}