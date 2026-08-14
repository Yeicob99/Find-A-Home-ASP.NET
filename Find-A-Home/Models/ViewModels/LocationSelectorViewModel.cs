using System.ComponentModel.DataAnnotations;

namespace Find_A_Home.Models.ViewModels
{
    public class LocationSelectorViewModel
    {
        [Required(ErrorMessage = "Seleccione una provincia")]
        public int? ProvinceId { get; set; }
        [Required(ErrorMessage = "Seleccione una zona")]
        public int? ZoneId { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
            = new List<Province>();
        public IEnumerable<Zone> Zones { get; set; }
            = new List<Zone>();
    }
}
