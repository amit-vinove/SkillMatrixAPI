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
    public class DevopController : ControllerBase
    {
        public readonly SkillMatrix.Data.ApplicationDbContext _context;
        public DevopController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetDevopsPractices")]
        public async Task<IEnumerable<Devop>> Get()
        {
            return await _context.Devops.ToListAsync();
        }

        [HttpPost("AddDevopsPractice")]
        public async Task<Devop> AddDevops(Devop devop)
        {

            if (devop == null)
                throw new ArgumentNullException("Add Test Devops Practices");

            _context.Devops.Add(devop);
            await _context.SaveChangesAsync();

            return devop;
        }

        [HttpDelete("DeleteDevopsPractices")]
        public async Task<ActionResult> DeleteDevops(int devopId)
        {

            var devop = _context.Devops.Find(devopId);
            _context.Devops.Remove(devop);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "Devops Practice Deleted Successfully",
                    Data = true
                });
        }
    }
}
