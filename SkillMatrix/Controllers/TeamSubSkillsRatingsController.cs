using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;
using SkillMatrixAPI.Model;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeamSubSkillsRatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TeamSubSkillsRatingsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllTeamSubSkillsRatings")]
        public IEnumerable<TeamSubskillRatings> GetAllSkills()
        {
            var TeamsubSkillsRatings = _db.TeamSubskillRatings.ToList();
            return TeamsubSkillsRatings;
        }

        [HttpPost("AddTeamSubSkillRatings")]
        public TeamSubskillRatings CreateSubSkillsRatings(TeamSubskillRatings teamSubSkillRatings)
        {
            _db.TeamSubskillRatings.Add(teamSubSkillRatings);
            _db.SaveChanges();
            return teamSubSkillRatings;
        }
        [HttpPost("PostEmpTeamSubSkillRatings")]
        public IActionResult PostTeamSubSkillsRatings(PostEmpTeamSubskillRating EmpTeamSubSkillRatings)
        {
            foreach (var item in EmpTeamSubSkillRatings.teamSubskillRatingArr)
            {
                TeamSubskillRatings temp = new TeamSubskillRatings();
                temp.SubskillId = item[0];
                temp.Ratings = item[1];
                temp.EmpId = EmpTeamSubSkillRatings.EmpId;
                temp.SkillId = EmpTeamSubSkillRatings.SkillId;

                _db.TeamSubskillRatings.Add(temp);
            }
            _db.SaveChanges();
            return Ok("Success");
        }

        [HttpDelete("DeleteTeamSubSkillRatings")]
        public async Task<ActionResult> DeleteTeamSubSkillsRatings(int teamSubSkillRatingId)
        {
            var teamSubSkillRating = _db.TeamSubskillRatings.Find(teamSubSkillRatingId);
            _db.TeamSubskillRatings.Remove(teamSubSkillRating);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Team SubSkill Rating Deleted Successfully",
                Data = true
            });
        }
    }
}
