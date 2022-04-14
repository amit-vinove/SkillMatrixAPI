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
    [EnableCors("AllowAllOrigins")]
    public class EmployeeQuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeeQuestionsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllEmployeeQuestions")]
        public IEnumerable<EmployeeQuestions> GetAllEmployee()
        {
            var employeeQuestions = _db.EmployeeQuestions.ToList();
            return employeeQuestions;
        }

        [HttpGet("GetQuestionsByEmpId")]
        public IEnumerable<EmployeeQuestionsViewModel> GetQuestionsByEmpId(int empId)
        {
            var employeeQuestions = (from empDb in _db.Employees
                                     join empQues in _db.EmployeeQuestions on
                                     empDb.Id equals empQues.EmpId
                                     join skillsDb in _db.Skills on
                                     empQues.QuestionId equals skillsDb.SkillId
                                     where empQues.EmpId == empId
                                     select new EmployeeQuestionsViewModel()
                                     {
                                         QuestionId = empQues.QuestionId,
                                         QuestionName = skillsDb.SkillName,
                                         QuestionLogo = skillsDb.SkillLogo,
                                         EmpId = empId,
                                     }).ToList();
            return employeeQuestions;
        }

        [HttpPost("CreateEmployeeQuestions")]
        public EmployeeQuestions CreateEmployeeQuestions(EmployeeQuestions employeeQuestions)
        {
            _db.EmployeeQuestions.Add(employeeQuestions);
            _db.SaveChanges();
            return employeeQuestions;
        }
        [HttpPost("PostEmployeeQuestions")]
        public IActionResult PostEmployeeQuestions(PostEmpQuestionModel model )
        {
            foreach (var item in model.Array)
            {
                EmployeeQuestions temp = new EmployeeQuestions();
                temp.QuestionId = item;
                temp.EmpId=model.EmpId;

                _db.EmployeeQuestions.Add(temp);
            }

            
            _db.SaveChanges();
            return Ok("Successful");
        }

        [HttpDelete("DeleteEmployeeQuestions")]
        public async Task<ActionResult> DeleteEmployeeQuestions(int empQuesId)
        {
           var empQues = _db.EmployeeQuestions.Find(empQuesId);
            _db.EmployeeQuestions.Remove(empQues);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
             {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Employee Question Deleted Successfully",
                Data = true
             });
        }

        
    }
}
