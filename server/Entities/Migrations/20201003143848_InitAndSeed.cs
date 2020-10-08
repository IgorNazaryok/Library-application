using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class InitAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");
            migrationBuilder.InsertData(
    table: "Books",
    columns: new[] { "Name", "Amount" },
    values: new object[,]
    {

                    {"Head First Object-Oriented Analysis and Design", 6 },
                    {"Object-Oriented Thought Process, The (Developer's Library)", 2 },
                    {"Object Design Style Guide 1st Edition",  4 },
                    {"The API Economy: Disruption and the Business of APIs", 3 },
                    {"Practices of the Python Pro", 3 },
                    {"Test-Driven Development with Python: Obey the Testing Goat: Using Django, Selenium, and JavaScript", 5 },

    });
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "FullName" },
                values: new object[,]
                {

                    {"Gary Pollice"},
                    {"Dave West"},
                    {"Matt Weisfeld"},
                    {"Matthias Noback"},
                    {"Chris Wood"},
                    {"Art Anthony"},
                    {"Arnaud Lauret"},
                    {"Kristopher Sandoval"},
                    {"Bill Doerrfeld"},
                    {"Dane Hillard"},
                    {"Harry Percival"}

                });
            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "BookId", "AuthorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 5, 10 },
                    { 5, 11 },
                    { 6, 5 },
                    { 6, 9 },
                    { 6, 7 },
                    { 4, 3 }
                });
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "Password", "Role" },
                values: new object[,]
                {
                     {"Garik@gmail.com", "12345", "admin"},
                     {"Alex@gmail.com", "12345", "user"},
                     {"Matt@gmail.com", "12345", "user"},
                     {"Gary@gmail.com", "12345", "user"},
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
