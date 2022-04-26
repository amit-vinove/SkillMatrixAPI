using System.ComponentModel.DataAnnotations;

namespace SkillMatrixAPI.Model
{
    public class TeamSubSkillsRatingStatus
    {
        [Key]
        public int TeamSubSkillsRatingsId { get; set; }
        public int EmpId { get; set; }
        public int IsApproved { get; set; }
    }
}
