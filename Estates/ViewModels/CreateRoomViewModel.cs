using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // Ensure you have this namespace for IFormFile
using Estates.Data.Enum;
using Estates.Models;

namespace Estates.ViewModels
{
    public class CreateRoomViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public Address Address { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Room category is required")]
        public RoomCategory RoomCategory { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public int Price { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public string AppUserId { get; set; }
    }
}
