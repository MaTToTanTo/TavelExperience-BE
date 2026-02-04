using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.Common;
using TravelExperience.Entity.Entity;
using TravelExperience.User;

namespace TravelExperience.Mapper
{
    public class HostProfileMapper : IMapperServices<HostProfileEntity, HostProfileDTO>
    {
        public HostProfileDTO ToDTO(HostProfileEntity entity)
        {
            HostProfileDTO dto = new HostProfileDTO()
            {
                Id = entity.Id,
                DisplayName = entity.DisplayName,
                BusinessName = entity.BusinessName,
                Country = entity.Country,
                City = entity.City,
                AvatarUrl = entity.AvatarUrl,
                WebsiteUrl = entity.WebsiteUrl,
                Bio = entity.Bio,
                IsVerified = entity.IsVerified,
                Rating = entity.Rating,
                TotalReviews = entity.TotalReviews,
                CreatedAt = entity.CreatedAt
            };
            return dto;
        }

        public HostProfileEntity ToEntity(HostProfileDTO dto)
        {
            HostProfileEntity entity = new HostProfileEntity()
                {
                Id = dto.Id,
                DisplayName = dto.DisplayName,
                BusinessName = dto.BusinessName,
                Country = dto.Country,
                City = dto.City,
                AvatarUrl = dto.AvatarUrl,
                WebsiteUrl = dto.WebsiteUrl,
                Bio = dto.Bio,
                IsVerified = dto.IsVerified,
                Rating = dto.Rating,
                TotalReviews = dto.TotalReviews,
                CreatedAt = dto.CreatedAt
            };
            return entity;
        }
    }
}
