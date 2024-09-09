namespace ShopAPI.Common.DTOs
{
    public class PurchaseResponce
    {
        public DateTime Date { get; set; }
        public double FullPrice { get; set; }
        public Guid ClientId { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
