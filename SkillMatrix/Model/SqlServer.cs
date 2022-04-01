using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class SqlServer
    {
        [Key]
        public int SqlServerId { get; set; }
        public int StoredPocedure { get; set; }
        public int SqlQueries { get; set; }
        public int Triggers { get; set; }
        public int ssrs { get; set; }
        public int EmpId { get; set; }
        public bool isApproved { get; set; }
    }
}
