using System;
using System.Collections.Generic;

#nullable disable

namespace Unit_4_MVC_Activity.Models-Tables
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
