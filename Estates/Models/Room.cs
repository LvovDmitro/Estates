using Estates.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estates.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int Price { get; set; }
        public RoomCategory RoomCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
