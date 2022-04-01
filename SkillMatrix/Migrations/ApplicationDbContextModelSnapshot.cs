﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillMatrix.Data;

#nullable disable

namespace SkillMatrix.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SkillMatrix.Model.BasicFoundation", b =>
                {
                    b.Property<int>("BasicFoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BasicFoundId"), 1L, 1);

                    b.Property<int>("BEST_PRACTICES")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GIT_OR_REVISION_CONTROL")
                        .HasColumnType("int");

                    b.Property<int>("JIRA_OR_AGILE_PRACTICES")
                        .HasColumnType("int");

                    b.Property<int>("SERVER_UPLOADS_OR_MANAGEMENT")
                        .HasColumnType("int");

                    b.Property<int>("TFS")
                        .HasColumnType("int");

                    b.Property<int>("UNIT_TESTING")
                        .HasColumnType("int");

                    b.HasKey("BasicFoundId");

                    b.ToTable("BasicFoundation");
                });

            modelBuilder.Entity("SkillMatrix.Model.BehaviourDrivenDevelopment", b =>
                {
                    b.Property<int>("BehaviourDrivenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BehaviourDrivenId"), 1L, 1);

                    b.Property<int>("Cucumber")
                        .HasColumnType("int");

                    b.Property<int>("Maven")
                        .HasColumnType("int");

                    b.Property<int>("UserApproach")
                        .HasColumnType("int");

                    b.HasKey("BehaviourDrivenId");

                    b.ToTable("BehaviourDrivenDevelopments");
                });

            modelBuilder.Entity("SkillMatrix.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Band")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportingManager")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("Team")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SkillMatrix.Model.GenericSkills", b =>
                {
                    b.Property<int>("GenericId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenericId"), 1L, 1);

                    b.Property<int>("Adaptability_And_Flexibility")
                        .HasColumnType("int");

                    b.Property<int>("Critical_and_Analytical_Thinking")
                        .HasColumnType("int");

                    b.Property<int>("Customer_Focus")
                        .HasColumnType("int");

                    b.Property<int>("Demonstrate_Teamwork")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Interpersonal_Skills")
                        .HasColumnType("int");

                    b.Property<int>("Leadership_Skills")
                        .HasColumnType("int");

                    b.Property<int>("Management")
                        .HasColumnType("int");

                    b.Property<int>("Negotiation_Skills")
                        .HasColumnType("int");

                    b.Property<int>("Oral_Communication")
                        .HasColumnType("int");

                    b.Property<int>("Planning_And_Organizing")
                        .HasColumnType("int");

                    b.Property<int>("Presentation_skill")
                        .HasColumnType("int");

                    b.Property<int>("Problem_Solving_Skills")
                        .HasColumnType("int");

                    b.Property<int>("Process_Conformance")
                        .HasColumnType("int");

                    b.Property<int>("Takes_Initiative")
                        .HasColumnType("int");

                    b.Property<int>("Written_Communication")
                        .HasColumnType("int");

                    b.HasKey("GenericId");

                    b.ToTable("GenericSkills");
                });

            modelBuilder.Entity("SkillMatrix.Model.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SkillMatrix.Model.TestDrivenDevelopment", b =>
                {
                    b.Property<int>("TestDrivenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestDrivenId"), 1L, 1);

                    b.Property<int>("AdaptabilityFlexibility")
                        .HasColumnType("int");

                    b.Property<int>("CriticalAnalytical")
                        .HasColumnType("int");

                    b.Property<int>("CustomerFocus")
                        .HasColumnType("int");

                    b.Property<int>("DemonstratesTeamwork")
                        .HasColumnType("int");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("InterpersonalSkills")
                        .HasColumnType("int");

                    b.Property<int>("LeadershipSkills")
                        .HasColumnType("int");

                    b.Property<int>("Management")
                        .HasColumnType("int");

                    b.Property<int>("NegotiationSkills")
                        .HasColumnType("int");

                    b.Property<int>("OralCommunication")
                        .HasColumnType("int");

                    b.Property<int>("PlanningOrganizing")
                        .HasColumnType("int");

                    b.Property<int>("PresentationSkills")
                        .HasColumnType("int");

                    b.Property<int>("ProblemSolvingSkills")
                        .HasColumnType("int");

                    b.Property<int>("ProcessConformance")
                        .HasColumnType("int");

                    b.Property<int>("TakesInitiative")
                        .HasColumnType("int");

                    b.Property<int>("WrittenCommunication")
                        .HasColumnType("int");

                    b.HasKey("TestDrivenId");

                    b.ToTable("TestDrivenDevelopments");
                });

            modelBuilder.Entity("SkillMatrix.Model.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("RoleLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
