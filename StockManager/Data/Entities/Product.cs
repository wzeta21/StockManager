namespace StockManager.Data.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string ImageUrl { get; set; }
        public double SalePrice { get; set; }
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
        public int BrandId { get; set; }
        public Brand Brands { get; set; }
    }
}