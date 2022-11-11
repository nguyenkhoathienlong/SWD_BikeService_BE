using System;
using System.Collections.Generic;

namespace BikeServiceProject_SWD.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public ulong IsActived { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
