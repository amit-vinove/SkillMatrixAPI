using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class TeamSubskillRatings
    {
        [Key]
        public int SubskillRatingsId { get; set; }
        public int SubskillId { get; set; }
        public int SkillId { get; set; }
        public int Ratings {  get; set; }
        public int EmpId { get; set; }
        public int IsApproved { get; set; }

    }
}
