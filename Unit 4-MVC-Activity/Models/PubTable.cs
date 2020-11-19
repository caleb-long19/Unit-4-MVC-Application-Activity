using System;
using System.Collections.Generic;

#nullable disable

namespace Unit_4_MVC_Activity.Models
{
    public partial class PubTable
    {
        public PubTable()
        {
            CustomerBookings = new HashSet<CustomerBooking>();
        }

        public int TableId { get; set; }
        public string NumOfSeats { get; set; }

        public virtual ICollection<CustomerBooking> CustomerBookings { get; set; }
    }
}
