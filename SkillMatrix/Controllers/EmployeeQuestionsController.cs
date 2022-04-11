﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost("CreateEmployeeQuestions")]
        public EmployeeQuestions CreateEmployeeQuestions(EmployeeQuestions employeeQuestions)
        {
            _db.EmployeeQuestions.Add(employeeQuestions);
            _db.SaveChanges();
            return employeeQuestions;
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