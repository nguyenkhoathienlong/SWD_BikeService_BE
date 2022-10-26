using System;
using System.Collections.Generic;

namespace BikeService.Models
{
    public partial class Area
    {
        public Area()
        {
            Wards = new HashSet<Ward>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? DistrictId { get; set; }

        public virtual District? District { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }
    }
}
