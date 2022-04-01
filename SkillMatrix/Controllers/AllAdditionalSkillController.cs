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
    public class AllAdditionalSkillController : ControllerBase
    {
        public readonly SkillMatrix.Data.ApplicationDbContext _context;
        public AllAdditionalSkillController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllAdditionalSkills")]
        public async Task<IEnumerable<AllAdditionalSkill>> Get()
        {
            return await _context.AllAdditionalSkills.ToListAsync();
        }

        [HttpPost("AddAllAdditionalSkill")]
        public async Task<AllAdditionalSkill> AddAllAdditionalSkill(AllAdditionalSkill allAdditionalSkill)
        {

            if (allAdditionalSkill == null)
                throw new ArgumentNullException("Add All Additional Skill");

            _context.AllAdditionalSkills.Add(allAdditionalSkill);
            await _context.SaveChangesAsync();

            return allAdditionalSkill;
        }

        [HttpDelete("DeleteAllAdditionalSkill")]
        public async Task<ActionResult> DeleteAllAdditionalSkill(int allAdditionalSkillId)
        {

            var allAdditionalSkill = _context.AllAdditionalSkills.Find(allAdditionalSkillId);
            _context.AllAdditionalSkills.Remove(allAdditionalSkill);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "All Additional Skill Deleted Successfully",
                    Data = true
                });
        }
    }
}
