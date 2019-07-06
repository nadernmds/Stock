using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class Stocks
    {
        public Stocks()
        {
            StockAllocations = new HashSet<StockAllocations>();
        }

        public int StockId { get; set; }
        public decimal? PricePerUnit { get; set; }
        public int? Count { get; set; }
        public int? CompanyId { get; set; }

        public virtual Companies Company { get; set; }
        public virtual ICollection<StockAllocations> StockAllocations { get; set; }
    }
}
