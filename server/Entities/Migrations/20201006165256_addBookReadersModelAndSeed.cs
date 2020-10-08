using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class addBookReadersModelAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookReaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReaders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookReaders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookReaders_BookId",
                table: "BookReaders",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReaders_UserId",
                table: "BookReaders",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "BookReaders",
                columns: new[] { "UserId", "BookId" },
                values: new object[,]
                {
                          { 1, 1 },
                          { 2, 1 },
                          { 3, 2 },
                          { 4, 2 },
                          { 1, 3 },
                          { 2, 3 },
                          { 3, 3 },
                          { 4, 4 },
                          { 1, 5 },
                          { 2, 5 },
                          { 3, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReaders");
        }
    }
}
