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
    public class UserStorageServices : IStorageServices<UserEntity>
    {
        private readonly TravelExperienceDBContext _context;
        public UserStorageServices(TravelExperienceDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserEntity entity)
        {
            var DBContext = _context;
            DBContext.Users.Add(entity);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var DBContext = _context;
            UserEntity entity = await DBContext.Users.FirstOrDefaultAsync(e => e.Id == id); 
            if (entity != null)
            {
                DBContext.Users.Remove(entity);
                await DBContext.SaveChangesAsync();
            }
        }

        public async Task<List<UserEntity>> ReadAllAsync()
        {
            var DBContext = _context;
            return await DBContext.Users.ToListAsync();
        }

        public async Task<UserEntity> ReadByIdAsync(Guid id)
        {
            var DBContext = _context;
            return await DBContext.Users.FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task<List<UserEntity>> ReadBySearchAsync(Expression<Func<UserEntity, bool>> filters)
        {
            var DBContext = _context;
            return await DBContext.Users
                .Where(filters)
                .ToListAsync();
        }
        public async Task<UserEntity> ReadWithInclude(Guid id)
        {
            var DBContext = _context;
            UserEntity userEntity = await DBContext.Users
                .Include(x => x.HostProfile)
                .Include(x => x.TravelerProfile)
                .FirstOrDefaultAsync(u => u.Id == id);
            return userEntity;
        }


        public async Task UpdateAsync(UserEntity entity)
        {
            var DBContext = _context;
            UserEntity existingUser = await DBContext.Users.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existingUser != null)
            {
               existingUser.Username = entity.Username;
                existingUser.Email = entity.Email;
            }
                await DBContext.SaveChangesAsync();
        }
    }
}
