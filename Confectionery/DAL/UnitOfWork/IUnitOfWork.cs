using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace DAL.UnitOfWork { 
    public interface IUnitOfWork : IDisposable 
    { 
        GoodsRepository Goodss { get; } 
        StockRepository Stocks { get; }
        CategoriesRepository Categoriess { get; }
        void Save(); 
    } 
}
