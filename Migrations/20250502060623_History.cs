using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Migrations
{
    /// <inheritdoc />
    public partial class History : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Copy_Id = table.Column<int>(type: "int", nullable: false),
                    People_Id = table.Column<int>(type: "int", nullable: false),
                    History_Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    History_End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Return_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_Book_Copy_Copy_Id",
                        column: x => x.Copy_Id,
                        principalTable: "Book_Copy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_History_People_People_Id",
                        column: x => x.People_Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_Copy_Id",
                table: "History",
                column: "Copy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_History_People_Id",
                table: "History",
                column: "People_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");
        }
    }
}
