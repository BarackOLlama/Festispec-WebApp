using System.Collections.Generic;
using Festispec_WebApp.Models;

namespace Festispec_WebApp.DataTransferObjects
{
    public class QuestionnaireDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public int Version { get; set; }
        public string Comments { get; set; }
        public int? InspectionId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual InspectionsDto Inspection { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}