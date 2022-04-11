using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class SubQuestionRatings
    {
        [Key]
        public int SubQuestionRatingsId { get; set; }
        public int SubQuestionId { get; set; }
        public int EmpId { get; set; }
        public int Ratings { get; set; }

    }
}
