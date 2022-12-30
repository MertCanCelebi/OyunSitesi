using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OyunSitesi.Migrations
{
    public partial class YorumTablosuGuncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Yorumlar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Yorumlar");
        }
    }
}
