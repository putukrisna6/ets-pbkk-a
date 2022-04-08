using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelSweden.Data.Migrations
{
    public partial class FlighrRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightRoute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    OriginAirportId = table.Column<int>(type: "int", nullable: false),
                    DestAirportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightRoute_Airport_DestAirportId",
                        column: x => x.DestAirportId,
                        principalTable: "Airport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FlightRoute_Airport_OriginAirportId",
                        column: x => x.OriginAirportId,
                        principalTable: "Airport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightRoute_DestAirportId",
                table: "FlightRoute",
                column: "DestAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightRoute_OriginAirportId",
                table: "FlightRoute",
                column: "OriginAirportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightRoute");
        }
    }
}
