using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperience.Entity.Entity
{
    public class TravelerProfileEntity
    {
        public Guid Id { get; set; }

        //Dati personali
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Profilo
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }
        public DateTime CreatedAt { get; set; }

        //Relazioni
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public List<BookingEntity> Bookings { get; set; }
        public List<SavedExperienceEntity> SavedExperiences { get; set; }

    }
}
