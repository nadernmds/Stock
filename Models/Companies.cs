using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class Companies
    {
        public Companies()
        {
            InstalmentTemplates = new HashSet<InstalmentTemplates>();
            Stocks = new HashSet<Stocks>();
            UserCompanies = new HashSet<UserCompanies>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<InstalmentTemplates> InstalmentTemplates { get; set; }
        public virtual ICollection<Stocks> Stocks { get; set; }
        public virtual ICollection<UserCompanies> UserCompanies { get; set; }
    }
}
