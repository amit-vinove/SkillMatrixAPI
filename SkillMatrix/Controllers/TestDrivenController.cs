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
    public class TestDrivenController : ControllerBase
    {
        public readonly SkillMatrix.Data.ApplicationDbContext _context;
        public TestDrivenController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetTestDriven")]
        
        public async Task<IEnumerable<TestDrivenDevelopment>> Get()
        {
            return await _context.TestDrivenDevelopments.ToListAsync();
        }
        [HttpPost("AddTestDriven")]
        public async Task<TestDrivenDevelopment> AddTestDriven(TestDrivenDevelopment testDrivenDevelopment)
        {
  
        if (testDrivenDevelopment == null)
              throw new ArgumentNullException("Add Test Driven Developments");

        _context.TestDrivenDevelopments.Add(testDrivenDevelopment);
        await _context.SaveChangesAsync();      
            
        return testDrivenDevelopment;
        }

        [HttpDelete("DeleteTestDriven")]
        public async Task<ActionResult> DeleteTestDriven(int testDrivenId)
        {

            var testdriven = _context.TestDrivenDevelopments.Find(testDrivenId);
            _context.TestDrivenDevelopments.Remove(testdriven);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "Test Driven Deleted Successfully",
                    Data = true
                });
        }
    }
}
