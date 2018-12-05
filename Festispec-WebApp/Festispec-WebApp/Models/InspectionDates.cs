using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class InspectionDates
    {
        public InspectionDates()
        {
            Inspections = new HashSet<Inspections>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Inspections> Inspections { get; set; }
    }
}
