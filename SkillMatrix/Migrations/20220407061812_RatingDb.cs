using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrix.Migrations
{
    public partial class RatingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Subskills");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Subskills");

            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "Subskills");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "AdditionalSkills");

            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "AdditionalSkills");

            migrationBuilder.CreateTable(
                name: "AllAdditionalSkillRatings",
                columns: table => new
                {
                    AllAdditionalSkillRatingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllAdditionalSkillId = table.Column<int>(type: "int", nullable: false),
                    Ratings = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllAdditionalSkillRatings", x => x.AllAdditionalSkillRatingsId);
                });

            migrationBuilder.CreateTable(
                name: "SubskillRatings",
                columns: table => new
                {
                    SubskillRatingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubskillId = table.Column<int>(type: "int", nullable: false),
                    Ratings = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubskillRatings", x => x.SubskillRatingsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllAdditionalSkillRatings");

            migrationBuilder.DropTable(
                name: "SubskillRatings");

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Subskills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Subskills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Ratings",
                table: "Subskills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Skills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "AllAdditionalSkills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "AdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "AdditionalSkills",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
