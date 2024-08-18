using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the composite key for DishIngredient
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId,
            });

            // Configure the relationships
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(d => d.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(i => i.DishIngredients).HasForeignKey(i => i.IngredientId);

            // Seed data with explicit GUIDs
            var dishId = Guid.NewGuid();
            var tomatoSauceId = Guid.NewGuid();
            var mozzarellaId = Guid.NewGuid();

            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = dishId,
                    Name = "Margherita",
                    Price = 4000.00,
                    ImageUrl = "https://veenaazmanov.com/wp-content/uploads/2020/04/Classic-Pizza-Margherita1-500x500.jpg",
                }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = tomatoSauceId,
                    Name = "Tomato Sauce"
                },
                new Ingredient
                {
                    Id = mozzarellaId,
                    Name = "Mozzarella"
                }
            );

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient
                {
                    DishId = dishId,
                    IngredientId = tomatoSauceId,
                },
                new DishIngredient
                {
                    DishId = dishId,
                    IngredientId = mozzarellaId,
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
