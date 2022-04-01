using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubSkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SubSkillsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllSubskills")]
        public IEnumerable<Subskills> GetAllSkills()
        {
            var skills = _db.Subskills.ToList();
            return skills;
        }

        [HttpPost("AddSubskill")]
        public Subskills CreateSkills(Subskills subskill)
        {
            _db.Subskills.Add(subskill);
            _db.SaveChanges();
            return subskill;
        }

        [HttpDelete("DeleteSubskill")]
        public async Task<ActionResult> DeleteSubskills(int subskillId)
        {
            var subskill = _db.Subskills.Find(subskillId);
            _db.Subskills.Remove(subskill);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Subskill Deleted Successfully",
                Data = true
            });
        }
    }
}
