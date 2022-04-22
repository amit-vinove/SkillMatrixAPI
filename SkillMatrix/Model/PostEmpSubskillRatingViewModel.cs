namespace SkillMatrixAPI.Model
{
    public class PostEmpSubskillRatingViewModel
    {
        
        public int[][] subskillRatingArr { get; set; }
        public int EmpId { get; set; }
        public int SkillId { get; set; }
        public string SubmittedOn { get; set; }
        public string AssessmentMonth { get; set; }

    }
}
