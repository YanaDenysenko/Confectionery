using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ConfectioneryContext db;
        private StockRepository stockRepository;
        private CategoriesRepository categoriesRepository;
        private GoodsRepository goodsRepository;

        public EFUnitOfWork(ConfectioneryContext context)
        {
            db = context;
        }
        public Repositories.Interfaces.IStockRepository Stocks
        {
            get
            {
                if (stockRepository == null)
                    stockRepository = new StockRepository(db);
                return stockRepository;
            }
        }
        public Repositories.Interfaces.IGoodsRepository Goodss
        {
            get
            {
                if (goodsRepository == null)
                    goodsRepository = new GoodsRepository(db);
                return goodsRepository;
            }
        }
        public Repositories.Interfaces.ICategoriesRepository Categoriess
        {
            get
            {
                if (categoriesRepository == null)
                    categoriesRepository = new CategoriesRepository(db);
                return categoriesRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
