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

        [HttpGet("GetGenericSkillByEmpId")]
        public async Task<ActionResult> GetGenericByEmpId(int empId)
        {
            var genericSkill = _context.GenericSkills.FirstOrDefault(m => m.EmployeeId == empId);
            if (genericSkill == null)
            {
                return Ok(
                    new ResponseGlobal()
                    {
                        ResponseCode = ((int)System.Net.HttpStatusCode.BadRequest),
                        Message = "GenericSkils Not Found",
                        Data = false

                    }
                    );
            }
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "GenericSkills Fetched Successfully",
                    Data = genericSkill

                }
                );
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
        public async Task<ActionResult> DeleteGenericSkill(int genericskillsId)
        {
            var genericSkill = _context.GenericSkills.Find(genericskillsId);
            _context.GenericSkills.Remove(genericSkill);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "GenericSkills Deleted Successfully",
                    Data = true

                }
                );


        }
    }
}
