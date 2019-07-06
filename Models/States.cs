using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class States
    {
        public States()
        {
            Cities = new HashSet<Cities>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}
