using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class StockAllocations
    {
        public StockAllocations()
        {
            CostAndBenefits = new HashSet<CostAndBenefits>();
            InversePreviousStockAllocation = new HashSet<StockAllocations>();
            Payments = new HashSet<Payments>();
        }

        public long StockAllocationId { get; set; }
        public int? Count { get; set; }
        public int? UserId { get; set; }
        public int? StockId { get; set; }
        public long? PreviousStockAllocationId { get; set; }

        public virtual StockAllocations PreviousStockAllocation { get; set; }
        public virtual Stocks Stock { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<CostAndBenefits> CostAndBenefits { get; set; }
        public virtual ICollection<StockAllocations> InversePreviousStockAllocation { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
