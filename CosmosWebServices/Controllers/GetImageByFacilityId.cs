using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CosmosWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetImageByFacilityId : Controller
    {
        [HttpGet("{facilityId}")]
        public async Task<IActionResult> Get(string facilityId,[FromServices] IMemoryCache cache, [FromServices] MyDbContext context)
        {
            string sqlString = $"SELECT s.FACILITYID, a.DATA, a.ATTACHMENTID FROM SPATIAL.SIGNLOCATION s, SPATIAL.SIGNLOCATION__ATTACH a WHERE s.GLOBALID = a.REL_GLOBALID AND s.FACILITYID = '{facilityId}'";

            CosmosImage? cosmosImage = await context.CosmosImages
                .FromSqlRaw(sqlString)
                .FirstOrDefaultAsync();

            if (cosmosImage == null) return NotFound();

            string cacheKey = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");

            byte[] imageData;

            if (!cache.TryGetValue(cacheKey, out imageData))
            {
                imageData = cosmosImage.Data;

                if (imageData !=null)
                {
                    cache.Set(cacheKey, imageData, TimeSpan.FromMinutes(10));
                }
            }

            return await Task.FromResult(File(imageData, "image/jpeg"));
        }
    }
}
