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
    [EnableCors("AllowAllOrigins")]
    public class SubSkillsRatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SubSkillsRatingsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllSubSkillsRatings")]
        public IEnumerable<SubSkillsRatings> GetAllSkills()
        {
            var subSkillsRatings = _db.SubSkillsRatings.ToList();
            return subSkillsRatings;
        }

        [HttpPost("AddSubSkillRatings")]
        public SubSkillsRatings CreateSubSkillsRatings(SubSkillsRatings subSkillRatings)
        {
            _db.SubSkillsRatings.Add(subSkillRatings);
            _db.SaveChanges();
            return subSkillRatings;
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
