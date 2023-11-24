using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bus_Sation_API.Migrations
{
    /// <inheritdoc />
    public partial class updateBusRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusCompany",
                table: "BusRoutes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DestinationTime",
                table: "BusRoutes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TicketsCount",
                table: "BusRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusCompany",
                table: "BusRoutes");

            migrationBuilder.DropColumn(
                name: "DestinationTime",
                table: "BusRoutes");

            migrationBuilder.DropColumn(
                name: "TicketsCount",
                table: "BusRoutes");
        }
    }
}
