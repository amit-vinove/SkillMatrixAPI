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
        [HttpGet("GetAllSubSkillsInSkills")]
        public async Task<IEnumerable<Subskills>> GetAllSubSkillsInSkills(int skillId)
        {

            var subskills = await _db.Subskills.Where(m => m.SkillId == skillId).ToListAsync();
            return subskills;

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
