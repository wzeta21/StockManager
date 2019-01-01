using System.Collections.Generic;
using System.Linq;
using StockManager.Data;
using StockManager.Data.Entities;
using StockManager.IServices;

namespace StockManager.Service
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext db;
        public CategoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool Create(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Category Get(Category category)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories.AsEnumerable() ?? null;
        }

        public Category GetById(int id)
        {
            return db.Categories.Where(x => x.Id == id).FirstOrDefault() ?? null;
        }

        public bool Update(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}