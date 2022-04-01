using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }
        public int ReportingManager { get; set; }
        public string Location { get; set; }    
        public string Department { get; set; }
        public int Team { get; set; }
        public string Band { get; set; }
        public string Designation { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public bool isApproved { get; set; }

    }
}
