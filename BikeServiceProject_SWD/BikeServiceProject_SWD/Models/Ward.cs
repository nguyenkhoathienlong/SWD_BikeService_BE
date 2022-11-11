using System;
using System.Collections.Generic;

namespace BikeServiceProject_SWD.Models
{
    public partial class Ward
    {
        public Ward()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DistrictId { get; set; }

        public virtual District District { get; set; } = null!;
        public virtual ICollection<Store> Stores { get; set; }
    }
}
