using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.Common;
using TravelExperience.Entity.Entity;
using TravelExperience.User;

namespace TravelExperience.Mapper
{
    public class UserMapper : IMapperServices<UserEntity, UserDTO>
    {
        private readonly TravelerProfileMapper _travelerProfileMapper;
        private readonly HostProfileMapper _hostProfileMapper;
        public UserMapper(TravelerProfileMapper travelerProfile, HostProfileMapper HostProfile)
        {
            _travelerProfileMapper = travelerProfile;
            _hostProfileMapper = HostProfile;
        }
        public UserDTO ToDTO(UserEntity entity)
        {
            return new UserDTO
            {
                Id = entity.Id,
                Email = entity.Email,
                CreatedAt = entity.CreatedAt,
                TravelerProfile = entity.TravelerProfile != null ? _travelerProfileMapper.ToDTO(entity.TravelerProfile) : null,
                HostProfile = entity.HostProfile != null ? _hostProfileMapper.ToDTO(entity.HostProfile) : null,
            };
        }

        public UserEntity ToEntity(UserDTO dto)
        {
           return new UserEntity
            {
                Id = dto.Id,
                Email = dto.Email,
                CreatedAt = dto.CreatedAt,
                TravelerProfile = dto.TravelerProfile != null ? _travelerProfileMapper.ToEntity(dto.TravelerProfile) : null,
                HostProfile = dto.HostProfile != null ? _hostProfileMapper.ToEntity(dto.HostProfile) : null,
           };
        }
    }
}
