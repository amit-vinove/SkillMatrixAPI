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





    }
}
