using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillMatrix.Model
{
    public class TeamSkills
    {
        [Key]
        public int TeamSkillId { get; set; }
        public string TeamSkillName { get; set; }
        public int TeamId { get; set; }
        
        [NotMapped]
        public String TeamName { get; set; }



    }
}
