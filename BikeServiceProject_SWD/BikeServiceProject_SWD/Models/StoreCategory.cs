using System;
using System.Collections.Generic;

namespace BikeServiceProject_SWD.Models
{
    public partial class StoreCategory
    {
        public StoreCategory()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Store> Stores { get; set; }
    }
}
