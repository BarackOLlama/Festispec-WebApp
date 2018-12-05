using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Inspections
    {
        public Inspections()
        {
            InspectionInspectors = new HashSet<InspectionInspectors>();
            Questionnaires = new HashSet<Questionnaires>();
            Quotations = new HashSet<Quotations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int? EventId { get; set; }
        public int? StatusId { get; set; }
        public int? InspectionDateId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Events Event { get; set; }
        public virtual InspectionDates InspectionDate { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<InspectionInspectors> InspectionInspectors { get; set; }
        public virtual ICollection<Questionnaires> Questionnaires { get; set; }
        public virtual ICollection<Quotations> Quotations { get; set; }
    }
}
