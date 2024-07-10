using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication18.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fiyatlandirma",
                columns: table => new
                {
                    FiyatlandirmaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkYeriTipi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SaatlikFiyat = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    GünlükFiyat = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AylıkFiyat = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiyatlandirma", x => x.FiyatlandirmaID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SifreHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "ParkYerleri",
                columns: table => new
                {
                    ParkYeriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkYeriNumarasi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DolulukDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Konum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkYerleri", x => x.ParkYeriID);
                });

            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    AracID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    Plaka = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.AracID);
                    table.ForeignKey(
                        name: "FK_Araclar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    RezervasyonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    ParkYeriID = table.Column<int>(type: "int", nullable: false),
                    BaslangicZamani = table.Column<DateTime>(type: "datetime", nullable: false),
                    BitisZamani = table.Column<DateTime>(type: "datetime", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.RezervasyonID);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_ParkYerleri_ParkYeriID",
                        column: x => x.ParkYeriID,
                        principalTable: "ParkYerleri",
                        principalColumn: "ParkYeriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GirisCikisKayitlari",
                columns: table => new
                {
                    KayitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkYeriID = table.Column<int>(type: "int", nullable: false),
                    AracID = table.Column<int>(type: "int", nullable: false),
                    GirisZamani = table.Column<DateTime>(type: "datetime", nullable: false),
                    CikisZamani = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GirisCikisKayitlari", x => x.KayitID);
                    table.ForeignKey(
                        name: "FK_GirisCikisKayitlari_Araclar_AracID",
                        column: x => x.AracID,
                        principalTable: "Araclar",
                        principalColumn: "AracID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GirisCikisKayitlari_ParkYerleri_ParkYeriID",
                        column: x => x.ParkYeriID,
                        principalTable: "ParkYerleri",
                        principalColumn: "ParkYeriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odemeler",
                columns: table => new
                {
                    OdemeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervasyonID = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OdemeYontemi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OdemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odemeler", x => x.OdemeID);
                    table.ForeignKey(
                        name: "FK_Odemeler_Rezervasyonlar_RezervasyonID",
                        column: x => x.RezervasyonID,
                        principalTable: "Rezervasyonlar",
                        principalColumn: "RezervasyonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_KullaniciID",
                table: "Araclar",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_GirisCikisKayitlari_AracID",
                table: "GirisCikisKayitlari",
                column: "AracID");

            migrationBuilder.CreateIndex(
                name: "IX_GirisCikisKayitlari_ParkYeriID",
                table: "GirisCikisKayitlari",
                column: "ParkYeriID");

            migrationBuilder.CreateIndex(
                name: "IX_Odemeler_RezervasyonID",
                table: "Odemeler",
                column: "RezervasyonID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_KullaniciID",
                table: "Rezervasyonlar",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_ParkYeriID",
                table: "Rezervasyonlar",
                column: "ParkYeriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fiyatlandirma");

            migrationBuilder.DropTable(
                name: "GirisCikisKayitlari");

            migrationBuilder.DropTable(
                name: "Odemeler");

            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "ParkYerleri");
        }
    }
}
