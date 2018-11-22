using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Quotations
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int? CustomerId { get; set; }
        public int? InspectionId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Inspections Inspection { get; set; }
    }
}
