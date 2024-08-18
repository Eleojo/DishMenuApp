using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Menu.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    DishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => new { x.DishId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[] { new Guid("cbb4b3df-010a-4b4c-9f15-ed41635022b4"), "https://veenaazmanov.com/wp-content/uploads/2020/04/Classic-Pizza-Margherita1-500x500.jpg", "Margherita", 4000.0 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b6b24b9f-66a3-45a9-8ce1-0fe81f76325c"), "Mozzarella" },
                    { new Guid("d862d160-f543-4254-9e4c-24b9cdda4438"), "Tomato Sauce" }
                });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" },
                values: new object[,]
                {
                    { new Guid("cbb4b3df-010a-4b4c-9f15-ed41635022b4"), new Guid("b6b24b9f-66a3-45a9-8ce1-0fe81f76325c") },
                    { new Guid("cbb4b3df-010a-4b4c-9f15-ed41635022b4"), new Guid("d862d160-f543-4254-9e4c-24b9cdda4438") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
