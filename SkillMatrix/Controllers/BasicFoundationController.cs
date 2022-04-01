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
    public class BasicFoundationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BasicFoundationController(ApplicationDbContext db)
        {
            _context = db;
        }
        [HttpGet("GetAllDetails")]

        public async Task<IEnumerable<BasicFoundation>> GetAllDetails()
        {
            return _context.BasicFoundation.ToList();
        }
        [HttpPost("CreateBasicFoundation")]
        public async Task<BasicFoundation> AddGenericSKills(BasicFoundation basicFoundation)
        {
            if (basicFoundation == null)
                throw new ArgumentNullException("Add Basic Foundation");
            _context.BasicFoundation.Add(basicFoundation);
            await _context.SaveChangesAsync();
            return basicFoundation;
        }
        [HttpDelete("DeleteBasicFoundationById")]
        public async Task<ActionResult> DeleteBasicFoundation(int basicFoundationId)
        {
            var basicFoundation = _context.BasicFoundation.Find(basicFoundationId);
            _context.BasicFoundation.Remove(basicFoundation);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "BasicFoundation Deleted Successfully",
                    Data = true

                }
                );

        }
    }
}
