using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Contacts = new HashSet<Contacts>();
            Events = new HashSet<Events>();
            Quotations = new HashSet<Quotations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adres { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public DateTime? StartingDate { get; set; }
        public short? ChamberOfCommerceNumber { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<Events> Events { get; set; }
        public virtual ICollection<Quotations> Quotations { get; set; }
    }
}
