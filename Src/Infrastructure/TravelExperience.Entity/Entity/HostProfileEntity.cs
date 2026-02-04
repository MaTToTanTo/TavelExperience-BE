using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperience.Entity.Entity
{
    public class HostProfileEntity : DbEntity
    {
        public Guid Id { get; set; }

        //Dati personali
        public string DisplayName { get; set; }
        public string? BusinessName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        //Profilo
        public string? AvatarUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Bio { get; set; }

        //Qualifiche
        public bool IsVerified { get; set; }
        public float Rating { get; set; }
        public int TotalReviews { get; set; }

        public DateTime CreatedAt { get; set; }

        //Relazioni
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public List<ExperienceEntity> HostedExperiences { get; set; }
    }

}
