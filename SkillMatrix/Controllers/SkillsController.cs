using Microsoft.AspNetCore.Cors;
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

    public class SkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SkillsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllSkills")]
        public IEnumerable<Skills> GetAllSkills()
        {
            var skills = _db.Skills.ToList();
            return skills;
        }

        [HttpPost("AddSkill")]
        public Skills CreateSkills(Skills skill)
        {
            _db.Skills.Add(skill);
            _db.SaveChanges();
            return skill;
        }

        [HttpDelete("DeleteSkill")]
        public async Task<ActionResult> DeleteSkills(int skillId)
        {
            var skill = _db.Skills.Find(skillId);
            _db.Skills.Remove(skill);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Skill Deleted Successfully",
                Data = true
            });
        }
    }
}
