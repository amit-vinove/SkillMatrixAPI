using SkillMatrix.Model;
using Microsoft.EntityFrameworkCore;

namespace SkillMatrix.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TestDrivenDevelopment> TestDrivenDevelopments { get; set; }
        public DbSet<BehaviourDrivenDevelopment> BehaviourDrivenDevelopments { get; set; }
        public DbSet<GenericSkills> GenericSkills { get; set; }
        public DbSet<BasicFoundation> BasicFoundation { get; set; }
        public DbSet<SDLCProceeses> SDLCProceeses { get; set; }
        public DbSet<JSFrontEnd> JSFrontEnd { get; set; }
        public DbSet<Cloud> Cloud { get; set; }
        public DbSet<Devop> Devops { get; set; }
        public DbSet<SqlServer> SqlServers { get; set; }
        public DbSet<WebService> WebServices { get; set; }
        public DbSet<AdditionalSkill> AdditionalSkills { get; set; }
        public DbSet<AllAdditionalSkill> AllAdditionalSkills { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Subskills> Subskills { get; set; }

        public DbSet<SubskillRatings> SubskillRatings { get; set; }

        public DbSet<AllAdditionalSkillRatings> AllAdditionalSkillRatings { get; set; }





    }
}
