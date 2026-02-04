using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperience.Entity.Entity
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        
        
        
        
        public TravelerProfileEntity? TravelerProfile { get; set; }
        public HostProfileEntity? HostProfile { get; set; }
        

    }
}
