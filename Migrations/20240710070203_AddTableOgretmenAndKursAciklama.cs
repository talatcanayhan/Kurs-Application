﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursUygulamasi.Migrations
{
    /// <inheritdoc />
    public partial class AddTableOgretmenAndKursAciklama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KursAciklama",
                table: "Kurslar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OgretmenId",
                table: "Kurslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ogretmen",
                columns: table => new
                {
                    OgretmenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmen", x => x.OgretmenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurslar_OgretmenId",
                table: "Kurslar",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitlari_KursId",
                table: "KursKayitlari",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitlari_OgrenciId",
                table: "KursKayitlari",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayitlari_Kurslar_KursId",
                table: "KursKayitlari",
                column: "KursId",
                principalTable: "Kurslar",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayitlari_Ogrenciler_OgrenciId",
                table: "KursKayitlari",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurslar_Ogretmen_OgretmenId",
                table: "Kurslar",
                column: "OgretmenId",
                principalTable: "Ogretmen",
                principalColumn: "OgretmenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursKayitlari_Kurslar_KursId",
                table: "KursKayitlari");

            migrationBuilder.DropForeignKey(
                name: "FK_KursKayitlari_Ogrenciler_OgrenciId",
                table: "KursKayitlari");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurslar_Ogretmen_OgretmenId",
                table: "Kurslar");

            migrationBuilder.DropTable(
                name: "Ogretmen");

            migrationBuilder.DropIndex(
                name: "IX_Kurslar_OgretmenId",
                table: "Kurslar");

            migrationBuilder.DropIndex(
                name: "IX_KursKayitlari_KursId",
                table: "KursKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_KursKayitlari_OgrenciId",
                table: "KursKayitlari");

            migrationBuilder.DropColumn(
                name: "KursAciklama",
                table: "Kurslar");

            migrationBuilder.DropColumn(
                name: "OgretmenId",
                table: "Kurslar");
        }
    }
}
