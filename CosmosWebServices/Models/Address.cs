using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices
{
    [Table ("V_PR_PROPERTY_DETAILS", Schema = "SPATIAL")]
    public class Address
    {
        [Column("MSLINK")]
        public int? Mslink { get; set; }
        [Column("UNIT")]
        public string? Unit { get; set; }
        [Column("STREET")]
        public string? Street { get; set; }
        [Column("HOUSE")]
        public int? House { get; set; }

        [NotMapped]
        public string? FullAddress
        {
            get => $"{House} {Street}";
        }
    }
}
