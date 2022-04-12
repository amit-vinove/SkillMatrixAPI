using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class SubSkillsRatings
    {
        [Key]
        public int SubSkillsRatingsId { get; set; }
        public int SubSkillId { get; set; }
        public int EmpId { get; set; }
        public int Ratings { get; set; }
        public int IsApproved { get; set; }

    }
}
