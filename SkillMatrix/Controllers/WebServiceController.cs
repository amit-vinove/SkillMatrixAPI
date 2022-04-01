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
    public class WebServiceController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public WebServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetWebServices")]
        public async Task<IEnumerable<WebService>> Get()
        {
            return await _context.WebServices.ToListAsync();
        }

        [HttpPost("AddWebService")]
        public async Task<WebService> AddWebService(WebService webService)
        {

            if (webService == null)
                throw new ArgumentNullException("Add Web Service");

            _context.WebServices.Add(webService);
            await _context.SaveChangesAsync();

            return webService;
        }

        [HttpDelete("DeleteWebService")]
        public async Task<ActionResult> DeleteWebService(int webServiceId)
        {

            var webService = _context.WebServices.Find(webServiceId);
            _context.WebServices.Remove(webService);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "Web Service Deleted Successfully",
                    Data = true
                });
        }
    }
}
