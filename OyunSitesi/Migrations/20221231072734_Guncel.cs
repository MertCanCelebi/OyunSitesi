using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OyunSitesi.Migrations
{
    public partial class Guncel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_KullaniciId",
                table: "Yorumlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_OyunId",
                table: "Yorumlar",
                column: "OyunId");

            migrationBuilder.CreateIndex(
                name: "IX_Oyunlar_KategoriId",
                table: "Oyunlar",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oyunlar_Kategoriler_KategoriId",
                table: "Oyunlar",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Kullanicilar_KullaniciId",
                table: "Yorumlar",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Oyunlar_OyunId",
                table: "Yorumlar",
                column: "OyunId",
                principalTable: "Oyunlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oyunlar_Kategoriler_KategoriId",
                table: "Oyunlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Kullanicilar_KullaniciId",
                table: "Yorumlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Oyunlar_OyunId",
                table: "Yorumlar");

            migrationBuilder.DropIndex(
                name: "IX_Yorumlar_KullaniciId",
                table: "Yorumlar");

            migrationBuilder.DropIndex(
                name: "IX_Yorumlar_OyunId",
                table: "Yorumlar");

            migrationBuilder.DropIndex(
                name: "IX_Oyunlar_KategoriId",
                table: "Oyunlar");
        }
    }
}
