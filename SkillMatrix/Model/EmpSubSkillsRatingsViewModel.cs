using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class EmpSubSkillsRatingsViewModel
    {
        
        public int EmpSubSkillsRatingsId { get; set; }
        public string SubSkillName { get; set; }
        public int EmpId { get; set; }
        public int SkillId { get; set; }
        public int Ratings { get; set; }
        public int IsApproved { get; set; }
        public string Month { get; set; }

    }
}
