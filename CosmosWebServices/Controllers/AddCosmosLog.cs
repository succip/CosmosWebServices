using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace CosmosWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddCosmosLog : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CosmosLog cosmosLog, [FromServices] MyDbContext context)
        {
            var sql = $@"INSERT INTO SPATIAL.COSMOS_LOG (ID, SOURCE, START_TIME, TOOL, USER_ID, TOOL_NAME)
             VALUES (SEQ_COMSOS_LOG.NEXTVAL, '{cosmosLog.Source}', '{cosmosLog.StartTime}', '{cosmosLog.MapTheme}', '{cosmosLog.UserId}', '{cosmosLog.ToolName}')";

            await context.Database.ExecuteSqlRawAsync(sql);
            return Ok();
        }
    }
}
