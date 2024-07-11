using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietSacBackend.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "productEntities",
                columns: new[] { "Id", "CreatedTime", "DeletedTime", "LastUpdatedTime", "category_id", "description", "discount", "image", "name", "price", "quantity" },
                values: new object[,]
                {
                    { "17", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "1", null, null, null, null, null, null },
                    { "18", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "2", null, null, null, null, null, null },
                    { "19", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "3", null, null, null, null, null, null },
                    { "20", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "4", null, null, null, null, null, null },
                    { "21", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "5", null, null, null, null, null, null },
                    { "22", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "6", null, null, null, null, null, null },
                    { "23", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "1", null, null, null, null, null, null },
                    { "24", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "2", null, null, null, null, null, null },
                    { "25", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "3", null, null, null, null, null, null },
                    { "26", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "4", null, null, null, null, null, null },
                    { "27", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "5", null, null, null, null, null, null },
                    { "28", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "6", null, null, null, null, null, null },
                    { "29", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "1", null, null, null, null, null, null },
                    { "30", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "2", null, null, null, null, null, null },
                    { "31", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "3", null, null, null, null, null, null },
                    { "32", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "4", null, null, null, null, null, null },
                    { "33", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "5", null, null, null, null, null, null },
                    { "34", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "6", null, null, null, null, null, null },
                    { "35", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "1", null, null, null, null, null, null },
                    { "36", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "2", null, null, null, null, null, null },
                    { "37", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "3", null, null, null, null, null, null },
                    { "38", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "4", null, null, null, null, null, null },
                    { "39", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "5", null, null, null, null, null, null },
                    { "40", new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2024, 7, 10, 23, 37, 59, 675, DateTimeKind.Unspecified).AddTicks(6015), new TimeSpan(0, 0, 0, 0, 0)), "6", null, null, null, null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "17");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "18");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "19");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "20");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "21");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "22");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "23");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "24");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "25");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "26");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "27");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "28");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "29");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "30");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "31");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "32");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "33");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "34");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "35");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "36");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "37");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "38");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "39");

            migrationBuilder.DeleteData(
                table: "productEntities",
                keyColumn: "Id",
                keyValue: "40");
        }
    }
}
