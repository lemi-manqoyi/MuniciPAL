namespace MuniciPAL.Models
{
    public class AnnouncedEvents
    {
        public int eventID { get; set; }
        public required DateTime eventDate { get; set; }
        public required string eventName { get; set; }
        public required string eventLocation { get; set; }
        public double eventFee { get; set; }

        public bool isAnnounced = false;
        public required string eventCategory { get; set; }

    }
}
