using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magi.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "VillaID",
            //    table: "VillaNumbers",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 3, 11, 54, 30, 622, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 3, 11, 54, 30, 622, DateTimeKind.Local).AddTicks(6075));

            //migrationBuilder.CreateIndex(
            //    name: "IX_VillaNumbers_VillaID",
            //    table: "VillaNumbers",
            //    column: "VillaID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_VillaNumbers_Villas_VillaID",
            //    table: "VillaNumbers",
            //    column: "VillaID",
            //    principalTable: "Villas",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);//if villa is deleted, the villa number will be also deleted
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 3, 10, 46, 55, 557, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 3, 10, 46, 55, 557, DateTimeKind.Local).AddTicks(9253));
        }
    }
}
