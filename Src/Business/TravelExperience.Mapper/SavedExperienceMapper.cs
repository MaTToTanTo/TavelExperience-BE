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
    public class SavedExperienceMapper : IMapperServices<SavedExperienceEntity, SavedExperienceDTO>
    {
        public SavedExperienceDTO ToDTO(SavedExperienceEntity entity)
        {
            return new SavedExperienceDTO
            {
                Id = entity.Id,
                SavedAt = entity.SavedAt
            };
        }

        public SavedExperienceEntity ToEntity(SavedExperienceDTO dto)
        {
            return new SavedExperienceEntity
            {
                Id = dto.Id,
                SavedAt = dto.SavedAt
            };
        }
    }
}
