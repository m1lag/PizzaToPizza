using Microsoft.EntityFrameworkCore;
using PizzaToPizza.Models;

namespace PizzaToPizza.Data
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Classic" },
                new Category { Id = 2, Name = "Special" }
            );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Margherita", Description = "Tomato, mozzarella, basil", Price = 6.99M, CategoryId = 1 },
                new Pizza { Id = 2, Name = "Pepperoni", Description = "Tomato, mozzarella, pepperoni", Price = 8.99M, CategoryId = 1 }
            );
        }
    }
}
