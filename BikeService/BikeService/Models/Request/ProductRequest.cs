﻿using System.ComponentModel.DataAnnotations;

namespace BikeService.Models.Request
{
    public class ProductRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        public float Price { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string StoreId { get; set; } = null!;
    }
}
