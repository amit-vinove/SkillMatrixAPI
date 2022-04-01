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
    public class AdditionalSkillController : ControllerBase
    {
        public readonly SkillMatrix.Data.ApplicationDbContext _context;
        public AdditionalSkillController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAdditionalSkills")]
        public async Task<IEnumerable<AdditionalSkill>> Get()
        {
            return await _context.AdditionalSkills.ToListAsync();
        }

        [HttpPost("AddAdditionalSkill")]
        public async Task<AdditionalSkill> AddAdditionalSkill(AdditionalSkill additionalSkill)
        {

            if (additionalSkill == null)
                throw new ArgumentNullException("Add Additional Skill");

            _context.AdditionalSkills.Add(additionalSkill);
            await _context.SaveChangesAsync();

            return additionalSkill;
        }

        [HttpDelete("DeleteAdditionalSkill")]
        public async Task<ActionResult> DeleteAdditionalSkill(int additionalSkillId)
        {

            var additionalSkill = _context.AdditionalSkills.Find(additionalSkillId);
            _context.AdditionalSkills.Remove(additionalSkill);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "Additional Skill Deleted Successfully",
                    Data = true
                });
        }
    }
}
