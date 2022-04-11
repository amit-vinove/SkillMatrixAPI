using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class TeamSubskills
    {
        [Key]
        public int TeamSubskillsId { get; set; }
        public string TeamSubskillsName { get; set; }
        public int SkillId { get; set; }



    }
}
