using System.ComponentModel.DataAnnotations;

namespace ShopAPI.DAL.Entity
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
