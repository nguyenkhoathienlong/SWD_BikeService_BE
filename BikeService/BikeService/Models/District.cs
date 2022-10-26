﻿using System;
using System.Collections.Generic;

namespace BikeService.Models
{
    public partial class District
    {
        public District()
        {
            Areas = new HashSet<Area>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Area> Areas { get; set; }
    }
}
