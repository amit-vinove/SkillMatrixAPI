using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;
using SkillMatrixAPI.Model;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ApprovalsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ApprovalsController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllApprovals")]
        public IEnumerable<Approvals> GetAllSkills()
        {
            var approvals = _db.Approvals.ToList();
            return approvals;
        }

        [HttpPost("AddApprovals")]
        public Approvals CreateSubSkills(Approvals approvals)
        {
            DateTime Dt = DateTime.Now;
            string Month_Name = Dt.ToString("MMMM");
            string Date = Dt.ToString("d");
            approvals.SubmittedOn = Date;
            approvals.AssessmentMonth = Month_Name;
            _db.Approvals.Add(approvals);
            _db.SaveChanges();
            return approvals;
        }

        [HttpDelete("DeleteApprovals")]
        public async Task<ActionResult> DeleteApproval(int approvalId)
        {
            var approvals = _db.Approvals.Find(approvalId);
            _db.Approvals.Remove(approvals);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Approval Deleted Successfully",
                Data = true
            });
        }

        [HttpGet("GetApprovalsByManagerId")]
        public IEnumerable<EmployeeApprovalViewModel> GetApprovalByManagerId(int managerId)
        {
            var approvals = (from approvalDb in _db.Approvals
                             join empDB in _db.Employees on
                             approvalDb.EmpId equals empDB.Id
                             join managerDB in _db.Managers on
                             approvalDb.ManagerId equals managerDB.Id
                             join teamDB in _db.Teams on    
                             empDB.Team equals teamDB.Id
                             where approvalDb.ManagerId == managerId
                             select new EmployeeApprovalViewModel()
                             {
                                 EmpId = empDB.Id,
                                 Name = empDB.Name,
                                 EmployeeCode = empDB.EmployeeCode,
                                 RMId = empDB.ReportingManager,
                                 ReportingManager = managerDB.Name,
                                 Location = empDB.Location,
                                 Department = empDB.Department,
                                 TeamId = teamDB.Id,
                                 Team = teamDB.Name,
                                 Band = empDB.Band,
                                 Designation = empDB.Designation,
                                 UserName = empDB.Email,
                                 AssessmentMonth = approvalDb.AssessmentMonth
                             }).ToList();
            return approvals;
        }

        [HttpDelete("DeleteApprovalsByEmpId")]
        public async Task<ActionResult> DeleteApprovalByEmpId(int empId)
        {
            var approvals = _db.Approvals.Where(m=>m.EmpId==empId);
            _db.Approvals.RemoveRange(approvals);
            _db.SaveChanges();
            return Ok(
            new ResponseGlobal()
            {
                ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                Message = "Approval Deleted Successfully",
                Data = true
            });
        }
    }
}
