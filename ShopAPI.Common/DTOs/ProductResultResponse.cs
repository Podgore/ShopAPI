namespace ShopAPI.Common.DTOs
{
    public class ProductResultResponse
    {
        public List<Guid> Failed { get; set; } = new List<Guid>();
        public List<Guid> Success { get; set; } = new List<Guid>();
    }
}
