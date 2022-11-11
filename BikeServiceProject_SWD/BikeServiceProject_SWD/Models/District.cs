using System;
using System.Collections.Generic;

namespace BikeServiceProject_SWD.Models
{
    public partial class District
    {
        public District()
        {
            Areas = new HashSet<Area>();
            Wards = new HashSet<Ward>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }
    }
}
