using System.Collections.Generic;
using Newtonsoft.Json;

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
        [JsonIgnore]
        public virtual ICollection<Inspections> Inspections { get; set; }
    }
}
