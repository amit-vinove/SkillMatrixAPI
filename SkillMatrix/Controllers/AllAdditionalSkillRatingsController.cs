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
    public class AllAdditionalSkillRatingsController : ControllerBase
    {
        public readonly SkillMatrix.Data.ApplicationDbContext _context;
        public AllAdditionalSkillRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllAdditionalSkillRatings")]
        public async Task<IEnumerable<AllAdditionalSkillRatings>> Get()
        {
            return await _context.AllAdditionalSkillRatings.ToListAsync();
        }

        [HttpPost("AddAllAdditionalSkillRatings")]
        public async Task<AllAdditionalSkillRatings> AddAllAdditionalSkillRating(AllAdditionalSkillRatings allAdditionalSkillRating)
        {
            _context.AllAdditionalSkillRatings.Add(allAdditionalSkillRating);
            await _context.SaveChangesAsync();
            return allAdditionalSkillRating;
        }

        [HttpDelete("DeleteAllAdditionalSkillRatings")]
        public async Task<ActionResult> DeleteAllAdditionalSkill(int allAdditionalSkillRatingId)
        {

            var allAdditionalSkillRating = _context.AllAdditionalSkills.Find(allAdditionalSkillRatingId);
            _context.AllAdditionalSkills.Remove(allAdditionalSkillRating);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "All Additional Skill Rating Deleted Successfully",
                    Data = true
                });
        }
    }
}
