using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Users = new HashSet<Users>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }

        public virtual States State { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
