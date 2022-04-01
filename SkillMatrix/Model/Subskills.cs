using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class Subskills
    {
        [Key]
        public int SubskillsId { get; set; }
        public string SubskillsName { get; set; }
        public int Ratings {  get; set; }
        public int EmpId { get; set; }
        public int SkillId { get; set; }
        public bool IsApproved { get; set; }



    }
}
