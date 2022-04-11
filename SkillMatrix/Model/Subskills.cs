using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class SubSkills
    {
        [Key]
        public int SubSkillsId { get; set; }
        public string SubskillName { get; set; }
        public int SkillId { get; set; }


    }
}
