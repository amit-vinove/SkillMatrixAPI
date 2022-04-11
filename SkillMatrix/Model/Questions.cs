using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }

    }
}
