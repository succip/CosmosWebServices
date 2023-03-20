using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Models
{
    public class CosmosImage
    {
        [Column("FACILITYID")]
        public string? FacilityId { get; set; }
        [Column("DATA")]
        public byte[]? Data { get; set; }
        [Column("ATTACHMENTID")]
        public string? AttachmentId { get; set; }
    }
}
