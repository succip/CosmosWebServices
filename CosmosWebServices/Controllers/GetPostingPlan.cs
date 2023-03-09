using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmosWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPostingPlan : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string[] fileIds, [FromServices] MyDbContext context)
        {
            var result = await context.PostingPlans
                .FromSqlRaw("SELECT LP.FILENAME, PB.PLAN_NO, LP.FILEPATHNAME, LP.FILEID " +
                "FROM SPATIAL.CADPOSTINGPLANS PB " +
                "JOIN SPATIAL.LEGALPLANIMAGELIST LP " +
                "ON LP.FILEID = PB.PLAN_NO_ID " +
                "ORDER BY PB.PLAN_NO_ID, LP.FILENAME")
                .Where(postingPlan => fileIds.Contains(postingPlan.FileId) && postingPlan.HotlinkPath != null)
                .ToListAsync();

            return Ok(result);
        }
    }
}
