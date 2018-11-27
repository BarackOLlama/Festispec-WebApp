using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Questionnaires
    {
        public Questionnaires()
        {
            Questions = new HashSet<Questions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public int Version { get; set; }
        public string Comments { get; set; }
        public int? InspectionId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Inspections Inspection { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
