using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Models
{
    [Table("COSMOS_LOG", Schema = "SPATIAL")]
    public class CosmosLog
    {
        [Key]
        [Column("ID")]
        public int LogId { get; set; }
        [Column("SOURCE")]
        public string? Source { get; set; }
        [NotMapped]
        private DateTime _startTime = DateTime.Now;
        [Column("START_TIME")]
        public string StartTime
        {
            get => _startTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        [Column("USER_ID")]
        public string? UserId { get; set; }
        [Column("TOOL")]
        public string? MapTheme { get; set; }
        [Column("TOOL_NAME")]
        public string? ToolName { get; set; }
    }
}
