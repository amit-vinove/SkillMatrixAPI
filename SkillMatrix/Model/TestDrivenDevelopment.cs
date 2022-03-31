using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class TestDrivenDevelopment
    {
        [Key]
        public int TestDrivenId { get; set; }
        public int EmpId { get; set; }
        public int OralCommunication { get; set; }
        public int WrittenCommunication { get; set; }
        public int ProcessConformance { get; set; }
        public int PresentationSkills { get; set; }
        public int LeadershipSkills { get; set; }
        public int Management { get; set; }
        public int InterpersonalSkills { get; set; }
        public int TakesInitiative { get; set; }
        public int CriticalAnalytical { get; set; }
        public int DemonstratesTeamwork { get; set; }
        public int AdaptabilityFlexibility { get; set; }
        public int CustomerFocus { get; set; }
        public int PlanningOrganizing { get; set; }
        public int NegotiationSkills { get; set; }
        public int ProblemSolvingSkills { get; set; }

    }
}
