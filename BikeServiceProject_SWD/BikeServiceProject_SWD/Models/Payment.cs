using System;
using System.Collections.Generic;

namespace BikeServiceProject_SWD.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int PaymentMethodId { get; set; }
        public float AmountPaid { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
    }
}
