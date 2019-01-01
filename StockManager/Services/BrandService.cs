using System.Collections.Generic;
using System.Linq;
using StockManager.Data;
using StockManager.Data.Entities;
using StockManager.IServices;

namespace StockManager.Service
{
    public class BrandService : IBrandService
    {
        private ApplicationDbContext db;
        public BrandService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool Create(Brand brand)
        {
            throw new System.NotImplementedException();
        }

        public Brand Get(Brand brand)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Brand> GetAll()
        {
            return db.Brands.AsEnumerable() ?? null;
        }

        public Brand GetById(int id)
        {
            return db.Brands.Where(x => x.Id == id).FirstOrDefault() ?? null;
        }

        public bool Update(Brand brand)
        {
            throw new System.NotImplementedException();
        }
    }
}