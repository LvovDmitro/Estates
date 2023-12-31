﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Estates.Data.Enum;

namespace Estates.Models
{
    public class Flat
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int Price { get; set; }
        public FlatCategory FlatCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
