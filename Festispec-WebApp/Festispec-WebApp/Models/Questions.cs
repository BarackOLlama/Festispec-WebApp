using System.Collections.Generic;

namespace Festispec_WebApp.Models
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public string Comments { get; set; }
        public string Options { get; set; }
        public string Columns { get; set; }
        public int? QuestionnaireId { get; set; }
        public int? QuestionTypeId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual QuestionTypes QuestionType { get; set; }
        public virtual Questionnaires Questionnaire { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
    }
}
