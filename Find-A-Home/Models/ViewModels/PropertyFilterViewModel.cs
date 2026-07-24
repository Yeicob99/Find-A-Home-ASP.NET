namespace Find_A_Home.Models.ViewModels
{
    public class PropertyFilterViewModel
    {
        public int? ProvinceId { get; set; } 
        public int? ZoneId { get; set; } 
        public string PropertyType { get; set; } = string.Empty;
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
