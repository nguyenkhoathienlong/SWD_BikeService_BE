using System;
using System.Collections.Generic;

namespace BikeService.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
