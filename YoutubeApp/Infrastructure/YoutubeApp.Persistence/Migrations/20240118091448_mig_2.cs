using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 18, 12, 14, 48, 248, DateTimeKind.Local).AddTicks(2817), "Grocery, Shoes & Games" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 18, 12, 14, 48, 248, DateTimeKind.Local).AddTicks(2823), "Movies" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 18, 12, 14, 48, 248, DateTimeKind.Local).AddTicks(2835), "Toys, Grocery & Games" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 18, 12, 14, 48, 248, DateTimeKind.Local).AddTicks(2840), "Baby" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 18, 12, 14, 48, 248, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 18, 12, 14, 48, 248, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 18, 12, 14, 48, 248, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 18, 12, 14, 48, 248, DateTimeKind.Local).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 18, 12, 14, 48, 251, DateTimeKind.Local).AddTicks(5609), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 0.8392599082349750m, 216.02m, "Refined Concrete Table" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 18, 12, 14, 48, 251, DateTimeKind.Local).AddTicks(5715), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 8.569485466707840m, 245.01m, "Refined Steel Pants" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 52, 49, 806, DateTimeKind.Local).AddTicks(2882), "Music, Sports & Garden" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 52, 49, 806, DateTimeKind.Local).AddTicks(2893), "Clothing & Computers" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 52, 49, 806, DateTimeKind.Local).AddTicks(2900), "Games & Garden" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 52, 49, 806, DateTimeKind.Local).AddTicks(2904), "Home" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 16, 15, 52, 49, 806, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 16, 15, 52, 49, 806, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 16, 15, 52, 49, 806, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 16, 15, 52, 49, 806, DateTimeKind.Local).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 52, 49, 808, DateTimeKind.Local).AddTicks(9263), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 1.853581991880670m, 493.07m, "Practical Soft Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 52, 49, 808, DateTimeKind.Local).AddTicks(9371), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 1.613420598025440m, 901.01m, "Awesome Plastic Computer" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
