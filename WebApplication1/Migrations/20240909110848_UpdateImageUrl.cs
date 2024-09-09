using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Magi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Details", "ImageUrl" },
                values: new object[] { new DateTime(2024, 9, 9, 13, 8, 47, 543, DateTimeKind.Local).AddTicks(1429), "i like this villa", "http://dotnetmastery.com/bluevillaimages/villa1.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate" },
                values: new object[] { new DateTime(2024, 9, 9, 13, 8, 47, 543, DateTimeKind.Local).AddTicks(1489), "here is the best villa", "http://dotnetmastery.com/bluevillaimages/villa2.jpg", "Premium Pool Villa", 4, 300.0 });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 3, "", new DateTime(2024, 9, 9, 13, 8, 47, 543, DateTimeKind.Local).AddTicks(1492), "just woow", "http://dotnetmastery.com/bluevillaimages/villa3.jpg", "Luxury Pool Villa", 4, 300.0, 552, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(2024, 9, 9, 13, 8, 47, 543, DateTimeKind.Local).AddTicks(1493), "oh", "http://dotnetmastery.com/bluevillaimages/villa4.jpg", "Diamand Villa", 4, 300.0, 552, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Details", "ImageUrl" },
                values: new object[] { new DateTime(2024, 9, 5, 12, 24, 38, 936, DateTimeKind.Local).AddTicks(303), "hi", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg" });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate" },
                values: new object[] { new DateTime(2024, 9, 5, 12, 24, 38, 936, DateTimeKind.Local).AddTicks(360), "hihi", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "royal2 villa", 5, 202.0 });
        }
    }
}
