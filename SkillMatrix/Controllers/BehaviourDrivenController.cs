using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Data;
using SkillMatrix.Model;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BehaviourDrivenController : ControllerBase
    {
        public readonly SkillMatrix.Data.ApplicationDbContext _context;
        public BehaviourDrivenController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<BehaviourDrivenDevelopment>> Get()
        {
            return await _context.BehaviourDrivenDevelopments.ToListAsync();
        }
        [HttpPost]
        public async Task<BehaviourDrivenDevelopment> AddBehaviourDriven(BehaviourDrivenDevelopment behaviourDrivenDevelopment)
        {

            if (behaviourDrivenDevelopment == null)
                throw new ArgumentNullException("Add Behaviour Driven Developments");

            _context.BehaviourDrivenDevelopments.Add(behaviourDrivenDevelopment);
            await _context.SaveChangesAsync();

            return behaviourDrivenDevelopment;
        }

        [HttpDelete]
        public async Task<bool> DeleteBehaviourDriven(int behaviourtDrivenId)
        {
            bool isDeleted = false;

            if (behaviourtDrivenId == 0)
                return isDeleted;
            var behaviourDriven = await _context.BehaviourDrivenDevelopments.FirstOrDefaultAsync(m => m.BehaviourDrivenId == behaviourtDrivenId);
            if (behaviourDriven == null)
                return isDeleted;
            _context.BehaviourDrivenDevelopments.Remove(behaviourDriven);
            await _context.SaveChangesAsync();
            isDeleted = true;

            return isDeleted;
        }
    }
}
