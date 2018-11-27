using System;

namespace Festispec_WebApp.Models
{
    public partial class EventDates
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? EventId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Events Event { get; set; }
    }
}
