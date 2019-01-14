namespace Festispec_WebApp.DataTransferObjects
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int InspectorId { get; set; }
    }
}