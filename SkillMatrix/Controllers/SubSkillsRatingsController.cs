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
    public class SubSkillsRatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SubSkillsRatingsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllSubskillRatings")]
        public IEnumerable<SubskillRatings> GetAllSkills()
        {
            var subSkillRatings = _db.SubskillRatings.ToList();
            return subSkillRatings;
        }
        
        [HttpPost("AddSubskillRatings")]
        public SubskillRatings CreateSkills(SubskillRatings subskillRatings)
        {
            _db.SubskillRatings.Add(subskillRatings);
            _db.SaveChanges();
            return subskillRatings;
        }

        [HttpDelete("DeleteSubskillRatings")]
        public async Task<ActionResult> DeleteSubskills(int subskillRatingId)
        {
            var subskillRating = _db.SubskillRatings.Find(subskillRatingId);
            _db.SubskillRatings.Remove(subskillRating);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Subskill Rating Deleted Successfully",
                Data = true
            });
        }
    }
}
