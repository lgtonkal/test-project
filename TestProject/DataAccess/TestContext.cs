using Microsoft.EntityFrameworkCore;
using TestProject.Entities;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TestProject.DataAccess
{
    public class TestContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=test_project;port=3306;user=root;password=123qweasd");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.FullName);
                entity.HasMany(e => e.Products)
                    .WithOne(c => c.User);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description);
                entity.Property(e => e.Price);
                entity.HasOne(e => e.User)
                    .WithMany(c => c.Products);
            });
        }
    }
}