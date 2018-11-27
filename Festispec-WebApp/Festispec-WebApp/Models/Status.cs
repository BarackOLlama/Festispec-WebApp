using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Status
    {
        public Status()
        {
            Inspections = new HashSet<Inspections>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Inspections> Inspections { get; set; }
    }
}
