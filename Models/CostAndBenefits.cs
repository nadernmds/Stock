using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class CostAndBenefits
    {
        public CostAndBenefits()
        {
            Payments = new HashSet<Payments>();
        }

        public int CostAndBenefitId { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public decimal? BenefitPerUnit { get; set; }
        public int? UserId { get; set; }
        public long? StockAllocationId { get; set; }

        public virtual StockAllocations StockAllocation { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
