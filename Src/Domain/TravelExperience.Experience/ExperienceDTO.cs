namespace TravelExperience.Experience
{
    public class ExperienceDTO
    {
        public Guid Id { get; set; }
        public Guid HostProfileId { get; set; }
        public Guid BookingId { get; set; }

        //informazioni sull'esperienza
        public string Title { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public string Location { get; set; }
        public float PricePerPerson { get; set; }
        public int MaxParticipants { get; set; }
        public int DurationInHours { get; set; }
        public List<string> ImagesUrls { get; set; }

        //Quality
        public float Rating { get; set; }
        public int TotalReviews { get; set; }
        public int TotalBookings { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
