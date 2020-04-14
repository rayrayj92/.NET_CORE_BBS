using Microsoft.EntityFrameworkCore.Migrations;

namespace esu_v.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EsuFile2",
                table: "Boards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EsuFile2URL",
                table: "Boards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EsuFile3",
                table: "Boards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EsuFile3URL",
                table: "Boards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsuFile2",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "EsuFile2URL",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "EsuFile3",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "EsuFile3URL",
                table: "Boards");
        }
    }
}
