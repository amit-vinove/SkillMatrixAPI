using System.ComponentModel.DataAnnotations;

namespace SkillMatrix.Model
{
    public class UsersResponseModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int UserRole { get; set; }
        public string UserRoleLevel { get; set; }

    }
}
