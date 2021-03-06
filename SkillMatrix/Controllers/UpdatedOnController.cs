using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Models;
using SkillMatrixAPI.Model;

namespace SkillMatrixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatedOnController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UpdatedOnController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetAllUpdates")]
        public IEnumerable<UpdatedOn> GetAllUpdates()
        {
            var update = _db.UpdatedOn.ToList();
            return update;
        }
        [HttpGet("GetUpdateTimeByEmpId")]
        public IEnumerable<UpdatedOn> GetUpdateTimeByEmpId(int EmpId)
        {
            var update = _db.UpdatedOn.Where(m => m.empId == EmpId);
            return update;
        }

        [HttpGet("GetLatestUpdateTimeByEmpId")]
        public async Task<ActionResult> GetLatestUpdateTimeByEmpId(int EmpId)
        {
            var update = _db.UpdatedOn.OrderByDescending(y => y.id).Where(m => m.empId == EmpId).FirstOrDefault();
            return Ok(
new ResponseGlobal()
{
    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
    Message = "Update Fetched",
    Data = update
});
        }

        [HttpPost("CreateUpdates")]
        public UpdatedOn CreateTeam(int empId)
        {
            DateTime Dt = DateTime.Now;
            string Month_Name = Dt.ToString("MMMM");
            string Date = Dt.ToString("d");
            var update = new UpdatedOn
            {
                id = 0,
                empId = empId,
                SubmittedOn = Date,
                AssessmentMonth = Month_Name,
            };
            _db.UpdatedOn.Add(update);
            _db.SaveChanges();
            return update;
        }
        
        [HttpDelete("DeleteUpdates")]
        public async Task<ActionResult> DeleteUpdates(int Id)
        {
            var update = _db.UpdatedOn.Find(Id);
            _db.UpdatedOn.Remove(update);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Update Deleted Successfully",
                Data = true
            });
        }

    }
}
