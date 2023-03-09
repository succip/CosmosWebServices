using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Models
{
    [Table ("DNO_XREF", Schema = "SPATIAL")]
    public class DnoXRef
    {
        [Column ("DNO_ID")]
        public int DnoId { get; set; }
        [Column ("FACILITYID")]
        public string? FacilityId { get; set; }
        [Column ("FEATURECLASS")]
        public string? FeatureClass { get; set; }
    }
}
