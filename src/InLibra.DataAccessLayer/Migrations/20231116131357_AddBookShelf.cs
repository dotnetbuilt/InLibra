using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InLibra.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddBookShelf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelves_ShelfId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ShelfId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ShelfId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BookShelves",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShelfId = table.Column<long>(type: "bigint", nullable: false),
                    BookId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShelves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookShelves_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookShelves_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookShelves_BookId",
                table: "BookShelves",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookShelves_ShelfId",
                table: "BookShelves",
                column: "ShelfId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookShelves");

            migrationBuilder.AddColumn<long>(
                name: "ShelfId",
                table: "Books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ShelfId",
                table: "Books",
                column: "ShelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelves_ShelfId",
                table: "Books",
                column: "ShelfId",
                principalTable: "Shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
