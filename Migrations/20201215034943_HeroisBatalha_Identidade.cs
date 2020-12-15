using Microsoft.EntityFrameworkCore.Migrations;

namespace EFICore.WebAPI.Migrations
{
    public partial class HeroisBatalha_Identidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Herois_Batalhas_BatalhaId1",
                table: "Herois");

            migrationBuilder.DropIndex(
                name: "IX_Herois_BatalhaId1",
                table: "Herois");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "Herois");

            migrationBuilder.DropColumn(
                name: "BatalhaId1",
                table: "Herois");

            migrationBuilder.DropColumn(
                name: "Heroi",
                table: "Armas");

            migrationBuilder.AddColumn<int>(
                name: "HeroiId1",
                table: "Armas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HeroisBatalhas",
                columns: table => new
                {
                    HeroiId = table.Column<int>(nullable: false),
                    BatalhaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroisBatalhas", x => new { x.BatalhaId, x.HeroiId });
                    table.ForeignKey(
                        name: "FK_HeroisBatalhas_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroisBatalhas_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentidadeSecretas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeReal = table.Column<string>(nullable: true),
                    HeroiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentidadeSecretas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentidadeSecretas_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_HeroiId1",
                table: "Armas",
                column: "HeroiId1");

            migrationBuilder.CreateIndex(
                name: "IX_HeroisBatalhas_HeroiId",
                table: "HeroisBatalhas",
                column: "HeroiId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadeSecretas_HeroiId",
                table: "IdentidadeSecretas",
                column: "HeroiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Herois_HeroiId1",
                table: "Armas",
                column: "HeroiId1",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Herois_HeroiId1",
                table: "Armas");

            migrationBuilder.DropTable(
                name: "HeroisBatalhas");

            migrationBuilder.DropTable(
                name: "IdentidadeSecretas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_HeroiId1",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "HeroiId1",
                table: "Armas");

            migrationBuilder.AddColumn<string>(
                name: "BatalhaId",
                table: "Herois",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BatalhaId1",
                table: "Herois",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Heroi",
                table: "Armas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Herois_BatalhaId1",
                table: "Herois",
                column: "BatalhaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Herois_Batalhas_BatalhaId1",
                table: "Herois",
                column: "BatalhaId1",
                principalTable: "Batalhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
