using System;
using System.Collections.Generic;

#nullable disable

namespace Unit_4_MVC_Activity.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
