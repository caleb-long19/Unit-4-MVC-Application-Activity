using System;
using System.Collections.Generic;

#nullable disable

namespace Unit_4_MVC_Activity.Models-Tables
{
    public partial class PubHour
    {
        public int DayId { get; set; }
        public string Dow { get; set; }
        public string PubStatus { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }
    }
}
