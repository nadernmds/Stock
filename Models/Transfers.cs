using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class Transfers
    {
        public int TransferId { get; set; }
        public string Text { get; set; }
        public int? Count { get; set; }
    }
}
