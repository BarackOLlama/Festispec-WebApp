using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class InspectionDates
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? InspectionId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Inspections Inspection { get; set; }
    }
}
