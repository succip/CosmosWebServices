using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Models
{
    [Table("COSMOS_LOG", Schema="SPATIAL")]
    public class CosmosLog
    {
        [Key]
        [Column ("ID")]
        public int LogId { get; set; }
        [Column("SOURCE")]
        public string? Source { get; set; }
        [Column("START_TIME")]
        public DateTime StartTime { get; set; } = DateTime.Now;
        [Column("USER_ID")]
        public string? UserId { get; set; }
        [Column("TOOL")]
        public string? MapTheme { get; set; }
        [Column("TOOL_NAME")]
        public string? ToolName { get; set; }
    }
}
