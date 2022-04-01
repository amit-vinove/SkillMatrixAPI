using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class BasicFoundation
    {
        [Key]
        public int BasicFoundId { get; set; }
        public int EmployeeId { get; set; }
        public int TFS { get; set; }
        public int GIT_OR_REVISION_CONTROL {get; set;}
        public int JIRA_OR_AGILE_PRACTICES { get; set; }
        public int SERVER_UPLOADS_OR_MANAGEMENT { get; set; }
        public int BEST_PRACTICES { get; set;}
        public int UNIT_TESTING { get; set; }

    }
}
