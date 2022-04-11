using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class TeamSkills
    {
        [Key]
        public int TeamSkillId { get; set; }
        public string TeamSkillName { get; set; }
        public int TeamId { get; set; }





    }
}
