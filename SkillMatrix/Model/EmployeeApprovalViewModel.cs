using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class EmployeeApprovalViewModel
    {
        [Key]
        public int EmpId{ get; set; }
        public string Name { get; set; }
        public string EmployeeCode { get; set; }
        public string ReportingManager { get; set; }
        public int RMId { get; set; }
        public string Location { get; set; }    
        public string Department { get; set; }
        public string Team { get; set; }
        public int TeamId { get; set; }
        public string Band { get; set; }
        public string Designation { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string AssessmentMonth { get; set; }


    }
}
