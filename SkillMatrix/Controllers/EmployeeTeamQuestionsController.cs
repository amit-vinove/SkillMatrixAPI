using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;
using SkillMatrixAPI.Model;

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
        [HttpGet("GetQuestionsByEmpIdandTeamId")]
        public IEnumerable<EmployeeTeamQuestionViewModel> GetQuestionsByEmpIdandTeamId(int empId,int teamId)
        {
            var employeeQuestions = (from empTeamQues in _db.EmployeeTeamQuestions
                                     join team in _db.Teams
                                     on empTeamQues.TeamId equals team.Id
                                     join teamques in _db.TeamSkills 
                                     on empTeamQues.TeamSkillsId 
                                     equals teamques.TeamSkillId
                                     where empTeamQues.EmpId==empId && empTeamQues.TeamId==teamId
                                     select new EmployeeTeamQuestionViewModel()
                                     {
                                         EmpId=empId,
                                         TeamId=teamId,
                                         TeamSkillId=teamques.TeamSkillId,
                                         TeamSkillName=teamques.TeamSkillName,
                                     }).ToList();
            return employeeQuestions;
        }

        [HttpPost("CreateEmployeeTeamQuestions")]
        public EmployeeTeamQuestions CreateEmployeeTeamQuestions(EmployeeTeamQuestions employeeTeamQuestions)
        {
            _db.EmployeeTeamQuestions.Add(employeeTeamQuestions);
            _db.SaveChanges();
            return employeeTeamQuestions;
        }

        [HttpPost("PostEmployeeTeamQuestions")]
        public IActionResult PostEmployeeQuestions(PostEmpTeamQuestionViewModel model)
        {
            foreach (var item in model.Array)
            {
                EmployeeTeamQuestions temp = new EmployeeTeamQuestions();
                temp.TeamSkillsId = item;
                temp.EmpId = model.EmpId;
                temp.TeamId = model.TeamId;

                _db.EmployeeTeamQuestions.Add(temp);
            }
            _db.SaveChanges();
            return Ok("Successful");
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
