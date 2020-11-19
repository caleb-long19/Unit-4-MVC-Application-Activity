using System;
using System.Collections.Generic;

#nullable disable

namespace Unit_4_MVC_Activity.Models
{
    public partial class CustomerContact
    {
        public int CustomerId { get; set; }
        public int? BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }

        public virtual CustomerBooking Booking { get; set; }
    }
}
