using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductCategories");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 18, 13, 8, 54, 651, DateTimeKind.Local).AddTicks(4537), "Movies, Industrial & Health" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 18, 13, 8, 54, 651, DateTimeKind.Local).AddTicks(4545), "Computers" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 18, 13, 8, 54, 651, DateTimeKind.Local).AddTicks(4595), "Home, Toys & Clothing" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedTime", "Name" },
                values: new object[] { new DateTime(2024, 1, 18, 13, 8, 54, 651, DateTimeKind.Local).AddTicks(4602), "Industrial & Movies" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 18, 13, 8, 54, 651, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 18, 13, 8, 54, 651, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 18, 13, 8, 54, 651, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 1, 18, 13, 8, 54, 651, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 18, 13, 8, 54, 654, DateTimeKind.Local).AddTicks(7116), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 4.320748470551170m, 575.07m, "Handcrafted Wooden Soap" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 18, 13, 8, 54, 654, DateTimeKind.Local).AddTicks(7236), 0.8274674960704520m, 257.97m, "Refined Fresh Cheese" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "CreatedTime", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 1, 18, 12, 14, 48, 251, DateTimeKind.Local).AddTicks(5715), 8.569485466707840m, 245.01m, "Refined Steel Pants" });
        }
    }
}
