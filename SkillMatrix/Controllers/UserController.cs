using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<Users> GetAllUsers()
        {
            var userData = _db.Users.ToList();
            return userData;
        }

        [HttpGet("GetUserByUsername")]
        public Task<Users> GetUserByUsername(string username)
        {
            var user = _db.Users.FirstOrDefaultAsync(m => m.Username == username);
            return user;

        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> AddUser(Users newUser)
        {
            if(newUser.Role == 0)
            {
                newUser.RoleLevel = "Employee";
            }
            if (newUser.Role == 1)
            {
                newUser.RoleLevel = "Manager";
            }
            _db.Users.Add(newUser);
            _db.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "User Created Successfully",
                    Data = newUser
                });
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UsersLoginModel userLogin)
        {
            if (userLogin == null)
                return BadRequest("Invalid login details");

            Users user = _db.Users.FirstOrDefault(m => m.Username == userLogin.Username);
            if (user == null)
                return NotFound("User Not Found!");

            if (user.Password != userLogin.Password)
                return BadRequest("Wrong Credentails");

            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "Logged In",
                    Data = true
                });
        }


        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var user = _db.Users.Find(userId);
            _db.Users.Remove(user);
            _db.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "User Deleted Successfully",
                    Data = true
                });
        }
    }
}
