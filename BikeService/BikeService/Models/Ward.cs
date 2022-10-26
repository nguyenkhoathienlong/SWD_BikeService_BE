using System;
using System.Collections.Generic;

namespace BikeService.Models
{
    public partial class Ward
    {
        public Ward()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int AreaId { get; set; }

        public virtual Area Area { get; set; } = null!;
        public virtual ICollection<Store> Stores { get; set; }
    }
}
