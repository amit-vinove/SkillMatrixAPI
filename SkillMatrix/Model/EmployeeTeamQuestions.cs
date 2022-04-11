using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class EmployeeTeamQuestions
    {
        [Key]
        public int EmployeeTeamQuestionsId { get; set; }
        public int TeamId { get; set; }
        public int TeamSkillsId { get; set; }
        public int EmpId { get; set; }


    }
}
