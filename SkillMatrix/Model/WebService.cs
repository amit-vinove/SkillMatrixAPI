using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class WebService
    {
        [Key]
        public int WebServiceId { get; set; }
        public int WebApi { get; set; }
        public int Wcf { get; set; }
        public int Soap { get; set; }
        public int ThirdParty { get; set; }
        public int EmpId { get; set; }
    }
}
