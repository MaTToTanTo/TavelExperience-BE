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
    public class HostProfileStorageServices : IStorageServices<HostProfileEntity>
    {
        private readonly TravelExperienceDBContext _context;
        public HostProfileStorageServices(TravelExperienceDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(HostProfileEntity entity)
        {
            var DBContext = _context;
            DBContext.HostProfiles.Add(entity);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var DBContext = _context;
            HostProfileEntity entity = await DBContext.HostProfiles.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                DBContext.HostProfiles.Remove(entity);
                await DBContext.SaveChangesAsync();
            }
        }

        public async Task<List<HostProfileEntity>> ReadAllAsync()
        {
           var DBContext = _context;
            return await DBContext.HostProfiles.ToListAsync();
        }

        public async Task<HostProfileEntity> ReadByIdAsync(Guid id)
        {
            var DBContext = _context;
            return await DBContext.HostProfiles.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<HostProfileEntity>> ReadBySearchAsync(Expression<Func<HostProfileEntity, bool>> filters)
        {
            var DBContext = _context;
            return await DBContext.HostProfiles
                .Where(filters)
                .ToListAsync();
        }
        public async Task<HostProfileEntity> ReadWithInclude(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(HostProfileEntity entity)
        {
            var DBContext = _context;
            HostProfileEntity existingHost = await DBContext.HostProfiles.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existingHost != null)
            {
                existingHost.DisplayName = entity.DisplayName;
                existingHost.BusinessName = entity.BusinessName;
                existingHost.Country = entity.Country;
                existingHost.City = entity.City;
                existingHost.AvatarUrl = entity.AvatarUrl;
                existingHost.WebsiteUrl = entity.WebsiteUrl;
                existingHost.Bio = entity.Bio;
                existingHost.IsVerified = entity.IsVerified;
            }
                await DBContext.SaveChangesAsync();
        }
    }
}
