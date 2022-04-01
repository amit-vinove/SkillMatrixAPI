using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrix.Migrations
{
    public partial class updateAddSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApolloExpress",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "DataLoader",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "KenticoCms",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "Microservices",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "ProressiveWebAppDev",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "SingleApiCall",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "Sitecore",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "UmbracoCms",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "Wpf",
                table: "AllAdditionalSkills");

            migrationBuilder.DropColumn(
                name: "Xamarin",
                table: "AllAdditionalSkills");

            migrationBuilder.AddColumn<string>(
                name: "AllAdditionalSkillName",
                table: "AllAdditionalSkills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllAdditionalSkillName",
                table: "AllAdditionalSkills");

            migrationBuilder.AddColumn<int>(
                name: "ApolloExpress",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DataLoader",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KenticoCms",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Microservices",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProressiveWebAppDev",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SingleApiCall",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sitecore",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UmbracoCms",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wpf",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Xamarin",
                table: "AllAdditionalSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
