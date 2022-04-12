using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }

    }
}
