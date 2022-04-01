using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CloudController(ApplicationDbContext db)
        {
            _context = db;
        }
        [HttpGet("GetAllDetails")]

        public async Task<IEnumerable<Cloud>> GetAllDetails()
        {
            return _context.Cloud.ToList();
        }
        [HttpPost("CreateCloud")]
        public async Task<Cloud> AddGenericSKills(Cloud cloud)
        {
            if (cloud == null)
                throw new ArgumentNullException("Add Cloud");
            _context.Cloud.Add(cloud);
            await _context.SaveChangesAsync();
            return cloud;
        }
        [HttpDelete("DeleteCloudById")]
        public async Task<ActionResult> DeleteCloud(int CloudId)
        {
            var Clouddata = _context.Cloud.Find(CloudId);
            _context.Cloud.Remove(Clouddata);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "Cloud Deleted Successfully",
                    Data = true

                }
                );

        }
    }
}
