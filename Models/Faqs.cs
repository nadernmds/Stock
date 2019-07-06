using System;
using System.Collections.Generic;

namespace Stock.Models
{
    public partial class Faqs
    {
        public int FaqId { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
    }
}
