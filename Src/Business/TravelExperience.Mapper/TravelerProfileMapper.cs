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
    public class TravelerProfileMapper : IMapperServices<TravelerProfileEntity, TravelerProfileDTO>
    {
        public TravelerProfileDTO ToDTO(TravelerProfileEntity entity)
        {
            TravelerProfileDTO dto = new TravelerProfileDTO()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Country = entity.Country,
                City = entity.City,
                DateOfBirth = entity.DateOfBirth,
                AvatarUrl = entity.AvatarUrl,
                Bio = entity.Bio,
                CreatedAt = entity.CreatedAt
            };
            return dto;
        }

        public TravelerProfileEntity ToEntity(TravelerProfileDTO dto)
        {
            TravelerProfileEntity entity = new TravelerProfileEntity()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Country = dto.Country,
                City = dto.City,
                DateOfBirth = dto.DateOfBirth,
                AvatarUrl = dto.AvatarUrl,
                Bio = dto.Bio,
                CreatedAt = dto.CreatedAt
            };
            return entity;
        }
    }
}
