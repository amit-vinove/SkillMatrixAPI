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
    public class SubSkillsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SubSkillsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllSubSkills")]
        public IEnumerable<SubSkills> GetAllSkills()
        {
            var subSkills = _db.SubSkills.ToList();
            return subSkills;
        }

        [HttpPost("AddSubSkill")]
        public SubSkills CreateSubSkills(SubSkills subSkill)
        {
            _db.SubSkills.Add(subSkill);
            _db.SaveChanges();
            return subSkill;
        }

        [HttpDelete("DeleteSubSkill")]
        public async Task<ActionResult> DeleteSubSkills(int subSkillId)
        {
            var subSkill = _db.SubSkills.Find(subSkillId);
            _db.SubSkills.Remove(subSkill);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "SubSkill Deleted Successfully",
                Data = true
            });
        }

        [HttpGet("GetSubSkillsBySkillId")]
        public IEnumerable<SubSkillsViewModel> GetSubSkillsBySkillId(int skillId)
        {
            var skills = (from skillsDb in _db.Skills 
                         join subSkillsDb in _db.SubSkills on 
                         skillsDb.SkillId equals subSkillsDb.SkillId
                         where subSkillsDb.SkillId == skillId
                         select new SubSkillsViewModel()
                         {
                             SkillsId = skillsDb.SkillId,
                             SkillName = skillsDb.SkillName,
                             SubSkillName = subSkillsDb.SubskillName
                         }).ToList();
            return skills;
        }
    }
}
