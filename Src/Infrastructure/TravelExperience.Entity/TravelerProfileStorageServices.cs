using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.Common;
using TravelExperience.DbContextClass;
using TravelExperience.Entity.Entity;

namespace TravelExperience.Entity
{
    public class TravelerProfileStorageServices : IStorageServices<TravelerProfileEntity>
    {
        private readonly TravelExperienceDBContext _context;
        public TravelerProfileStorageServices(TravelExperienceDBContext context)
        {
            _context = context;
        }
        
        public async Task CreateAsync(TravelerProfileEntity entity)
        {
            var DBContext = _context;
            DBContext.TravelerProfiles.Add(entity);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var DBContext = _context;
            TravelerProfileEntity entity = await DBContext.TravelerProfiles.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                DBContext.TravelerProfiles.Remove(entity);
                await DBContext.SaveChangesAsync();
            }
        }

        public async Task<List<TravelerProfileEntity>> ReadAllAsync()
        {
            var DBContext = _context;
            return await DBContext.TravelerProfiles.ToListAsync();
        }

        public async Task<TravelerProfileEntity> ReadByIdAsync(Guid id)
        {
            var DBContext = _context;
            return await DBContext.TravelerProfiles.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<TravelerProfileEntity>> ReadBySearchAsync(Expression<Func<TravelerProfileEntity, bool>> filters)
        {
            var DBContext = _context;
            return await DBContext.TravelerProfiles
                .Where(filters)
                .ToListAsync();
        }

        public async Task<TravelerProfileEntity> ReadWithInclude(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TravelerProfileEntity entity)
        {
            var DBContext = _context;
            TravelerProfileEntity existingProfile = await DBContext.TravelerProfiles.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existingProfile != null)
            {
                existingProfile.FirstName = entity.FirstName;
                existingProfile.LastName = entity.LastName;
                existingProfile.Country = entity.Country;
                existingProfile.City = entity.City;
                existingProfile.DateOfBirth = entity.DateOfBirth;
                existingProfile.AvatarUrl = entity.AvatarUrl;
                existingProfile.Bio = entity.Bio;
                
            }
            await DBContext.SaveChangesAsync();

        }
    }
}
