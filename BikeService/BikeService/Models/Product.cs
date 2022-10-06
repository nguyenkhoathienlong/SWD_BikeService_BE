using System;
using System.Collections.Generic;

namespace BikeService.Models
{
    public partial class Product
    {
        public Product()
        {
            Products = new HashSet<Product>();
            Services = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float Price { get; set; }
        public int? Quantity { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public string StoreId { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual Store IdNavigation { get; set; } = null!;
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Product> Services { get; set; }
    }
}
