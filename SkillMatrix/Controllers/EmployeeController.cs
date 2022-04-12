﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<Employee> GetAllEmployee()
        {
            var employees = _db.Employees.ToList();
            return employees;
        }

        [HttpGet("GetEmployeeByUserId")]
        public async Task<ActionResult> GetEmpByUserId(int userId)
        {
            var EmpDetails = (from empDb in _db.Employees
                              join userDb in _db.Users on
                              empDb.UserId equals userDb.UserId
                              join teamdb in _db.Teams on
                              empDb.Team equals teamdb.Id
                              join managerDb in _db.Managers on
                              empDb.ReportingManager equals managerDb.Id
                              where empDb.UserId == userId
                              select new EmployeeViewModel()
                              {
                                  Id = empDb.Id,
                                  Name = empDb.Name,
                                  EmployeeCode = empDb.EmployeeCode,
                                  ReportingManager = managerDb.Name,
                                  Location = empDb.Location,
                                  Department = empDb.Department,
                                  Team = teamdb.Name,
                                  Band = empDb.Band,
                                  Designation = empDb.Designation,
                                  Status = empDb.Status,
                                  UserName = userDb.Username
                              }).ToList();

            if (EmpDetails == null)
            {
                return BadRequest("No Such Employee Found");
            }
            return Ok(EmpDetails);
        }

        [HttpPost("CreateEmployee")]
        public Employee CreateEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return employee;
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult> DeleteEmployee(int empId)
        {
           var emp = _db.Employees.Find(empId);
            _db.Employees.Remove(emp);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
             {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "User Deleted Successfully",
                Data = true
             });
        }

        
    }
}
