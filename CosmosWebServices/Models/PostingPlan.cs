using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Models
{
    public class PostingPlan
    {
        [Column ("FILEID")]
        public string? FileId { get; set; }
        [Column("FILENAME")]
        public string? FileName { get; set; }
        [Column("PLAN_NO")]
        public string? PlanNumber { get; set; }
        [Column("FILEPATHNAME")]
        public string? HotlinkPath { get; set; }
    }
}
