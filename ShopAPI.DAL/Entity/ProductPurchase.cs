using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.DAL.Entity
{
    public class ProductPurchase : EntityBase
    {
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(Purchase))]
        public Guid PurchaseId { get; set; }

        public Product Product { get; set; } = null!;
        public Purchase Purchase { get; set; } = null!;
    }
}
