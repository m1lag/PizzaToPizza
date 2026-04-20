using Microsoft.EntityFrameworkCore;
using PizzaToPizza.Models;

namespace PizzaToPizza.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }

        public DbSet<PizzaRating> PizzaRatings { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Classic" },
                new Category { Id = 2, Name = "Special" },
                new Category { Id = 3, Name = "Spicy" },
                new Category { Id = 4, Name = "Sweet" }
            );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Margherita", Description = "Tomato, mozzarella, basil", Price = 6.99M, CategoryId = 1 },
                new Pizza { Id = 2, Name = "Pepperoni", Description = "Tomato, mozzarella, pepperoni", Price = 8.99M, CategoryId = 1 },
                new Pizza { Id = 3, Name = "Four Cheese", Description = "Mozzarella, gorgonzola, parmesan, ricotta", Price = 9.99M, CategoryId = 1 },
                new Pizza { Id = 4, Name = "BBQ Chicken", Description = "Chicken, BBQ sauce, onions, mozzarella", Price = 10.99M, CategoryId = 2 },
                new Pizza { Id = 5, Name = "Hawaiian", Description = "Ham, pineapple, mozzarella", Price = 9.49M, CategoryId = 2 },
                new Pizza { Id = 6, Name = "Veggie Delight", Description = "Tomato, peppers, mushrooms, olives", Price = 8.49M, CategoryId = 2 },
                new Pizza { Id = 7, Name = "Diavola", Description = "Spicy salami, tomato, mozzarella, chili flakes", Price = 9.99M, CategoryId = 3 },
                new Pizza { Id = 8, Name = "Mexican Heat", Description = "Jalapeños, beef, onions, mozzarella", Price = 10.49M, CategoryId = 3 },
                new Pizza { Id = 9, Name = "Inferno", Description = "Extra chili, pepperoni, hot sauce", Price = 11.49M, CategoryId = 3 },
                new Pizza { Id = 10, Name = "Nutella Pizza", Description = "Nutella spread, strawberries, powdered sugar", Price = 7.99M, CategoryId = 4 },
                new Pizza { Id = 11, Name = "Apple Cinnamon", Description = "Apple slices, cinnamon, cream cheese", Price = 8.49M, CategoryId = 4 },
                new Pizza { Id = 12, Name = "Banana Caramel", Description = "Banana, caramel sauce, mascarpone", Price = 8.99M, CategoryId = 4 }
            );
        }
    }
}
