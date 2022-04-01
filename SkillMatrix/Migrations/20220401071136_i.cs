using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillMatrix.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalSkills",
                columns: table => new
                {
                    AdditionalSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalSkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalSkills", x => x.AdditionalSkillId);
                });

            migrationBuilder.CreateTable(
                name: "AllAdditionalSkills",
                columns: table => new
                {
                    AllAdditionalSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalSkillId = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    SingleApiCall = table.Column<int>(type: "int", nullable: false),
                    ApolloExpress = table.Column<int>(type: "int", nullable: false),
                    DataLoader = table.Column<int>(type: "int", nullable: false),
                    ProressiveWebAppDev = table.Column<int>(type: "int", nullable: false),
                    Wpf = table.Column<int>(type: "int", nullable: false),
                    Sitecore = table.Column<int>(type: "int", nullable: false),
                    Xamarin = table.Column<int>(type: "int", nullable: false),
                    KenticoCms = table.Column<int>(type: "int", nullable: false),
                    UmbracoCms = table.Column<int>(type: "int", nullable: false),
                    Microservices = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllAdditionalSkills", x => x.AllAdditionalSkillId);
                });

            migrationBuilder.CreateTable(
                name: "BasicFoundation",
                columns: table => new
                {
                    BasicFoundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
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
                name: "BehaviourDrivenDevelopments",
                columns: table => new
                {
                    BehaviourDrivenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cucumber = table.Column<int>(type: "int", nullable: false),
                    Maven = table.Column<int>(type: "int", nullable: false),
                    UserApproach = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BehaviourDrivenDevelopments", x => x.BehaviourDrivenId);
                });

            migrationBuilder.CreateTable(
                name: "Cloud",
                columns: table => new
                {
                    CloudId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Azure = table.Column<int>(type: "int", nullable: false),
                    AWS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cloud", x => x.CloudId);
                });

            migrationBuilder.CreateTable(
                name: "Devops",
                columns: table => new
                {
                    DevopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DockerKubernetes = table.Column<int>(type: "int", nullable: false),
                    WebDb = table.Column<int>(type: "int", nullable: false),
                    CiCd = table.Column<int>(type: "int", nullable: false),
                    CiCdDevopPractice = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devops", x => x.DevopId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportingManager = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<int>(type: "int", nullable: false),
                    Band = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenericSkills",
                columns: table => new
                {
                    GenericId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "JSFrontEnd",
                columns: table => new
                {
                    JSFrontEndId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    HTML_CSS = table.Column<int>(type: "int", nullable: false),
                    Jquery = table.Column<int>(type: "int", nullable: false),
                    AngularJS = table.Column<int>(type: "int", nullable: false),
                    ReactJS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JSFrontEnd", x => x.JSFrontEndId);
                });

            migrationBuilder.CreateTable(
                name: "SDLCProceeses",
                columns: table => new
                {
                    SDLCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Coding_Standards = table.Column<int>(type: "int", nullable: false),
                    Code_Optimization_Techniques = table.Column<int>(type: "int", nullable: false),
                    ER_Diagram = table.Column<int>(type: "int", nullable: false),
                    Swagger_UI = table.Column<int>(type: "int", nullable: false),
                    Postman = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDLCProceeses", x => x.SDLCId);
                });

            migrationBuilder.CreateTable(
                name: "SqlServers",
                columns: table => new
                {
                    SqlServerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoredPocedure = table.Column<int>(type: "int", nullable: false),
                    SqlQueries = table.Column<int>(type: "int", nullable: false),
                    Triggers = table.Column<int>(type: "int", nullable: false),
                    ssrs = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqlServers", x => x.SqlServerId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    RoleLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WebServices",
                columns: table => new
                {
                    WebServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebApi = table.Column<int>(type: "int", nullable: false),
                    Wcf = table.Column<int>(type: "int", nullable: false),
                    Soap = table.Column<int>(type: "int", nullable: false),
                    ThirdParty = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebServices", x => x.WebServiceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalSkills");

            migrationBuilder.DropTable(
                name: "AllAdditionalSkills");

            migrationBuilder.DropTable(
                name: "BasicFoundation");

            migrationBuilder.DropTable(
                name: "BehaviourDrivenDevelopments");

            migrationBuilder.DropTable(
                name: "Cloud");

            migrationBuilder.DropTable(
                name: "Devops");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "GenericSkills");

            migrationBuilder.DropTable(
                name: "JSFrontEnd");

            migrationBuilder.DropTable(
                name: "SDLCProceeses");

            migrationBuilder.DropTable(
                name: "SqlServers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "TestDrivenDevelopments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WebServices");
        }
    }
}
