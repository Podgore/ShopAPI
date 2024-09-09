using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.DAL.Entity
{
    public class Purchase : EntityBase
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double FullPrice { get; set; }
        public Client Client { get; set; } = null!;

        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }

        public List<ProductPurchase> ProductPurchase { get; set; } = null!;
    }
}
