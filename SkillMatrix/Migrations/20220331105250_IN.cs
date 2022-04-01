﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrix.Migrations
{
    public partial class IN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BehaviourDrivenDevelopments",
                columns: table => new
                {
                    BehaviourDrivenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cucumber = table.Column<int>(type: "int", nullable: false),
                    Maven = table.Column<int>(type: "int", nullable: false),
                    UserApproach = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BehaviourDrivenDevelopments", x => x.BehaviourDrivenId);
                });

            migrationBuilder.CreateTable(
                name: "TestDrivenDevelopments",
                columns: table => new
                {
                    TestDrivenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    OralCommunication = table.Column<int>(type: "int", nullable: false),
                    WrittenCommunication = table.Column<int>(type: "int", nullable: false),
                    ProcessConformance = table.Column<int>(type: "int", nullable: false),
                    PresentationSkills = table.Column<int>(type: "int", nullable: false),
                    LeadershipSkills = table.Column<int>(type: "int", nullable: false),
                    Management = table.Column<int>(type: "int", nullable: false),
                    InterpersonalSkills = table.Column<int>(type: "int", nullable: false),
                    TakesInitiative = table.Column<int>(type: "int", nullable: false),
                    CriticalAnalytical = table.Column<int>(type: "int", nullable: false),
                    DemonstratesTeamwork = table.Column<int>(type: "int", nullable: false),
                    AdaptabilityFlexibility = table.Column<int>(type: "int", nullable: false),
                    CustomerFocus = table.Column<int>(type: "int", nullable: false),
                    PlanningOrganizing = table.Column<int>(type: "int", nullable: false),
                    NegotiationSkills = table.Column<int>(type: "int", nullable: false),
                    ProblemSolvingSkills = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDrivenDevelopments", x => x.TestDrivenId);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BehaviourDrivenDevelopments");

            migrationBuilder.DropTable(
                name: "TestDrivenDevelopments");

        }
    }
}
