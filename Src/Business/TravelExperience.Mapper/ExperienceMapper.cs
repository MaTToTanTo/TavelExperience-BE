using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.Booking;
using TravelExperience.Common;
using TravelExperience.Entity.Entity;
using TravelExperience.Experience;

namespace TravelExperience.Mapper
{
    public class ExperienceMapper : IMapperServices<ExperienceEntity, ExperienceDTO>
    {
        public ExperienceDTO ToDTO(ExperienceEntity entity)
        {
            ExperienceDTO dto = new ExperienceDTO()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Information = entity.Information,
                ImagesUrls = entity.ImagesUrls.ToList(),
                Location = entity.Location,
                PricePerPerson = entity.PricePerPerson,
                MaxParticipants = entity.MaxParticipants,
                DurationInHours = entity.DurationInHours,
                CreatedAt = entity.CreatedAt,
                Rating = entity.Rating,
                TotalBookings = entity.TotalBookings,
                TotalReviews = entity.TotalReviews,
            };
            return dto;
        }

        public ExperienceEntity ToEntity(ExperienceDTO dto)
        {
           ExperienceEntity entity = new ExperienceEntity()
           {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Information = dto.Information,
                ImagesUrls = dto.ImagesUrls.ToList(),
                Location = dto.Location,
                PricePerPerson = dto.PricePerPerson,
                MaxParticipants = dto.MaxParticipants,
                DurationInHours = dto.DurationInHours,
                CreatedAt = dto.CreatedAt,
                Rating = dto.Rating,
                TotalBookings = dto.TotalBookings,
                TotalReviews = dto.TotalReviews,
           };
              return entity;
        }
    }
}
