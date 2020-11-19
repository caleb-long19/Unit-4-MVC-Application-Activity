using System;
using System.Collections.Generic;

#nullable disable

namespace Unit_4_MVC_Activity.Models-Tables
{
    public partial class Sale
    {
        public double? TotalCost { get; set; }
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
    }
}
