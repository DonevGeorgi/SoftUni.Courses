using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserContacts",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserContacts", x => new { x.ApplicationUserId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserContacts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber", "Website" },
                values: new object[] { 1, "Gotham City", "imbatman@batman.com", "Bruce", "Wayne", "+359881223344", "www.batman.com" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ContactId",
                table: "AspNetUsers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserContacts_ContactId",
                table: "ApplicationUserContacts",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Contacts_ContactId",
                table: "AspNetUsers",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Contacts_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ApplicationUserContacts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ContactId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "AspNetUsers");
        }
    }
}
