using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class EventDates
    {
        public EventDates()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}
