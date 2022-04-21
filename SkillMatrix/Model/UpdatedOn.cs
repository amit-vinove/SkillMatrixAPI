using System.ComponentModel.DataAnnotations;

namespace SkillMatrixAPI.Model
{
    public class UpdatedOn
    {
        [Key]
        public int id { get; set; }
        public int empId { get; set; }
        public DateTime Updated_On { get; set; }
    }
}