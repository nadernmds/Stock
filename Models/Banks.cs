using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class Banks
    {
        public Banks()
        {
            Users = new HashSet<Users>();
        }

        public int BankId { get; set; }
        public string BankName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
