using TravelExperience.Common;
using TravelExperience.DbContextClass;
using TravelExperience.Entity.Entity;
using TravelExperience.User;

namespace TravelExperience.UserWorker
{
    public class UserManager
    {
        private readonly IStorageServices<UserEntity> _userStorageServices;
        private readonly IStorageServices<HostProfileEntity> _hostProfileStorageServices;
        private readonly IStorageServices<TravelerProfileEntity> _travelerProfileStorageServices;
        private readonly IMapperServices<UserEntity, UserDTO> _userMapperServices;
        private readonly IMapperServices<HostProfileEntity, HostProfileDTO> _hostProfileMapperServices;
        private readonly IMapperServices<TravelerProfileEntity, TravelerProfileDTO> _travelerProfileMapperServices;
        private readonly TravelExperienceDBContext _dbContext;

        public UserManager (IStorageServices<UserEntity> userStorageServices, IStorageServices<HostProfileEntity> hostProfileStorageServices, IStorageServices<TravelerProfileEntity> travelerProfileStorageServices, IMapperServices<UserEntity, UserDTO> userMapperServices, IMapperServices<HostProfileEntity, HostProfileDTO> hostProfileMapperServices, IMapperServices<TravelerProfileEntity, TravelerProfileDTO> travelerProfileMapperServices, TravelExperienceDBContext dbContext)
        {
            _userStorageServices = userStorageServices;
            _hostProfileStorageServices = hostProfileStorageServices;
            _travelerProfileStorageServices = travelerProfileStorageServices;
            _userMapperServices = userMapperServices;
            _hostProfileMapperServices = hostProfileMapperServices;
            _travelerProfileMapperServices = travelerProfileMapperServices;
            _dbContext = dbContext;
        }

        public async Task<HostProfileDTO> ReadHostProfileById(string id)
        {
            Guid hostId = Guid.Parse(id); 
            HostProfileEntity hostProfileEntity = await _hostProfileStorageServices.ReadByIdAsync(hostId);
            return _hostProfileMapperServices.ToDTO(hostProfileEntity);
            
        }
       
        public async Task CreateHostProfileAsync(HostProfileDTO hostProfile, string userId)
        {
            if (string.IsNullOrEmpty(hostProfile.City) || string.IsNullOrEmpty(hostProfile.Country) || string.IsNullOrEmpty(hostProfile.DisplayName))
            {
                throw new Exception("A field is missing");
            }

            Guid guidUserId = Guid.Parse(userId);
            UserEntity user = await _userStorageServices.ReadWithInclude(guidUserId);

            if (user.HostProfile != null)
            {
                throw new Exception("Already exists");
            }

            hostProfile.UserId = guidUserId;
            hostProfile.CreatedAt = DateTime.UtcNow;
            HostProfileEntity profileEntity = _hostProfileMapperServices.ToEntity(hostProfile);
            user.HostProfile = profileEntity;
            await _userStorageServices.CreateAsync(user);
        }
        
        public async Task CreateTravelerProfileAsync(TravelerProfileDTO travelerProfile, string userId)
        {
            if (string.IsNullOrEmpty(travelerProfile.FirstName) || string.IsNullOrEmpty(travelerProfile.LastName) || string.IsNullOrEmpty(travelerProfile.Country) || string.IsNullOrEmpty(travelerProfile.City))
            {
                throw new Exception("A field is missing");
            }
            Guid guidUserId = Guid.Parse(userId);
            UserEntity user = await _userStorageServices.ReadWithInclude(guidUserId);
            if (user.TravelerProfile != null)
            {
                travelerProfile.UserId = guidUserId;
                travelerProfile.CreatedAt = DateTime.UtcNow;
                TravelerProfileEntity entityProfile = _travelerProfileMapperServices.ToEntity(travelerProfile);
                user.TravelerProfile = entityProfile;
                await _userStorageServices.CreateAsync(user);
            }
        }

    }
}
