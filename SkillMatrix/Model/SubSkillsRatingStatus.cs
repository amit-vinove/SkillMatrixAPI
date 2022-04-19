using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class SubSkillsRatingStatus
    {
        [Key]
        public int SubSkillsRatingsId { get; set; }
        public int EmpId { get; set; }
        public int IsApproved { get; set; }

    }
}
