using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Data;
using SkillMatrix.Model;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SDLCProceesesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SDLCProceesesController(ApplicationDbContext db)
        {
            _context = db;
        }
        [HttpGet("GetAllSDLCProceeses")]
        public async Task<IEnumerable<SDLCProceeses>> GetProceeses()
        {
            return _context.SDLCProceeses.ToList();
        }

        [HttpPost("CreateSDLCProceeses")]
        public async Task<SDLCProceeses> AddSDLCProceeses(SDLCProceeses SDLCproceeses)
        {
            if (SDLCproceeses == null)
                throw new ArgumentException("Add SDLC Proceeses");
            _context.SDLCProceeses.Add(SDLCproceeses);
            await _context.SaveChangesAsync();
            return SDLCproceeses;
        }
        [HttpDelete("DeleteSDLCProcesses")]
        public async Task<ActionResult> DeleteSDLCProceeses(int SDLCId)
        {
            var SDLCProceeses = _context.SDLCProceeses.Find(SDLCId);
            _context.SDLCProceeses.Remove(SDLCProceeses);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "SDLCProceeses Deleted Successfully",
                    Data = true
                }
                );

        }

    }
}
