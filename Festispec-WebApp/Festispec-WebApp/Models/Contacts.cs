using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Contacts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public int? CustomerId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
