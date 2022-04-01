using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class AllAdditionalSkill
    {
        [Key]
        public int AllAdditionalSkillId { get; set; }
        public int AdditionalSkillId { get; set; }
        public int EmpId { get; set; }        
        public string AllAdditionalSkillName { get; set; }
        public int Rating { get; set; }

    }
}
