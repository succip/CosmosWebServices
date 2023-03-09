using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Models
{
    public class AsBuiltDrawing
    {
        public string? DrawingNumber { get; set; }
        public string? ProjectNumber { get; set; }
        public string? HotlinkPath { get; set; }
        public DateTime AsBuiltDate { get; set; }
    }
}
