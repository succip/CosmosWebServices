using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Models
{
    [Table ("DRAWINGINDEX", Schema ="SPATIAL")]
    public class DrawingIndex
    {
        [Column ("DNO_ID")]
        public int DnoId { get; set; }
        [Column ("DNO")]
        public string? DrawingNumber { get; set; }
        [Column ("PROJECTNO")]
        public string? ProjectNumber { get; set; }
        [Column ("AB_DATE")]
        public DateTime AsBuiltDate { get; set; }
        [Column ("LOCATION")]
        public string? Location { get; set; }
        [Column ("HOTLINKPATH")]
        public string? HotlinkPath { get; set; }
    }
}
