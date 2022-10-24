﻿namespace BikeService.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public ulong? IsService { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
