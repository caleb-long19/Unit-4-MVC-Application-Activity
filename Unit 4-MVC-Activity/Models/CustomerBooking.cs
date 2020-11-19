using System;
using System.Collections.Generic;

#nullable disable

namespace Unit_4_MVC_Activity.Models
{
    public partial class CustomerBooking
    {
        public CustomerBooking()
        {
            CustomerContacts = new HashSet<CustomerContact>();
        }

        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartingTime { get; set; }
        public int? TableId { get; set; }
        public string PartySize { get; set; }

        public virtual PubTable Table { get; set; }
        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }
    }
}
