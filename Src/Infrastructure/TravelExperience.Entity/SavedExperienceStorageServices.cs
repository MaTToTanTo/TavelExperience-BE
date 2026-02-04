using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.Common;
using TravelExperience.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using TravelExperience.DbContextClass;

namespace TravelExperience.Entity
{
    public class SavedExperienceStorageServices : IStorageServices<SavedExperienceEntity>
    {
        private readonly TravelExperienceDBContext _context;
        public SavedExperienceStorageServices(TravelExperienceDBContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(SavedExperienceEntity entity)
        {
                var DBContext = _context;
                DBContext.SavedExperiences.Add(entity);
                await DBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var DBContext = _context;
            SavedExperienceEntity entity = await DBContext.SavedExperiences.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                DBContext.SavedExperiences.Remove(entity);
                await DBContext.SaveChangesAsync();
            }
        }

        public async Task<List<SavedExperienceEntity>> ReadAllAsync()
        {
            var DBContext = _context;
            return await DBContext.SavedExperiences.ToListAsync();
        }

        public async Task<SavedExperienceEntity> ReadByIdAsync(Guid id)
        {
            var DBContext = _context;
            return await DBContext.SavedExperiences.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<SavedExperienceEntity>> ReadBySearchAsync(Expression<Func<SavedExperienceEntity, bool>> filters)
        {
            var DBContext = _context;
            return await DBContext.SavedExperiences
                .Where(filters)
                .ToListAsync();
        }

        public async Task<SavedExperienceEntity> ReadWithInclude(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateAsync(SavedExperienceEntity entity)
        {
            throw new NotImplementedException();

        }
    }
}
