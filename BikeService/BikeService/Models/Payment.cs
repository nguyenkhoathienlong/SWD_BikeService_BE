using System;
using System.Collections.Generic;

namespace BikeService.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int PaymentMethodId { get; set; }
        public float AmountPaid { get; set; }
        public int OrderId { get; set; }
    }
}
