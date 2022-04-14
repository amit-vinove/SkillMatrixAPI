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

    public class TeamSubSkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TeamSubSkillsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllTeamSubSkills")]
        public IEnumerable<TeamSubskills> GetAllSkills()
        {
            var TeamsubSkills = _db.TeamSubskills.ToList();
            return TeamsubSkills;
        }

        [HttpPost("AddTeamSubSkill")]
        public TeamSubskills CreateTeamSubSkills(TeamSubskills teamSubSkills)
        {
            _db.TeamSubskills.Add(teamSubSkills);
            _db.SaveChanges();
            return teamSubSkills;
        }

        [HttpDelete("DeleteTeamSubSkills")]
        public async Task<ActionResult> DeleteTeamSubSkills(int teamSubSkillId)
        {
            var teamSubSkill = _db.TeamSubskills.Find(teamSubSkillId);
            _db.TeamSubskills.Remove(teamSubSkill);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Team SubSkill Deleted Successfully",
                Data = true
            });
        }
    }
}
