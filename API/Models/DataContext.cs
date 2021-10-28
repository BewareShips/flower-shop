using API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
              new Item() { ItemID = 100, Name = "A New Day", Price = 3.50M },
              new Item() { ItemID = 101, Name = "The flower of love", Price = 2.73M },
              new Item() { ItemID = 102, Name = "Passion", Price = 4.33M },
              new Item() { ItemID = 103, Name = "I love you", Price = 6.27M },
              new Item() { ItemID = 104, Name = "Evelyn", Price = 3.73M },
              new Item() { ItemID = 105, Name = "You're beautiful", Price = 4.53M },
              new Item() { ItemID = 106, Name = "Amour", Price = 1.89M }
              );

            modelBuilder.Entity<Customer>().HasData(
              new Customer() { CustomerID = 500, Name = "Ajith" },
              new Customer() { CustomerID = 501, Name = "Manasa" },
              new Customer() { CustomerID = 502, Name = "Chandru" },
              new Customer() { CustomerID = 503, Name = "Meeesha" },
              new Customer() { CustomerID = 504, Name = "Aman" },
              new Customer() { CustomerID = 505, Name = "Nikhil" },
              new Customer() { CustomerID = 506, Name = "Bala" },
              new Customer() { CustomerID = 507, Name = "Math" }
              );
        }
    }
}
