namespace TestProject.Entities
{
    public class Product : IEntity
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public User User { get; set; }
        
    }
}