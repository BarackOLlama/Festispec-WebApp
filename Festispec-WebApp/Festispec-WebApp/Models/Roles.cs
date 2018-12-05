using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int Id { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
