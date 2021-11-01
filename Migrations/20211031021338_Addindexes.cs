using Microsoft.EntityFrameworkCore.Migrations;

namespace CastillePCRTestManagement.Migrations
{
    public partial class Addindexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "BookingMaster",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "BookingInformation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "BookingInformation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "BookingInformation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CancelledStatus",
                table: "BookingInformation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Location",
                table: "Locations",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_BookingMaster_Date",
                table: "BookingMaster",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_BookingMaster_Date_Location",
                table: "BookingMaster",
                columns: new[] { "Date", "Location" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingMaster_Location",
                table: "BookingMaster",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_BookingInformation_BookingDate",
                table: "BookingInformation",
                column: "BookingDate");

            migrationBuilder.CreateIndex(
                name: "IX_BookingInformation_BookingDate_Location",
                table: "BookingInformation",
                columns: new[] { "BookingDate", "Location" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingInformation_BookingDate_Location_FirstName_LastName",
                table: "BookingInformation",
                columns: new[] { "BookingDate", "Location", "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingInformation_Id_CancelledStatus",
                table: "BookingInformation",
                columns: new[] { "Id", "CancelledStatus" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingInformation_Location",
                table: "BookingInformation",
                column: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Locations_Location",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_BookingMaster_Date",
                table: "BookingMaster");

            migrationBuilder.DropIndex(
                name: "IX_BookingMaster_Date_Location",
                table: "BookingMaster");

            migrationBuilder.DropIndex(
                name: "IX_BookingMaster_Location",
                table: "BookingMaster");

            migrationBuilder.DropIndex(
                name: "IX_BookingInformation_BookingDate",
                table: "BookingInformation");

            migrationBuilder.DropIndex(
                name: "IX_BookingInformation_BookingDate_Location",
                table: "BookingInformation");

            migrationBuilder.DropIndex(
                name: "IX_BookingInformation_BookingDate_Location_FirstName_LastName",
                table: "BookingInformation");

            migrationBuilder.DropIndex(
                name: "IX_BookingInformation_Id_CancelledStatus",
                table: "BookingInformation");

            migrationBuilder.DropIndex(
                name: "IX_BookingInformation_Location",
                table: "BookingInformation");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "BookingMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "BookingInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "BookingInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "BookingInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CancelledStatus",
                table: "BookingInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
