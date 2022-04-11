using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class EmployeeQuestions
    {
        [Key]
        public int EmployeeQuestionsId { get; set; }
        public int QuestionId { get; set; }
        public int EmpId { get; set; }


    }
}
