namespace MuniciPAL.Models
{
    public class AnnouncedEvents
    {
        public int eventID { get; set; }
        public required string eventDate { get; set; }
        public required string eventLocation { get; set; }
        public double eventFee { get; set; }
        public required string eventTheme { get; set; }

    }
}
