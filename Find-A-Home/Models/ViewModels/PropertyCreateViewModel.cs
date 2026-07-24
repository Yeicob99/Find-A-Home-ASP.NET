using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Find_A_Home.Models.ViewModels
{
    public class PropertyCreateViewModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }
        public string? PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public double Area { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
        public bool HasPool { get; set; }
        public bool HasGym { get; set; }
        public bool HasSecurity { get; set; }
        public bool HasGarden { get; set; }
        public bool HasTerrace { get; set; }
        public bool HasConcierge { get; set; }
        public bool HasStorage { get; set; }
        public bool HasParking { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
