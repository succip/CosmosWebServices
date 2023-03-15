using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Models
{
    public class CctvData
    {
        [Column("DNO_ID")]
        public int DnoId { get; set; }
        [Column("DNO")]
        public string? FacilityId { get; set; }
        [Column("AB_DATE")]
        public DateTime CaptureDate { get; set; }
        [Column("LOCATION")]
        public string? Location { get; set; }
        [Column("HOTLINKPATH")]
        public string? HotlinkPath { get; set; }
    }
}
