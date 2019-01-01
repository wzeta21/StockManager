using System.Collections.Generic;
using StockManager.Data.Entities;

namespace StockManager.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        Category Get(Category category);
        bool Create(Category category);
        bool Update(Category category);
    }
}