using Microsoft.AspNetCore.Http; // Ensure you have this namespace for IFormFile
using System.ComponentModel.DataAnnotations;

namespace Estates.ViewModels
{
    public class EditUserDashboardViewModel
    {
        public string Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public int? Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Money must be greater than 0")]
        public int? Money { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        public string? ProfileImageUrl { get; set; }

        [StringLength(50, ErrorMessage = "City name cannot exceed 50 characters")]
        public string? City { get; set; }

        [StringLength(50, ErrorMessage = "State name cannot exceed 50 characters")]
        public string? State { get; set; }

        // If Image is optional, you can remove the [Required] attribute
        public IFormFile Image { get; set; }
    }
}
