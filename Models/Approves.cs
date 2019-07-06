using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class Approves
    {
        public int ApproveId { get; set; }
        public int? ApproverUserId { get; set; }
        public int? UserId { get; set; }

        public virtual Users ApproverUser { get; set; }
        public virtual Users User { get; set; }
    }
}
