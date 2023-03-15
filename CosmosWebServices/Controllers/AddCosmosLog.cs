using CosmosWebServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddCosmosLog : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CosmosLog cosmosLog, [FromServices] MyDbContext context)
        {
            return Ok();
        }
    }
}
