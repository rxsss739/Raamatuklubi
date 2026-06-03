namespace Raamatuklubi.Models.BookClubs
{
    public class OngoingEventsViewModel
    {
        public Guid Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<string> Attendees { get; set; }
    }
}
