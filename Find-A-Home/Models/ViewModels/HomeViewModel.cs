namespace Find_A_Home.Models.ViewModels
{
    public class HomeViewModel
    {
        public PropertyFilterViewModel Filters { get; set; } = new();
        public IEnumerable<Property> FeaturedProperties { get; set; } = new List<Property>();
        public LocationSelectorViewModel Location { get; set; } = new();
    }
}
