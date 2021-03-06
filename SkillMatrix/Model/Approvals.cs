using System.ComponentModel.DataAnnotations;

namespace SkillMatrixAPI.Model
{
    public class Approvals
    {
        [Key]
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int ManagerId { get; set; }
        public string SubmittedOn { get; set; }
        public string AssessmentMonth { get; set; }
    }
}
