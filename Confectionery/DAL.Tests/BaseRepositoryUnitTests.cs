using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using Moq;
namespace DAL.Tests { 
    class TestStockRepository : BaseRepository<Stock> 
    { 
        public TestStockRepository(DbContext context) : base(context) 
        { 
        } 
    } 
    public class BaseRepositoryUnitTests 
    {
        [Fact] 
        public void Create_InputStockInstance_CalledAddMethodOfDBSetWithStockInstance() 
        { 
            // Arrange 
            DbContextOptions opt = new DbContextOptionsBuilder<ConfectioneryContext>().Options;
            var mockContext = new Mock<ConfectioneryContext>(opt);
            var mockDbSet = new Mock<DbSet<Stock>>();
            mockContext.Setup(context => context.Set<Stock>()).Returns(mockDbSet.Object);
            var repository = new TestStockRepository(mockContext.Object);
            Stock expectedStock = new Mock<Stock>().Object;

            //Act 
            repository.Create(expectedStock);

            // Assert 
            mockDbSet.Verify(dbSet => dbSet.Add(expectedStock), Times.Once());
        } 
        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg() 
        {
            // Arrange 
            DbContextOptions opt = new DbContextOptionsBuilder<ConfectioneryContext>().Options;
            var mockContext = new Mock<ConfectioneryContext>(opt);
            var mockDbSet = new Mock<DbSet<Stock>>();
            mockContext.Setup(context => context.Set<Stock>()).Returns(mockDbSet.Object);
            var repository = new TestStockRepository(mockContext.Object);

            Stock expectedStock = new Stock() { vendor_code = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStock.vendor_code)).Returns(expectedStock);

            //Act 
            repository.Delete(expectedStock.vendor_code);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStock.vendor_code), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedStock), Times.Once());
        } 
        
        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId() { 
            // Arrange 
            DbContextOptions opt = new DbContextOptionsBuilder<ConfectioneryContext>().Options; 
            var mockContext = new Mock<ConfectioneryContext>(opt); 
            var mockDbSet = new Mock<DbSet<Stock>>();
            mockContext.Setup(context => context.Set<Stock>()).Returns(mockDbSet.Object);
            Stock expectedStock = new Stock() { vendor_code = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStock.vendor_code)).Returns(expectedStock);
            var repository = new TestStockRepository(mockContext.Object); 
            
            //Act 
            var actualStock = repository.Get(expectedStock.vendor_code);

            // Assert 
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStock.vendor_code), Times.Once());
            Assert.Equal(expectedStock, actualStock);
        } 
    }
}