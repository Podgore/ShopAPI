namespace ShopAPI.DAL.Entity
{
    public class Client : EntityBase
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
