using Microsoft.EntityFrameworkCore.Migrations;

namespace CastillePCRTestManagement.Migrations
{
    public partial class AddUsedSpace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UsedSpace",
                table: "BookingMaster",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsedSpace",
                table: "BookingMaster");
        }
    }
}
