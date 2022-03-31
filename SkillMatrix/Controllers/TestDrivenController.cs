using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Data;
using SkillMatrix.Model;

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
        [HttpGet]
        public async Task<IEnumerable<TestDrivenDevelopment>> Get()
        {
            return await _context.TestDrivenDevelopments.ToListAsync();
        }
        [HttpPost]
        public async Task<TestDrivenDevelopment> AddTestDriven(TestDrivenDevelopment testDrivenDevelopment)
        {
  
        if (testDrivenDevelopment == null)
              throw new ArgumentNullException("Add Test Driven Developments");

        _context.TestDrivenDevelopments.Add(testDrivenDevelopment);
        await _context.SaveChangesAsync();      
            
        return testDrivenDevelopment;
        }

        [HttpDelete]
        public async Task<bool> DeleteTestDriven(int testDrivenId)
        {
            bool isDeleted = false;
            
                if (testDrivenId == 0)
                    return isDeleted;
                var testDriven = await _context.TestDrivenDevelopments.FirstOrDefaultAsync(m => m.TestDrivenId == testDrivenId);
                if (testDriven == null)
                    return isDeleted;
                _context.TestDrivenDevelopments.Remove(testDriven);
                await _context.SaveChangesAsync();
                isDeleted = true;
            
            return isDeleted;
        }
    }
}
