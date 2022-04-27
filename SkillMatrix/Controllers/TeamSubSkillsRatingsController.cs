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
        public IEnumerable<EmpSubSkillsRatingsViewModel> GetEmpTeamSubSkillsRatings(int skillId, int empId , string month)
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
                                  Month = month
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

        [HttpGet("IsExistRating")]
        public async Task<bool> DeleteExistance(int empId, int skillId, string month)
        {
            var row = (_db.TeamSubskillRatings.Where(r => r.EmpId == empId && r.SkillId == skillId && r.AssessmentMonth == month)).ToList();
            if (row.Count > 0)
            {
                foreach (var item in row)
                {
                    _db.TeamSubskillRatings.Remove(item);
                }
                _db.SaveChanges();
                return true;
            }

            return false;
        }
        [HttpPost("PostEmpTeamSubSkillRatings")]
        public async Task<IActionResult> PostTeamSubSkillsRatings(PostEmpTeamSubskillRating EmpTeamSubSkillRatings)
        {
            foreach (var item in EmpTeamSubSkillRatings.teamSubskillRatingArr)
            {
                DateTime Dt = DateTime.Now;
                string Month_Name = Dt.ToString("MMMM");
                string Date = Dt.ToString("d");

                int empId = EmpTeamSubSkillRatings.EmpId;
                int skillId = EmpTeamSubSkillRatings.SkillId;
                string month = EmpTeamSubSkillRatings.AssessmentMonth;
                await DeleteExistance(empId, skillId, Month_Name);
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
