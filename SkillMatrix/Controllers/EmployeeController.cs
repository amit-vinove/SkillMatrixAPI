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

        [HttpGet("GetAllUsers")]
        public IEnumerable<Employee> GetAllEmployee()
        {
            var employees = _db.Employees.ToList();
            return employees;
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
