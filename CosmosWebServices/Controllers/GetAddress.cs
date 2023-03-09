using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmosWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAddress : ControllerBase
    {
        [HttpGet("{mslink}")]
        public async Task<IActionResult> Get(long mslink, [FromServices] MyDbContext context)
        {
            var addresses = await context.Addresses
                .Where(p => p.Mslink == mslink)
                .Select(p => new { p.Unit, p.House, p.Street, p.FullAddress })
                .OrderBy(p => p.Unit)
                .ThenBy(p => p.House)
                .ThenBy(p => p.Street)
                .Distinct()
                .ToListAsync();

            return Ok(addresses);
        }
    }
}
