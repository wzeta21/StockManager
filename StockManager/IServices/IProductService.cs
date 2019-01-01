using System.Collections.Generic;
using StockManager.Data.Entities;

namespace StockManager.IServices
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Get(Product product);
        bool Create(Product product);
        bool Update(Product product);
    }
}