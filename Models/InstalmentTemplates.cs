using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class InstalmentTemplates
    {
        public InstalmentTemplates()
        {
            Payments = new HashSet<Payments>();
        }

        public int InstalmentTemplateId { get; set; }
        public string Title { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Count { get; set; }
        public string Payday { get; set; }
        public decimal? Amount { get; set; }
        public int? CompanyId { get; set; }

        public virtual Companies Company { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
