using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursUygulamasi.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSetKursKayitlari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurslar_Ogretmen_OgretmenId",
                table: "Kurslar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ogretmen",
                table: "Ogretmen");

            migrationBuilder.RenameTable(
                name: "Ogretmen",
                newName: "Ogretmenler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ogretmenler",
                table: "Ogretmenler",
                column: "OgretmenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurslar_Ogretmenler_OgretmenId",
                table: "Kurslar",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurslar_Ogretmenler_OgretmenId",
                table: "Kurslar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ogretmenler",
                table: "Ogretmenler");

            migrationBuilder.RenameTable(
                name: "Ogretmenler",
                newName: "Ogretmen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ogretmen",
                table: "Ogretmen",
                column: "OgretmenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurslar_Ogretmen_OgretmenId",
                table: "Kurslar",
                column: "OgretmenId",
                principalTable: "Ogretmen",
                principalColumn: "OgretmenId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
