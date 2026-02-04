using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.Common;
using TravelExperience.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using TravelExperience.DbContextClass;
using System.Linq.Expressions;

namespace TravelExperience.Entity
{
    public class ExperienceStorageServices : IStorageServices<ExperienceEntity>
    {
        private readonly TravelExperienceDBContext _context;
        public ExperienceStorageServices(TravelExperienceDBContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ExperienceEntity entity)
        {
            var DBContext = _context;
            DBContext.Experiences.Add(entity);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var DBContext = _context;
            ExperienceEntity entity = await DBContext.Experiences.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                DBContext.Experiences.Remove(entity);
                await DBContext.SaveChangesAsync();
            }
        }

        public async Task<List<ExperienceEntity>> ReadAllAsync()
        {
            var DBContext = _context;
            return await DBContext.Experiences.ToListAsync();
        }

        public async Task<ExperienceEntity> ReadByIdAsync(Guid id)
        {
            var DBContext = _context;
            return await DBContext.Experiences.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<ExperienceEntity>> ReadBySearchAsync(Expression<Func<ExperienceEntity, bool>>filters)
        {
            var DBContext = _context;
            return await DBContext.Experiences
                .Where(filters) 
                .ToListAsync();
        }
        public async Task<ExperienceEntity> ReadWithInclude(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ExperienceEntity entity)
        {
            var DBContext = _context;
            ExperienceEntity existingEntity = await DBContext.Experiences.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existingEntity != null)
            {
                existingEntity.Title = entity.Title;
                existingEntity.Description = entity.Description;
                existingEntity.Information = entity.Information;
                existingEntity.Location = entity.Location;
                existingEntity.PricePerPerson = entity.PricePerPerson;
                existingEntity.MaxParticipants = entity.MaxParticipants;
                existingEntity.DurationInHours = entity.DurationInHours;
                existingEntity.ImagesUrls = entity.ImagesUrls;
            }
            await DBContext.SaveChangesAsync();
        }
    }
}
