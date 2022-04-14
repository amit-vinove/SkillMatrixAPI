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
        public IEnumerable<EmpSubSkillsRatingsViewModel> GetEmpSubSkillsRatings(int skillId, int empId)
        {
            var empRatings = (from ratingsDb in _db.SubSkillsRatings
                              join subSkillsDb in _db.SubSkills on
                              ratingsDb.SubSkillId equals subSkillsDb.SubSkillsId
                              where ratingsDb.EmpId == empId && ratingsDb.SkillId == skillId
                              select new EmpSubSkillsRatingsViewModel()
                              {
                                  EmpSubSkillsRatingsId = ratingsDb.SubSkillsRatingsId,
                                  SubSkillName = subSkillsDb.SubskillName,
                                  EmpId = empId,
                                  SkillId = skillId,
                                  Ratings = ratingsDb.Ratings,
                                  IsApproved = ratingsDb.IsApproved,
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
            foreach (var item in EmpsubSkillRatings.subskillRatingArr)
            {
                SubSkillsRatings temp = new SubSkillsRatings();
                temp.SubSkillId = item[0];
                temp.Ratings = item[1];
                temp.EmpId= EmpsubSkillRatings.EmpId;
                temp.SkillId = EmpsubSkillRatings.SkillId;

                _db.SubSkillsRatings.Add(temp);
            }
            _db.SaveChanges();
            return Ok("Success");
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
