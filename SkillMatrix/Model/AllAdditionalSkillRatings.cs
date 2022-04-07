using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class AllAdditionalSkillRatings
    {
        [Key]
        public int AllAdditionalSkillRatingsId { get; set; }
        public int AllAdditionalSkillId { get; set; }
        public int Ratings { get; set; }
        public int EmpId { get; set; }
        public bool IsApproved { get; set; }


    }
}
