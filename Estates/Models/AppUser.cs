using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estates.Models
{
    public class AppUser : IdentityUser
    {
        public int? Price { get; set; }
        public int? Money { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Flat> flat { get; set; }
        public ICollection<Room> room { get; set; }
    }
}
