namespace Raamatuklubi.Models.BookClubs
{
    public class CreateEventViewModel
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }
}
