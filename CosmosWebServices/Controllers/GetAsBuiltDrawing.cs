using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmosWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAsBuiltDrawings : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string[] facilityIds, [FromServices] MyDbContext context)
        {
            var result = await context.DnoXRefs
                .Join(context.DrawingIndexes,
                dnoXRef => dnoXRef.DnoId,
                drawingIndex => drawingIndex.DnoId,
                (dnoXRef, drawingIndex) => new { DnoXRef = dnoXRef, DrawingIndex = drawingIndex })
                .Where(asBuiltDrawingView => facilityIds.Contains(asBuiltDrawingView.DnoXRef.FacilityId) && asBuiltDrawingView.DrawingIndex.HotlinkPath != null)
                .Select(asBuiltDrawingView => new AsBuiltDrawing
                {
                    DrawingNumber = asBuiltDrawingView.DrawingIndex.DrawingNumber,
                    ProjectNumber = asBuiltDrawingView.DrawingIndex.ProjectNumber,
                    HotlinkPath = asBuiltDrawingView.DrawingIndex.HotlinkPath,
                    AsBuiltDate = asBuiltDrawingView.DrawingIndex.AsBuiltDate
                })
                .OrderByDescending(asBuiltDrawing => asBuiltDrawing.ProjectNumber)
                .GroupBy(asBuiltDrawing => new { asBuiltDrawing.DrawingNumber, asBuiltDrawing.ProjectNumber, asBuiltDrawing.AsBuiltDate })
                .Select(grouped => grouped.First())
                .ToListAsync();

            return Ok(result);
        }
    }
}
