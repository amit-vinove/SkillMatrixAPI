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
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public QuestionsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllQuestions")]
        public IEnumerable<Questions> GetAllSkills()
        {
            var questions = _db.Questions.ToList();
            return questions;
        }
        [HttpGet("GetAllSkillsInTeam")]
        public async Task<IEnumerable<Skills>> GetAllSkillsInTeam(int teamId)
        {
           
            var skills= await _db.Skills.Where(m => m.TeamId == teamId).ToListAsync();
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
