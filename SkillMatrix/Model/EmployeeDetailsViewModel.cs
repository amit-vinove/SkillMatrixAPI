using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class EmployeeDetailsViewModel
    {

        public string Name { get; set; }
        public string EmployeeCode { get; set; }
        public string ReportingManager { get; set; }
        public string Location { get; set; }    
        public string Department { get; set; }
        public string TeamName { get; set; }
        public string Band { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Skills { get; set; }
        public string TeamSkills { get; set; }


    }
}
