using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Service.Library.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    ReleaseDate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "integer", nullable: false),
                    CategoriesCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BooksBookId, x.CategoriesCategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "VP", "SSSR" },
                    { 10, "Bedřich", "Trávníček" },
                    { 8, "Lev Nikolajevič", "Tolstoj" },
                    { 7, "Ernst", "Hemingway" },
                    { 6, "Globální", "Prediktor" },
                    { 9, "J. K.", "Rowling" },
                    { 4, "Emet", "Stirling" },
                    { 3, "Naděžda", "Ivanovna" },
                    { 2, "Lukáš", "Vjargan" },
                    { 5, "William", "Shakespear" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 6, "Fantasy" },
                    { 1, "Educational" },
                    { 2, "Encyclopedia" },
                    { 3, "Fiction" },
                    { 4, "Religion" },
                    { 5, "Sci-Fi" },
                    { 7, "Hobby" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, 2009, "Základy Sociologie 1" },
                    { 2, 1, 2012, "Sad Roste Sám" },
                    { 4, 2, 1994, "Příručka zálesáka" },
                    { 5, 3, 1928, "Ruština pro Samouky" },
                    { 6, 4, 1999, "Pendragon" },
                    { 7, 6, 2001, "Bible" },
                    { 8, 7, 1995, "Stařec a moře" },
                    { 9, 8, 1920, "Vojna a Mír" },
                    { 10, 9, 2003, "Harry Potter" },
                    { 3, 10, 2009, "Zahrádkář" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoriesCategoryId",
                table: "BookCategory",
                column: "CategoriesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
