using System.Collections.Generic;

namespace StockManager.Data.Entities
{
    public class Brand : IEntity
    {
        public Brand()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}