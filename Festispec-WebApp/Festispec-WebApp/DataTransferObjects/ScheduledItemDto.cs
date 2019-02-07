using System;

namespace Festispec_WebApp.DataTransferObjects
{
    public class ScheduledItemDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int InspectorId { get; set; }
    }
}