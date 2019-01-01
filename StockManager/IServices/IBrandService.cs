using System.Collections.Generic;
using StockManager.Data.Entities;

namespace StockManager.IServices
{
    public interface IBrandService
    {
        IEnumerable<Brand> GetAll();
        Brand GetById(int id);
        Brand Get(Brand brand);
        bool Create(Brand brand);
        bool Update(Brand brand);
    }
}