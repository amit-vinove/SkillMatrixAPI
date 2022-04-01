using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Data;
using SkillMatrix.Model;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericSkillsController : ControllerBase
    {
        
        private readonly ApplicationDbContext _context;
        public GenericSkillsController(ApplicationDbContext db)
        {
            _context = db;
        }
        [HttpGet("GetAllDetails")]
        
        public async Task<IEnumerable<GenericSkills>> GetAllDetails()
        {
            return _context.GenericSkills.ToList();
        }
        [HttpPost("CreateGenericSkills")]
        public async Task<GenericSkills> AddGenericSKills(GenericSkills genericSkills)
        {
            if (genericSkills == null)
                throw new ArgumentNullException("Add generic Skills");
            _context.GenericSkills.Add(genericSkills);
            await _context.SaveChangesAsync();   
            return genericSkills;
        }
        [HttpDelete("DeleteGenericSkillById")]
        public async Task<bool> DeleteGenericSkill(int genericskillsId)
        {
            bool isDeleted = false;

              if (genericskillsId == 0)
                 return isDeleted;

              var genericSkills = await _context.GenericSkills.FirstOrDefaultAsync(m => m.GenericId == genericskillsId);
              if(genericSkills == null)
                  return isDeleted;
              _context.GenericSkills.Remove(genericSkills);
              await _context.SaveChangesAsync();
            isDeleted = true;
         return isDeleted;
        }
    }
}
