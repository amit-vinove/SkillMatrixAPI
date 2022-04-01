using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class BehaviourDrivenDevelopment
    {
        [Key]
        public int BehaviourDrivenId { get; set; }
        public int Cucumber { get; set; }
        public int Maven { get; set; }
        public int UserApproach { get; set; }
        public int EmpId { get; set; }

    }
}
