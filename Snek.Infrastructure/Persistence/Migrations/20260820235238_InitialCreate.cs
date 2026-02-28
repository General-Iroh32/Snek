using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snek.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arbeiten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Art = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbeiten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mitwirkende",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vorname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitwirkende", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zeiten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stunden = table.Column<int>(type: "INTEGER", nullable: false),
                    Minuten = table.Column<int>(type: "INTEGER", nullable: false),
                    Sekunden = table.Column<int>(type: "INTEGER", nullable: false),
                    ArbeitenId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zeiten", x => x.Id);
                    table.CheckConstraint("CK_Zeiten_Minuten", "Minuten >= 0 AND Minuten < 60");
                    table.CheckConstraint("CK_Zeiten_Sekunden", "Sekunden >= 0 AND Sekunden < 60");
                    table.CheckConstraint("CK_Zeiten_Stunden", "Stunden >= 0");
                    table.ForeignKey(
                        name: "FK_Zeiten_Arbeiten_ArbeitenId",
                        column: x => x.ArbeitenId,
                        principalTable: "Arbeiten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArbeitenMitwirkende",
                columns: table => new
                {
                    ArbeitenId = table.Column<int>(type: "INTEGER", nullable: false),
                    MitwirkendeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArbeitenMitwirkende", x => new { x.ArbeitenId, x.MitwirkendeId });
                    table.ForeignKey(
                        name: "FK_ArbeitenMitwirkende_Arbeiten_ArbeitenId",
                        column: x => x.ArbeitenId,
                        principalTable: "Arbeiten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArbeitenMitwirkende_Mitwirkende_MitwirkendeId",
                        column: x => x.MitwirkendeId,
                        principalTable: "Mitwirkende",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArbeitenMitwirkende_MitwirkendeId",
                table: "ArbeitenMitwirkende",
                column: "MitwirkendeId");

            migrationBuilder.CreateIndex(
                name: "IX_Zeiten_ArbeitenId",
                table: "Zeiten",
                column: "ArbeitenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArbeitenMitwirkende");

            migrationBuilder.DropTable(
                name: "Zeiten");

            migrationBuilder.DropTable(
                name: "Mitwirkende");

            migrationBuilder.DropTable(
                name: "Arbeiten");
        }
    }
}
