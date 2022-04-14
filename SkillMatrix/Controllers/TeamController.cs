using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TeamController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetAllTeams")]
        public IEnumerable<Team> GetAllTeams()
        {
           var teams = _db.Teams.ToList();
            return teams;
        }

        [HttpPost("CreateTeam")]
        public Team CreateTeam(Team team)
        {
            _db.Teams.Add(team);
            _db.SaveChanges();
            return team;
        }

        [HttpDelete("DeleteTeam")]
        public async Task<ActionResult> DeleteTeam(int teamId)
        {
            var team = _db.Employees.Find(teamId);
            _db.Employees.Remove(team);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Team Deleted Successfully",
                Data = true
            });
        }


    }
}
