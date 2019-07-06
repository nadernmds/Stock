using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class UserCompanies
    {
        public int UserCompanyId { get; set; }
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }

        public virtual Companies Company { get; set; }
        public virtual Users User { get; set; }
    }
}
