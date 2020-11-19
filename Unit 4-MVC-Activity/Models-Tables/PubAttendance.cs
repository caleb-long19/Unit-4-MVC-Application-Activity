using System;
using System.Collections.Generic;

#nullable disable

namespace Unit_4_MVC_Activity.Models-Tables
{
    public partial class PubAttendance
    {
        public int BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartingTime { get; set; }
    }
}
