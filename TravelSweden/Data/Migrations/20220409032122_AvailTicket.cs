using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelSweden.Data.Migrations
{
    public partial class AvailTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachedFlightId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsFreeLuggage = table.Column<bool>(type: "bit", nullable: false),
                    IsFreeFood = table.Column<bool>(type: "bit", nullable: false),
                    IsFreeCancellation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableTicket_Flight_AttachedFlightId",
                        column: x => x.AttachedFlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTicket_AttachedFlightId",
                table: "AvailableTicket",
                column: "AttachedFlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableTicket");
        }
    }
}
