namespace ShopAPI.DAL.Entity
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Сategory { get; set; }
        public string Article { get; set; }
        public double Price { get; set; }

        public List<ProductPurchase> ProductPurchase { get; set; } = null!;
    }
}
