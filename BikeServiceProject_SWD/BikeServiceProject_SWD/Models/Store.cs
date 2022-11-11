using System;
using System.Collections.Generic;

namespace BikeServiceProject_SWD.Models
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            StoreCategories = new HashSet<StoreCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int WardId { get; set; }

        public virtual Ward Ward { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<StoreCategory> StoreCategories { get; set; }
    }
}
