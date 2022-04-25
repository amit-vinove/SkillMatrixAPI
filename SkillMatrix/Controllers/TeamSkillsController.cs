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

    public class TeamSkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TeamSkillsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllTeamSkills")]
        public IEnumerable<TeamSkills> GetAllSkills()
        {
            var TeamsubSkills = _db.TeamSkills.ToList();
            return TeamsubSkills;
        }

        [HttpGet("GetTeamSkillsByTeamId")]
        public IEnumerable<TeamSkills> GetTeamSkillsByTeamId(int teamId)
        {
            var TeamSkill = (from skillsDB in _db.TeamSkills 
                            join teamDB in _db.Teams on 
                            skillsDB.TeamId equals teamDB.Id
                            where skillsDB.TeamId == teamId 
                            select new TeamSkills()
                            {
                                TeamSkillId = skillsDB.TeamSkillId,
                                TeamSkillName = skillsDB.TeamSkillName,
                                TeamName = teamDB.Name,
                                TeamId = teamId
                            }).ToList();
                            
            return TeamSkill;
        }

        [HttpPost("AddTeamSkill")]
        public TeamSkills CreateTeamSubSkills(TeamSkills teamSkills)
        {
            _db.TeamSkills.Add(teamSkills);
            _db.SaveChanges();
            return teamSkills;
        }

        [HttpDelete("DeleteTeamSkills")]
        public async Task<ActionResult> DeleteTeamSkills(int teamSkillId)
        {
            var teamSkill = _db.TeamSkills.Find(teamSkillId);
            _db.TeamSkills.Remove(teamSkill);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Team Skill Deleted Successfully",
                Data = true
            });
        }
    }
}
