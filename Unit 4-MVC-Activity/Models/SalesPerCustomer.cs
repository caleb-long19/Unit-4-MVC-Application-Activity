using System;
using System.Collections.Generic;

#nullable disable

namespace Unit_4_MVC_Activity.Models
{
    public partial class SalesPerCustomer
    {
        public int? TotalOrders { get; set; }
        public decimal? LineTotal { get; set; }
        public string CustomerName { get; set; }
    }
}
