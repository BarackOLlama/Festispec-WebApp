using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festispec_WebApp.Models
{
    public partial class InspectionDates
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
