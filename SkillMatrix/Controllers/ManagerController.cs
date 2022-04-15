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

        [HttpGet("GetManagerByUserId")]
        public async Task<ActionResult> GetManagerByUserId(int userId)
        {
            var ManagerDetails = _db.Managers.FirstOrDefault(m => m.UserId == userId);

            if (ManagerDetails == null)
            {
                return BadRequest("No Such Manager Found");
            }
            return Ok(ManagerDetails);
        }


        [HttpGet("GetManagerByEmpId")]
        public async Task<ActionResult> GetManagerByEmpId(int empId)
        {
            var ManagerDetails = _db.Managers.FirstOrDefault(m => m.Id == empId);

            if (ManagerDetails == null)
            {
                return BadRequest("No Such Manager Found");
            }
            return Ok(ManagerDetails);
        }

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
