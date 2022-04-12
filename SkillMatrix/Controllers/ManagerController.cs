using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ManagerController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllManagers")]
        public IEnumerable<Manager> GetAllEmployee()
        {
            var managers = _db.Managers.ToList();
            return managers;
        }

/*        [HttpGet("GetEmployeeByUserId")]
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
                              }).ToList();

            if (EmpDetails == null)
            {
                return BadRequest("No Such Employee Found");
            }
            return Ok(EmpDetails);
        }*/

        [HttpPost("CreateManager")]
        public Manager CreateEmployee(Manager manager)
        {
            _db.Managers.Add(manager);
            _db.SaveChanges();
            return manager;
        }

        [HttpDelete("DeleteManager")]
        public async Task<ActionResult> DeleteManager(int managerId)
        {
           var manager = _db.Managers.Find(managerId);
            _db.Managers.Remove(manager);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
             {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Manager Deleted Successfully",
                Data = true
             });
        }

        
    }
}
