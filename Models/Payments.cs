using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class Payments
    {
        public Payments()
        {
            ApproveUserPayments = new HashSet<ApproveUserPayments>();
        }

        public long PaymentId { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public string BillCode { get; set; }
        public int? UserId { get; set; }
        public int? CostAndBenefitId { get; set; }
        public int? InstalmentTemplateId { get; set; }
        public long? StockAllocationId { get; set; }
        public int? PaymentTypeId { get; set; }
        public bool? verified { get; set; }

        public virtual CostAndBenefits CostAndBenefit { get; set; }
        public virtual InstalmentTemplates InstalmentTemplate { get; set; }
        public virtual PaymentTypes PaymentType { get; set; }
        public virtual StockAllocations StockAllocation { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<ApproveUserPayments> ApproveUserPayments { get; set; }
    }
}
