using System;
using System.Collections.Generic;

namespace BikeServiceProject_SWD.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Model> Models { get; set; }
    }
}
