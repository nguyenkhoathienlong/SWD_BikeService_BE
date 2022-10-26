using System;
using System.Collections.Generic;

namespace BikeService.Models
{
    public partial class Model
    {
        public Model()
        {
            Motorbikes = new HashSet<Motorbike>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateOnly ManufacturingDate { get; set; }
        public int BrandId { get; set; }
        public string Type { get; set; } = null!;
        public int EngineCapacity { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<Motorbike> Motorbikes { get; set; }
    }
}
