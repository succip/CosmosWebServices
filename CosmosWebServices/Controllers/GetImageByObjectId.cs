using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CosmosWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetImageByObjectId : Controller
    {
        [HttpGet("{objectId}")]
        public async Task<IActionResult> Get(string objectId, [FromServices] IMemoryCache cache, [FromServices] MyDbContext context)
        {
            string sqlString = $"SELECT s.FACILITYID, a.DATA, a.ATTACHMENTID FROM SPATIAL.TRNBIKERACKS s, SPATIAL.TRNBIKERACKS__ATTACH a WHERE s.OBJECTID = a.REL_OBJECTID AND s.OBJECTID={objectId}";

            CosmosImage? cosmosImage = await context.CosmosImages
                .FromSqlRaw(sqlString)
                .FirstOrDefaultAsync();

            if (cosmosImage == null) return NotFound();

            string cacheKey = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
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
