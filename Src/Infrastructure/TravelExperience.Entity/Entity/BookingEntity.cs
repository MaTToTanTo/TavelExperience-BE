using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.Common;

namespace TravelExperience.Entity.Entity
{
    public class BookingEntity
    {
        public Guid Id { get; set; }

        public DateTime BookingDate { get; set; }
        public int NumberOfGuests { get; set; }
        public float TotalPrice { get; set; }
        public BookingStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? CancelledAt { get; set; }

        //Relazioni

        public Guid TravelerProfileId { get; set; }
        public TravelerProfileEntity TravelerProfile { get; set; }
        public Guid ExperienceId { get; set; }
        public ExperienceEntity Experience { get; set; }

    }
}
