using Microsoft.EntityFrameworkCore.Migrations;

namespace HAJ.PhoneAPI.Domain.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "PhoneUsers",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false),
                   FirstName = table.Column<string>(maxLength: 32, nullable: true),
                   Surname = table.Column<string>(maxLength: 32, nullable: true),
                   Number = table.Column<string>(maxLength: 32, nullable: true),
                   Street = table.Column<string>(maxLength: 32, nullable: true),
                   Postcode = table.Column<string>(maxLength: 32, nullable: true),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_PhoneUser", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                  name: "PhoneUsers");
        }
    }
}
