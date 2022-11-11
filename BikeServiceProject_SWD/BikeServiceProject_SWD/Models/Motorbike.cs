using System;
using System.Collections.Generic;

namespace BikeServiceProject_SWD.Models
{
    public partial class Motorbike
    {
        public Motorbike()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string LicensePlate { get; set; } = null!;
        public int CustomerId { get; set; }
        public ulong? IsActived { get; set; }
        public int? ModelId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Model? Model { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
