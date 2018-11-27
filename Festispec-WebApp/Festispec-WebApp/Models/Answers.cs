namespace Festispec_WebApp.Models
{
    public partial class Answers
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? QuestionId { get; set; }
        public int? InspectorId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Inspectors Inspector { get; set; }
        public virtual Questions Question { get; set; }
    }
}
