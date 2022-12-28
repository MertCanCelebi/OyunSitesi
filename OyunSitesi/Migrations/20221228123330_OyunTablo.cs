using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OyunSitesi.Migrations
{
    public partial class OyunTablo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oyunlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OyunAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false),
                    Yorum = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    KategoriId = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyunlar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oyunlar");
        }
    }
}
