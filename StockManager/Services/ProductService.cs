using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StockManager.Data;
using StockManager.Data.Entities;
using StockManager.IServices;

namespace StockManager.Service{
    public class ProductService : IProductService
    {
        private ApplicationDbContext db;
        public ProductService(ApplicationDbContext db){
            this.db = db;
        }
        public bool Create(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Product Get(Product product)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.AsEnumerable() ?? null;
        }

        public Product GetById(int id)
        {
            return db.Products.Where(x => x.Id == id)
                    .Include(y => y.Categories)
                    .Include(r => r.Brands)
                    .FirstOrDefault() ?? null;
        }

        public bool Update(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}