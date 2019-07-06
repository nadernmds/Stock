using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class ApproveUserPayments
    {
        public int ApproveUserPaymentsId { get; set; }
        public int? UserId { get; set; }
        public long? PaymentId { get; set; }

        public virtual Payments Payment { get; set; }
        public virtual Users User { get; set; }
    }
}
