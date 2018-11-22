using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class InspectionInspectors
    {
        public int InspectionId { get; set; }
        public int InspectorId { get; set; }

        public virtual Inspections Inspection { get; set; }
        public virtual Inspectors Inspector { get; set; }
    }
}
