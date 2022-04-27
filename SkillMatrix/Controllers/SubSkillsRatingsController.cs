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

    public class SubSkillsRatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SubSkillsRatingsController(ApplicationDbContext db)
        {
            _db = db;

        }
/*        GetSubskill-skillRatingByEmpId*/
        [HttpGet("GetAllSubSkillsRatings")]
        public IEnumerable<SubSkillsRatings> GetAllSkills()
        {
            var subSkillsRatings = _db.SubSkillsRatings.ToList();
            return subSkillsRatings;
        }

        [HttpGet("GetSubSkillRatingBySkillIdAndEmpId")]
        public IEnumerable<EmpSubSkillsRatingsViewModel> GetEmpSubSkillsRatings(int skillId, int empId, string month)
        {
            var empRatings = (from ratingsDb in _db.SubSkillsRatings
                              join subSkillsDb in _db.SubSkills on
                              ratingsDb.SubSkillId equals subSkillsDb.SubSkillsId
                              where ratingsDb.EmpId == empId && ratingsDb.SkillId == skillId && ratingsDb.AssessmentMonth == month
                              select new EmpSubSkillsRatingsViewModel()
                              {
                                  EmpSubSkillsRatingsId = ratingsDb.SubSkillsRatingsId,
                                  SubSkillName = subSkillsDb.SubskillName,
                                  EmpId = empId,
                                  SkillId = skillId,
                                  Ratings = ratingsDb.Ratings,
                                  IsApproved = ratingsDb.IsApproved,
                                  Month = month
                              }).ToList();

            return empRatings;
        }


        [HttpPost("AddSubSkillRatings")]
        public SubSkillsRatings CreateSubSkillsRatings(SubSkillsRatings subSkillRatings)
        {
            _db.SubSkillsRatings.Add(subSkillRatings);
            _db.SaveChanges();
            return subSkillRatings;
        }

        [HttpPost("PostEmpSubSkillRatings")]
        public IActionResult PostSubSkillsRatings(PostEmpSubskillRatingViewModel EmpsubSkillRatings)
        {
            DateTime Dt = DateTime.Now;
            string Month_Name = Dt.ToString("MMMM");
            string Date = Dt.ToString("d");
            foreach (var item in EmpsubSkillRatings.subskillRatingArr)
            {
                SubSkillsRatings temp = new SubSkillsRatings();
                temp.SubSkillId = item[0];
                temp.Ratings = item[1];
                temp.EmpId= EmpsubSkillRatings.EmpId;
                temp.SkillId = EmpsubSkillRatings.SkillId;
                temp.SubmittedOn = Date;
                temp.AssessmentMonth = Month_Name;

                _db.SubSkillsRatings.Add(temp);
            }
            _db.SaveChanges();
            return Ok("Success");
        }

        [HttpPut("ChangeRatingStatus")]
        public SubSkillsRatings ChangeStatus(SubSkillsRatingStatus subskillRating)
        {
            var empSubskillRating = _db.SubSkillsRatings.FirstOrDefault(x => x.SubSkillsRatingsId == subskillRating.SubSkillsRatingsId);
            empSubskillRating.IsApproved = subskillRating.IsApproved;
            _db.SubSkillsRatings.Update(empSubskillRating);
            _db.SaveChanges();
            return empSubskillRating;
        }

        [HttpDelete("DeleteSubSkillRatings")]
        public async Task<ActionResult> DeleteSubSkillsRatings(int subSkillRatingId)
        {
            var subSkillRating = _db.SubSkillsRatings.Find(subSkillRatingId);
            _db.SubSkillsRatings.Remove(subSkillRating);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "SubSkill Rating Deleted Successfully",
                Data = true
            });
        }
    }
}
