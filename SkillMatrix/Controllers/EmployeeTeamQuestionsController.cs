using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeTeamQuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeeTeamQuestionsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllEmployeeQuestions")]
        public IEnumerable<EmployeeTeamQuestions> GetAllEmployee()
        {
            var employeeTeamQuestions = _db.EmployeeTeamQuestions.ToList();
            return employeeTeamQuestions;
        }

        [HttpPost("CreateEmployeeTeamQuestions")]
        public EmployeeTeamQuestions CreateEmployeeTeamQuestions(EmployeeTeamQuestions employeeTeamQuestions)
        {
            _db.EmployeeTeamQuestions.Add(employeeTeamQuestions);
            _db.SaveChanges();
            return employeeTeamQuestions;
        }

        [HttpDelete("DeleteEmployeeTeamQuestions")]
        public async Task<ActionResult> DeleteEmployeeTeamQuestions(int empTeamQuesId)
        {
           var empTeamQues = _db.EmployeeTeamQuestions.Find(empTeamQuesId);
            _db.EmployeeTeamQuestions.Remove(empTeamQues);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
             {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Employee Team Question Deleted Successfully",
                Data = true
             });
        }

        
    }
}
