using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JSFrontEndController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public JSFrontEndController(ApplicationDbContext db)
        {
            _context = db;
        }
        [HttpGet("GetAllDetails")]
        public async Task<IEnumerable<JSFrontEnd>> GetAllDetails()
        {
            return _context.JSFrontEnd.ToList();
        }
        [HttpPost("CreateJSProntEnd")]
        public async Task<JSFrontEnd> AddJSFrontEnd(JSFrontEnd JSfrontend)
        {
            if (JSfrontend == null)
                throw new ArgumentNullException("Add JSFrontEnd");
            _context.JSFrontEnd.Add(JSfrontend);
            await _context.SaveChangesAsync();
            return JSfrontend;
        }
        [HttpDelete("Delete JSFrontEnd")]
        public async Task<ActionResult> DeleteJSFrontEnd(int JSFrontEndId)
        {
            var JSFrontEnd = _context.JSFrontEnd.Find(JSFrontEndId);
            _context.JSFrontEnd.Remove(JSFrontEnd);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "JSFrontEnd Deleted Successfully",
                    Data = true

                }
                );
        }
    }
}
