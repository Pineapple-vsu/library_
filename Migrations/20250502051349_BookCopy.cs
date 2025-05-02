using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Migrations
{
    /// <inheritdoc />
    public partial class BookCopy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book_Copy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Status_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Copy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Copy_Book_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Copy_Book_Status_Status_Id",
                        column: x => x.Status_Id,
                        principalTable: "Book_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Copy_Book_Id",
                table: "Book_Copy",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Copy_Status_Id",
                table: "Book_Copy",
                column: "Status_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_Copy");
        }
    }
}
