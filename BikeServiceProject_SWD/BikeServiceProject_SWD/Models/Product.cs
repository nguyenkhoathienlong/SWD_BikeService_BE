using System;
using System.Collections.Generic;

namespace BikeServiceProject_SWD.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Products = new HashSet<Product>();
            Services = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float Price { get; set; }
        public int? Quantity { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CategoryId { get; set; }
        public int StoreId { get; set; }
        public ulong IsService { get; set; }
        public ulong IsActive { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Manufacturer? Manufacturer { get; set; }
        public virtual Store Store { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Product> Services { get; set; }
    }
}
