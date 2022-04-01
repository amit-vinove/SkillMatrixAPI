using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class JSFrontEnd
    {
        [Key]
        public int JSFrontEndId { get; set; }
        public int EmployeeId { get; set; }
        public int HTML_CSS { get; set; }
        public int Jquery { get; set; } 
        public int AngularJS { get; set; }
        public int ReactJS { get; set; }
    }
}
