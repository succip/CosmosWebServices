using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CosmosWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetCosmosImage : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IMemoryCache cache, [FromServices] MyDbContext context)
        {
            string cacheKey = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");

            CosmosImage? cosmosImage = await context.CosmosImages
                .FromSqlRaw("SELECT SA.DATA, S.FACILITYID, SA.ATTACHMENTID " +
                "FROM SPATIAL.SIGNLOCATION S, SPATIAL.SIGNLOCATION__ATTACH sa " +
                "WHERE S.GLOBALID = SA.REL_GLOBALID AND s.FACILITYID = '1002086659'")
                .FirstOrDefaultAsync();

            if (cosmosImage == null)
            {
                return NotFound();
            }

            byte[] imageData;

            if (!cache.TryGetValue(cacheKey, out imageData))
            {
                imageData = cosmosImage.Data;

                if (imageData != null)
                {
                    cache.Set(cacheKey, imageData, TimeSpan.FromMinutes(10));
                }
            }

            return await Task.FromResult(File(imageData, "image/jpeg"));
        }
    }
}
