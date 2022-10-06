using System;
using System.Collections.Generic;

namespace BikeService.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Motorbikes = new HashSet<Motorbike>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }

        public virtual ICollection<Motorbike> Motorbikes { get; set; }
    }
}
