using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Models
{
    public class LegalPlanDrawing
    {
        [Column("ECDCID")]
        public string? EcdcId { get; set; }
        [Column("FILENAME")]
        public string? FileName { get; set; }
        [Column("PLAN_NO")]
        public string? PlanNumber { get; set; }
        [Column("PLAN_TYPE2")]
        public string? PlanType { get; set; }
        [Column("YR")]
        public int Year { get; set; }
        [Column("STATUS")]
        public string? Status { get; set; }
        [NotMapped]
        private string? _hotlinkPath = "";
        [Column("FILEPATHNAME")]
        public string? HotlinkPath
        {
            get => _hotlinkPath?.Replace("http", "https");
            set => _hotlinkPath = value;
        }
    }
}
