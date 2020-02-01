using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    Id_Klient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.Id_Klient);
                });

            migrationBuilder.CreateTable(
                name: "Pokoj",
                columns: table => new
                {
                    Nr_Pokoju = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wolny = table.Column<bool>(nullable: false),
                    Liczba_miejsc = table.Column<int>(nullable: false),
                    Standard_pokoju = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokoj", x => x.Nr_Pokoju);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacja",
                columns: table => new
                {
                    Id_Rezerwacji = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_klient = table.Column<int>(nullable: false),
                    nr_pokoju = table.Column<int>(nullable: false),
                    Data_Rozpoczecia_Rezerwacji = table.Column<DateTime>(nullable: false),
                    Data_Zakonczenia_Rezerwacji = table.Column<DateTime>(nullable: false),
                    Cena = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacja", x => x.Id_Rezerwacji);
                });

            migrationBuilder.CreateTable(
                name: "Standard",
                columns: table => new
                {
                    StandardPokoju = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenaStandardu = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standard", x => x.StandardPokoju);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Pokoj");

            migrationBuilder.DropTable(
                name: "Rezerwacja");

            migrationBuilder.DropTable(
                name: "Standard");
        }
    }
}
