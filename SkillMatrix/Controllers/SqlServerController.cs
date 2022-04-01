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
    public class SqlServerController : ControllerBase
    {
        public readonly SkillMatrix.Data.ApplicationDbContext _context;
        public SqlServerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetSqlServer")]
        public async Task<IEnumerable<SqlServer>> Get()
        {
            return await _context.SqlServers.ToListAsync();
        }

        [HttpPost("AddSqlServer")]
        public async Task<SqlServer> AddSqlServer(SqlServer sqlServer)
        {

            if (sqlServer == null)
                throw new ArgumentNullException("Add Sql Server");

            _context.SqlServers.Add(sqlServer);
            await _context.SaveChangesAsync();

            return sqlServer;
        }

        [HttpDelete("DeleteSqlServer")]
        public async Task<ActionResult> DeleteSqlServer(int sqlServerId)
        {

            var sqlServer = _context.SqlServers.Find(sqlServerId);
            _context.SqlServers.Remove(sqlServer);
            _context.SaveChanges();
            return Ok(
                new ResponseGlobal()
                {
                    ResponseCode = ((int)System.Net.HttpStatusCode.OK),
                    Message = "Sql Server Deleted Successfully",
                    Data = true
                });
        }
    }
}
