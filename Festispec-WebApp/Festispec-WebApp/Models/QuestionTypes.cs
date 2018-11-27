using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class QuestionTypes
    {
        public QuestionTypes()
        {
            Questions = new HashSet<Questions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
    }
}
