using System;
using System.Collections.Generic;

namespace BikeService.Models
{
    public partial class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int WardId { get; set; }

        public virtual Ward Ward { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
