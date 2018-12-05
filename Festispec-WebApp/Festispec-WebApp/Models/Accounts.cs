using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Inspectors = new HashSet<Inspectors>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsAdmin { get; set; }
        public int? RoleId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Inspectors> Inspectors { get; set; }
    }
}
