using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class PaymentTypes
    {
        public PaymentTypes()
        {
            Payments = new HashSet<Payments>();
        }

        public int PaymentTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }
    }
}
