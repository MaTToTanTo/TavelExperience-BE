using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperience.Entity.Entity
{
    public class SavedExperienceEntity: DbEntity
    {
        public Guid Id { get; set; }

        public DateTime SavedAt { get; set; }

        // Relazioni
        public Guid TravelerProfileId { get; set; }
        public TravelerProfileEntity TravelerProfile { get; set; }
        public Guid ExperienceId { get; set; }
        public ExperienceEntity Experience { get; set; }
    }
}
