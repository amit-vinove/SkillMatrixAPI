using SkillMatrix.Model;
using Microsoft.EntityFrameworkCore;
using SkillMatrixAPI.Model;

namespace SkillMatrix.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSkills> TeamSkills { get; set; }
        public DbSet<TeamSubskills> TeamSubskills { get; set; }
        public DbSet<TeamSubskillRatings> TeamSubskillRatings { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SubSkills> SubSkills { get; set; }
        public DbSet<SubSkillsRatings> SubSkillsRatings { get; set; }
        public DbSet<EmployeeQuestions> EmployeeQuestions { get; set; }
        public DbSet<EmployeeTeamQuestions> EmployeeTeamQuestions { get; set; }
        public DbSet<Approvals> Approvals { get; set; }









    }
}
