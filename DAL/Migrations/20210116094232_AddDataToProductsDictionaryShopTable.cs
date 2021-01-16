using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddDataToProductsDictionaryShopTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dictionaries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "მარკეტი" },
                    { 2, "სუპერმარკეტი" },
                    { 3, "ჰიპერმარკეტი" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Brand", "Code", "Description", "Image", "ImportDate", "Name" },
                values: new object[,]
                {
                    { 1, "Apple", "APPLE159", "შეიძინეთ 2020 წლის საუკეთესო მოდელი - Apple iPhone 12 Pro Max Single Sim 512GB Pacific Blue", null, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple iPhone 12 Pro Max" },
                    { 2, "Samsung", "SAMSUNG127", "შეიძინეთ Samsung G986FD Galaxy S20+ Dual Sim 12GB RAM", null, new DateTime(2019, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsung Galaxy S20+" },
                    { 3, "OnePlus", "ONEPLUS8", "შეიძინეთ შეღავათიან ფასად OnePlus 8T Dual Sim 8GB RAM 128GB 5G Global Version Lunar Silver", null, new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "OnePlus 8T" }
                });

            migrationBuilder.InsertData(
                table: "Shop",
                columns: new[] { "Id", "Address", "Name", "TypeId" },
                values: new object[] { 1, "ქ.თბილისი, წერეთლის გამზ. N1", "ზუმერი", 1 });

            migrationBuilder.InsertData(
                table: "Shop",
                columns: new[] { "Id", "Address", "Name", "TypeId" },
                values: new object[] { 2, "ქ. თბილისი, ქავთარაძის 1 (სითი მოლი)", "ალტა", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dictionaries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dictionaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dictionaries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
