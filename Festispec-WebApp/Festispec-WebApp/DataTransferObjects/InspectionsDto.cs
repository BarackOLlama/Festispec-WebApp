using System.Collections.Generic;
using Festispec_WebApp.Models;

namespace Festispec_WebApp.DataTransferObjects
{
    public class InspectionsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int? EventId { get; set; }
        public int? StatusId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Events Event { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<InspectionDates> InspectionDates { get; set; }
        public virtual ICollection<InspectionInspectors> InspectionInspectors { get; set; }
        public virtual ICollection<Questionnaires> Questionnaires { get; set; }
        public virtual ICollection<Quotations> Quotations { get; set; }
    }
}