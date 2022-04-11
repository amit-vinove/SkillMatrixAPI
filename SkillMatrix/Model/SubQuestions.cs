using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class SubQuestions
    {
        [Key]
        public int SubQuestionId { get; set; }
        public string SubQuestionName { get; set; }
        public int QuestionId { get; set; }


    }
}
