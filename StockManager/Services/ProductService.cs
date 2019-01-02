using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StockManager.Data;
using StockManager.Data.Entities;
using StockManager.IServices;

namespace StockManager.Service
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext db;
        public ProductService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool Create(Product product)
        {
            bool response = false;
            try
            {
                db.Add(product);
                db.SaveChanges();
                response = true;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        public bool Delete(int id)
        {
            bool response = false;
            try
            {
                Product product = db.Products.FirstOrDefault(x => x.Id == id);
                db.Products.Remove(product);
                db.SaveChanges();
                response = true;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
            return response;
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