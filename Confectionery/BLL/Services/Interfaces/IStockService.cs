using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IStockService
    {
        IEnumerable<StockDTO> GetProducts(int page);
    }
}
