using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Data;
using SkillMatrix.Model;

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
        public async Task<bool> DeleteBasicFoundation(int basicFoundationId)
        {
            bool isDeleted = false;

            if (basicFoundationId == 0)
                return isDeleted;

            var basicFoundation = await _context.BasicFoundation.FirstOrDefaultAsync(m => m.BasicFoundId == basicFoundationId);
            if (basicFoundation == null)
                return isDeleted;
            _context.BasicFoundation.Remove(basicFoundation);
            await _context.SaveChangesAsync();
            isDeleted = true;
            return isDeleted;
        }
    }
}
