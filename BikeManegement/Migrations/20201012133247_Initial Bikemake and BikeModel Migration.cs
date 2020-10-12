using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeManegement.Migrations
{
    public partial class InitialBikemakeandBikeModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeMakers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakerName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeMakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bikeModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(maxLength: 255, nullable: false),
                    BikeMakerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bikeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bikeModels_BikeMakers_BikeMakerId",
                        column: x => x.BikeMakerId,
                        principalTable: "BikeMakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bikeModels_BikeMakerId",
                table: "bikeModels",
                column: "BikeMakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bikeModels");

            migrationBuilder.DropTable(
                name: "BikeMakers");
        }
    }
}
