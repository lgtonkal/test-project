using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestProject.DataAccess;
using TestProject.Entities;

namespace TestProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //InsertData();
            
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        
        
        private static void InsertData()
        {
            using(var context = new TestContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds a user
                var user = new User
                {
                    Username = "Admin",
                    Password = "123"
                };
                context.Users.Add(user);

                // Adds some products
                context.Products.Add(new Product
                {
                    Name = "The Lord of the Rings",
                    Description = "The Lord of the Rings",
                    Price = 200,
                    User = user
                });
                context.Products.Add(new Product
                {
                    Name = "The Sealed Letter",
                    Description = "Emma",
                    Price = 20,
                    User = user
                });

                // Saves changes
                context.SaveChanges();
            }
        }
    }
}