using TravelExperience.Common;

namespace TravelExperience.Booking
{
    public class BookingDTO
    {
        public Guid Id { get; set; }

        public DateTime BookingDate { get; set; }
        public int NumberOfGuests { get; set; }
        public float TotalPrice { get; set; }
        public BookingStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
    }
}
