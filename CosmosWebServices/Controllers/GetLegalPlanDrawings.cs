using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;

namespace CosmosWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetLegalPlanDrawings : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string[] planIds, [FromServices] MyDbContext context)
        {
            var result = await context.LegalPlanDrawings
                .FromSqlRaw("SELECT XREF.ECDCID, LP.FILENAME, PB.PLAN_NO, PB.PLAN_TYPE2, PB.YR, PB.STATUS, LP.FILEPATHNAME " +
                "FROM SPATIAL.PLANIMAGEXREF XREF " +
                "INNER JOIN SPATIAL.CADPLANBOUNDARIES PB ON XREF.ECDCID = PB.PLANID " +
                "INNER JOIN SPATIAL.LEGALPLANIMAGELIST LP ON XREF.FILEID = LP.FILEID " +
                "ORDER BY PB.PLAN_TYPE2, PB.PLAN_NO")
                .Where(legalPlanDrawing => planIds.Contains(legalPlanDrawing.EcdcId) && legalPlanDrawing.HotlinkPath != null)
                .ToListAsync();

            return Ok(result);
        }
    }
}
