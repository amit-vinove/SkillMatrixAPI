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

    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;

        }
 /*       getemp by RMId*/
        [HttpGet("GetAllEmployee")]
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
                              empDb.Id equals userDb.EmpId
                              join teamdb in _db.Teams on
                              empDb.Team equals teamdb.Id
                              join managerDb in _db.Managers on
                              empDb.ReportingManager equals managerDb.Id
                              where userDb.UserId == userId
                              select new EmployeeViewModel()
                              {
                                  EmpId = empDb.Id,
                                  Name = empDb.Name,
                                  EmployeeCode = empDb.EmployeeCode,
                                  RMId = empDb.ReportingManager,
                                  ReportingManager = managerDb.Name,
                                  Location = empDb.Location,
                                  Department = empDb.Department,
                                  TeamId =empDb.Team,
                                  Team = teamdb.Name,
                                  Band = empDb.Band,
                                  Designation = empDb.Designation,
                                  Status = empDb.Status,
                                  UserName = userDb.Username,
                                  UserId = userId
                              }).ToList();

            if (EmpDetails == null)
            {
                return BadRequest("No Such Employee Found");
            }
            return Ok(EmpDetails);
        }

        [HttpGet("GetEmployeeByEmpId")]
        public async Task<ActionResult> GetEmpByEmpId(int empId)
        {
            var EmpDetails = (from empDb in _db.Employees
                              join teamdb in _db.Teams on
                              empDb.Team equals teamdb.Id
                              join managerDb in _db.Managers on
                              empDb.ReportingManager equals managerDb.Id
                              where empDb.Id == empId
                              select new EmployeeViewModel()
                              {
                                  EmpId = empDb.Id,
                                  Name = empDb.Name,
                                  EmployeeCode = empDb.EmployeeCode,
                                  ReportingManager = managerDb.Name,
                                  Location = empDb.Location,
                                  Department = empDb.Department,
                                  Team = teamdb.Name,
                                  Band = empDb.Band,
                                  Designation = empDb.Designation,
                                  Status = empDb.Status,
                                  UserName = empDb.Email
                              }).ToList();

            if (EmpDetails == null)
            {
                return BadRequest("No Such Employee Found");
            }
            return Ok(EmpDetails);
        }

        [HttpGet("GetEmployeeByResourceManagerId")]
        public async Task<ActionResult> GetEmpByResourceManagerId(int resourceManagerId)
        {
            var EmpDetails = (from empDb in _db.Employees
                              join managerDb in _db.Managers on
                              empDb.ReportingManager equals managerDb.Id
                              join teamdb in _db.Teams on
                              empDb.Team equals teamdb.Id
                              where empDb.ReportingManager == resourceManagerId
                              select new EmployeeViewModel()
                              {
                                  EmpId = empDb.Id,
                                  Name = empDb.Name,
                                  EmployeeCode = empDb.EmployeeCode,
                                  ReportingManager = managerDb.Name,
                                  Location = empDb.Location,
                                  Department = empDb.Department,
                                  Team = teamdb.Name,
                                  Band = empDb.Band,
                                  Designation = empDb.Designation,
                                  Status = empDb.Status
                              }).ToList();

            if (EmpDetails == null)
            {
                return BadRequest("No Such Employee Found");
            }
            return Ok(EmpDetails);
        }


        [HttpPost("CreateEmp")]
        public Employee CreateEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return employee;
        }

        [HttpPost("CreateEmployee")]
        public Employee CreateEmpoyeeUser(Employee employee)
        {
            var emp = CreateEmployee(employee);
            var user = new Users
            {
                EmpId = emp.Id,
                Role = 0,
                RoleLevel = "Employee",
                Username = emp.Email,
                Password = emp.Password,
            };
            _db.Users.Add(user);
            _db.SaveChanges();
            return emp;
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
