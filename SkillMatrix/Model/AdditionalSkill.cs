using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class AdditionalSkill
    {
        [Key]
        public int AdditionalSkillId { get; set; }
        public string AdditionalSkillName { get; set; }
        public int EmpId { get; set; }

    }   
}
