using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class Devop
    {
        [Key]
        public int DevopId { get; set; }
        public int DockerKubernetes { get; set; }
        public int WebDb { get; set; }
        public int CiCd { get; set; }
        public int CiCdDevopPractice { get; set; }
        public int EmpId { get; set; }
        public bool isApproved { get; set; }
    }
}
