using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using BLL.DTO;
using DAL.Repositories.Interfaces;
using AutoMapper;
using DAL.UnitOfWork;
using CLL.Security;
using CLL.Security.Identity;


namespace BLL.Services.Impl
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public StockService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<StockDTO> GetStoks(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Client) && userType != typeof(Manager))
            {
                throw new MethodAccessException();
            }
            var vendorCode = user.VendorCode;
            var stoksEntities = _database.Stocks.Find(z => z.VendorCode == vendorCode, pageNumber, pageSize);
            var mapper = new MapperConfiguration( cfg => cfg.CreateMap<Stock, StockDTO>()).CreateMapper();
            var stocksDto = mapper.Map<IEnumerable<Stock>, List<StockDTO>>(stocksEntities);
            return stocksDto;
        }
    }
}
