using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CLL.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class StockServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new StockService(nullUnitOfWork));
        }

        [Fact]
        public void GetStocks_UserIsManager_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Manager(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IStockService stockService = new StockService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => stockService.GetStocks(0));
        }

        [Fact]
        public void GetStocks_StockFromDAL_CorrectMappingToStockDTO()
        {
            // Arrange
            User user = new Client(1, "test", 1);
            SecurityContext.SetUser(user);
            var stockService = GetStocks();

            // Act
            var actualstockDto = stockService.Getstocks(0).First();

            // Assert
            Assert.True(actualstockDto.VendorCode == 1 && actualstockDto.Name == "testN" && actualstockDto.Description == "testD");
        }

        IStockService GetStocks()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedStock = new Stock() { VendorCode = 1, Name = "testN", Description = "testD", GoodId = 2 };
            var mockDbSet = new Mock<StockRepository>();
            mockDbSet.Setup(z => z.Find(It.IsAny<Func<Stock, bool>>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Stock>() { expectedStock });
            mockContext.Setup(context => context.Stocks).Returns(mockDbSet.Object);
            IStockService productService = new StockService(mockContext.Object);

            return productService;
        }
    }
}