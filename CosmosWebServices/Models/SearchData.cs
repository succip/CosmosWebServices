using System.ComponentModel.DataAnnotations.Schema;

namespace CosmosWebServices.Models
{
    [Table ("SEARCH_GIS_NEW", Schema = "SPATIAL")]
    public class SearchData
    {
        [Column("ATTRIBUTE")]
        public string? Field { get; set; }
        [Column("VALUE2FIND")]
        public string? Value { get; set; }
        [Column("FEATURECLASS")]
        public string? LayerName { get; set; }
        [Column("LISTVALUE")]
        public string? DisplayValue { get; set; }
        [Column("FLAG")]
        public string? Flag { get; set; }
        private string? _searchValue = "";
        [Column("SEARCHVALUE")]
        public string? SearchValue {
            get => _searchValue?.ToUpper();
            set => _searchValue = value;
        }
    }
}
