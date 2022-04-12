using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string RoleLevel { get; set; }
        public int EmpId { get; set; }



    }
}
