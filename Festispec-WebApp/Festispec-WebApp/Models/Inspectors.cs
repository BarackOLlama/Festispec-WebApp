using System;
using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Inspectors
    {
        public Inspectors()
        {
            Answers = new HashSet<Answers>();
            ScheduleItems = new HashSet<ScheduleItems>();
            InspectionInspectors = new HashSet<InspectionInspectors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CertificationDate { get; set; }
        public DateTime? InvalidDate { get; set; }
        public string BankNumber { get; set; }
        public int? AccountId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<ScheduleItems> ScheduleItems { get; set; }
        public virtual ICollection<InspectionInspectors> InspectionInspectors { get; set; }
    }
}
