using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaToPizza.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Spicy" },
                    { 4, "Sweet" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OrderId", "Price" },
                values: new object[,]
                {
                    { 3, 1, "Mozzarella, gorgonzola, parmesan, ricotta", "Four Cheese", null, 9.99m },
                    { 4, 2, "Chicken, BBQ sauce, onions, mozzarella", "BBQ Chicken", null, 10.99m },
                    { 5, 2, "Ham, pineapple, mozzarella", "Hawaiian", null, 9.49m },
                    { 6, 2, "Tomato, peppers, mushrooms, olives", "Veggie Delight", null, 8.49m },
                    { 7, 3, "Spicy salami, tomato, mozzarella, chili flakes", "Diavola", null, 9.99m },
                    { 8, 3, "Jalapeños, beef, onions, mozzarella", "Mexican Heat", null, 10.49m },
                    { 9, 3, "Extra chili, pepperoni, hot sauce", "Inferno", null, 11.49m },
                    { 10, 4, "Nutella spread, strawberries, powdered sugar", "Nutella Pizza", null, 7.99m },
                    { 11, 4, "Apple slices, cinnamon, cream cheese", "Apple Cinnamon", null, 8.49m },
                    { 12, 4, "Banana, caramel sauce, mascarpone", "Banana Caramel", null, 8.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
