using System.Collections.Generic;

namespace TestProject.Entities
{
    public class User : IEntity
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public List<Product> Products { get; set; }
    }
}