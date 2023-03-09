using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmosWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetSearchData : Controller
    {
        [HttpGet("{query}")]
        public async Task<IActionResult> Get(string query, [FromServices] MyDbContext context)
        {
            string codeBase = "EXT";
            query = query.Replace(" ", "%").ToUpper();
            
            var result = await context.SearchDatas
                .Where(s => s.SearchValue.EndsWith("Layer"))
                .Where(s => s.SearchValue.Contains(query))
                .OrderBy(s => s.SearchValue.IndexOf(query))
                .ThenBy(s => s.SearchValue)
                .ToListAsync();

            result.AddRange(await context.SearchDatas
                .Where(s => !s.SearchValue.EndsWith("Layer"))
                .Where(s => s.SearchValue.Contains(query))
                .OrderBy(s => s.SearchValue.IndexOf(query))
                .ThenBy(s => s.SearchValue)
                .ToListAsync());

            return Ok(result
                .Where(s => s.Flag.Contains(codeBase))
                .Select(s => new { s.Field, s.Value, s.LayerName, s.DisplayValue })
                .Take(100));
        }
    }
}
