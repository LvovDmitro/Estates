using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // Ensure you have this namespace for IFormFile
using Estates.Data.Enum;
using Estates.Models;

namespace Estates.ViewModels
{
    public class EditRoomViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public int Price { get; set; }

        // If Image is optional, you can remove the [Required] attribute
        public IFormFile Image { get; set; }

        // If URL is optional, you can remove the [Required] attribute
        public string? URL { get; set; }

        [Required(ErrorMessage = "Address ID is required")]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public Address Address { get; set; }

        [Required(ErrorMessage = "Room category is required")]
        public RoomCategory RoomCategory { get; set; }
    }
}
