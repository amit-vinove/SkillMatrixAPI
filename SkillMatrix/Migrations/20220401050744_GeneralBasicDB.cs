using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrix.Migrations
{
    public partial class GeneralBasicDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicFoundation",
                columns: table => new
                {
                    BasicFoundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TFS = table.Column<int>(type: "int", nullable: false),
                    GIT_OR_REVISION_CONTROL = table.Column<int>(type: "int", nullable: false),
                    JIRA_OR_AGILE_PRACTICES = table.Column<int>(type: "int", nullable: false),
                    SERVER_UPLOADS_OR_MANAGEMENT = table.Column<int>(type: "int", nullable: false),
                    BEST_PRACTICES = table.Column<int>(type: "int", nullable: false),
                    UNIT_TESTING = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicFoundation", x => x.BasicFoundId);
                });


            migrationBuilder.CreateTable(
                name: "GenericSkills",
                columns: table => new
                {
                    GenericId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oral_Communication = table.Column<int>(type: "int", nullable: false),
                    Written_Communication = table.Column<int>(type: "int", nullable: false),
                    Process_Conformance = table.Column<int>(type: "int", nullable: false),
                    Presentation_skill = table.Column<int>(type: "int", nullable: false),
                    Leadership_Skills = table.Column<int>(type: "int", nullable: false),
                    Management = table.Column<int>(type: "int", nullable: false),
                    Interpersonal_Skills = table.Column<int>(type: "int", nullable: false),
                    Takes_Initiative = table.Column<int>(type: "int", nullable: false),
                    Critical_and_Analytical_Thinking = table.Column<int>(type: "int", nullable: false),
                    Demonstrate_Teamwork = table.Column<int>(type: "int", nullable: false),
                    Adaptability_And_Flexibility = table.Column<int>(type: "int", nullable: false),
                    Customer_Focus = table.Column<int>(type: "int", nullable: false),
                    Planning_And_Organizing = table.Column<int>(type: "int", nullable: false),
                    Negotiation_Skills = table.Column<int>(type: "int", nullable: false),
                    Problem_Solving_Skills = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericSkills", x => x.GenericId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicFoundation");

            migrationBuilder.DropTable(
                name: "GenericSkills");
        }
    }
}
