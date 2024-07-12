using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Migrations
{
    /// <inheritdoc />
    public partial class AddCargoParametersAndExecutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<double>(
                name: "depth",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "executor",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "height",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "weight",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "width",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "depth",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "executor",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "height",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "width",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
