using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietSacBackend.Migrations
{
    public partial class AddUserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "userEntities",
                newName: "lastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "userEntities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "userEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "userEntities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "userEntities");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "userEntities");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "userEntities");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "userEntities",
                newName: "fullName");
        }
    }
}
