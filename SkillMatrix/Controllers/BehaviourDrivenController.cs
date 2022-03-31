using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

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
        [HttpGet("GetBehaviourDriven")]
        public async Task<IEnumerable<BehaviourDrivenDevelopment>> Get()
        {
            return await _context.BehaviourDrivenDevelopments.ToListAsync();
        }
        [HttpPost("AddBehaviourDriven")]
        public async Task<BehaviourDrivenDevelopment> AddBehaviourDriven(BehaviourDrivenDevelopment behaviourDrivenDevelopment)
        {

            if (behaviourDrivenDevelopment == null)
                throw new ArgumentNullException("Add Behaviour Driven Developments");

            _context.BehaviourDrivenDevelopments.Add(behaviourDrivenDevelopment);
            await _context.SaveChangesAsync();

            return behaviourDrivenDevelopment;
        }

        [HttpDelete("DeleteBehaviourDriven")]
        public async Task<ActionResult> DeleteBehaviourDriven(int behaviourDrivenId)
        {
            var behaviourdriven = _context.BehaviourDrivenDevelopments.Find(behaviourDrivenId);
            _context.BehaviourDrivenDevelopments.Remove(behaviourdriven);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "Behaviour Deleted Successfully",
                    Data = true
                });
        }
    }
}
