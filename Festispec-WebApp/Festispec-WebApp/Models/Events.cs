using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Events
    {
        public Events()
        {
            Inspections = new HashSet<Inspections>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public int? CustomerId { get; set; }
        public bool IsDeleted { get; set; }
        public int? EventDateId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual EventDates EventDate { get; set; }
        public virtual ICollection<Inspections> Inspections { get; set; }
    }
}
