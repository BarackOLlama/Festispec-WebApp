using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class ScheduleItems
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public bool Scheduled { get; set; }
        public TimeSpan? AvailableStartTime { get; set; }
        public TimeSpan? AvailableEndTime { get; set; }
        public TimeSpan? ScheduleStartTime { get; set; }
        public TimeSpan? ScheduleEndTime { get; set; }
        public int? InspectorId { get; set; }
        public virtual Inspectors Inspector { get; set; }
        public bool IsDeleted { get; set; }
    }
}
