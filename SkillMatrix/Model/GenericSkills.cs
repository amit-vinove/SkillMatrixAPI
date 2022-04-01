using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class GenericSkills
    {
        [Key]
        public int GenericId { get; set; }
        public int EmployeeId { get; set; }
        public int Oral_Communication { get; set; }
        public int Written_Communication { get; set; }
        public int Process_Conformance { get; set; }
        public int Presentation_skill { get; set; }
        public int Leadership_Skills { get; set; }
        public int Management { get; set; }
        public int Interpersonal_Skills { get; set; }
        public int Takes_Initiative { get; set; }
        public int Critical_and_Analytical_Thinking { get; set; }
        public int Demonstrate_Teamwork { get; set; }
        public int Adaptability_And_Flexibility { get; set; }
        public int Customer_Focus { get; set; }
        public int Planning_And_Organizing { get; set; }
        public int Negotiation_Skills { get; set; }
        public int Problem_Solving_Skills { get; set; }
      
    }
}
