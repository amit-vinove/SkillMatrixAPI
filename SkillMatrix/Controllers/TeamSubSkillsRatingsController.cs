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
        [HttpGet("GetTeamSubSkillRatingBySkillIdAndEmpId")]
        public IEnumerable<EmpSubSkillsRatingsViewModel> GetEmpTeamSubSkillsRatings(int skillId, int empId)
        {
            var empRatings = (from ratingsDb in _db.TeamSubskillRatings
                              join teamSubSkillsDb in _db.TeamSubskills on
                              ratingsDb.SubskillId equals teamSubSkillsDb.TeamSubskillsId
                              where ratingsDb.EmpId == empId && ratingsDb.SkillId == skillId
                              select new EmpSubSkillsRatingsViewModel()
                              {
                                  EmpSubSkillsRatingsId = ratingsDb.SubskillRatingsId,
                                  SubSkillName = teamSubSkillsDb.TeamSubskillsName,
                                  EmpId = empId,
                                  SkillId = skillId,
                                  Ratings = ratingsDb.Ratings,
                                  IsApproved = ratingsDb.IsApproved,
                              }).ToList();

            return empRatings;
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
                DateTime Dt = DateTime.Now;
                string Month_Name = Dt.ToString("MMMM");
                string Date = Dt.ToString("d");
                TeamSubskillRatings temp = new TeamSubskillRatings();
                temp.SubskillId = item[0];
                temp.Ratings = item[1];
                temp.EmpId = EmpTeamSubSkillRatings.EmpId;
                temp.SkillId = EmpTeamSubSkillRatings.SkillId;
                temp.SubmittedOn = Date;
                temp.AssessmentMonth = Month_Name;

                _db.TeamSubskillRatings.Add(temp);
            }
            _db.SaveChanges();
            return Ok("Success");
        }
        [HttpPut("ChangeTeamSkillRatingStatus")]
        public TeamSubskillRatings ChangeStatus(TeamSubSkillsRatingStatus teamSubskillRating)
        {
            var empSubskillRating = _db.TeamSubskillRatings.FirstOrDefault(x => x.SubskillRatingsId == teamSubskillRating.TeamSubSkillsRatingsId);
            empSubskillRating.IsApproved = teamSubskillRating.IsApproved;
            _db.TeamSubskillRatings.Update(empSubskillRating);
            _db.SaveChanges();
            return empSubskillRating;
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
