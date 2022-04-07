using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class AllAdditionalSkill
    {
        [Key]
        public int AllAdditionalSkillId { get; set; }
        public int AdditionalSkillId { get; set; }
        public string AllAdditionalSkillName { get; set; }


    }
}
