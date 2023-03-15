using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmosWebServices.Controllers
{
    public class CctvRequest
    {
        public string? DataType { get; set; }
        public int DnoId { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class GetCctvData : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CctvRequest cctvRequest, [FromServices] MyDbContext context)
        {
            var result = await context.CctvDatas
                .FromSqlRaw("SELECT DI.DNO_ID, DI.DNO, DI.AB_DATE, DI.LOCATION, DI.HOTLINKPATH, DI.DRAWINGTYPE, FI.FEATURECLASS " +
                "FROM SPATIAL.DRAWINGINDEX DI " +
                "JOIN SPATIAL.FACILITYID_LIST FI ON DI.DNO = FI.FACILITYID " +
                "ORDER BY LPAD(DI.DNO,10,'0') DESC, DI.AB_DATE DESC")
                .Where(cctvData => cctvData.DnoId == cctvRequest.DnoId && cctvData.HotlinkPath != null)
                .ToListAsync();
            return Ok(result);
        }
    }
}
