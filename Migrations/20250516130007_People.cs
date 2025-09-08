using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace library.Migrations
{
    /// <inheritdoc />
    public partial class People : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_People_Role_People_Role_Id",
                table: "People");

            migrationBuilder.DropTable(
                name: "People_Role");

            migrationBuilder.DropIndex(
                name: "IX_People_People_Role_Id",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "People_Password",
                table: "People",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "People_Role_Id",
                table: "People",
                newName: "AccessFailedCount");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "People",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "People",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "People",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "People",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "People",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityRole<int>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<int>", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole<int>",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Librarian", "LIBRARIAN" },
                    { 3, null, "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole<int>");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "People");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "People");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "People");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "People");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "People");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "People",
                newName: "People_Password");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "People",
                newName: "People_Role_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "People_Password",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "People_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_People_Role_Id",
                table: "People",
                column: "People_Role_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_Role_People_Role_Id",
                table: "People",
                column: "People_Role_Id",
                principalTable: "People_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
