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
    public class BookingStorageServices : IStorageServices<BookingEntity>
    {
        private readonly TravelExperienceDBContext _context;
        public BookingStorageServices(TravelExperienceDBContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(BookingEntity entity)
        {
            var DBContext = _context;
            DBContext.Bookings.Add(entity);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var DBContext = _context;
            BookingEntity entity = await DBContext.Bookings.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                DBContext.Bookings.Remove(entity);
                await DBContext.SaveChangesAsync();
            }
        }

        public async Task<List<BookingEntity>> ReadAllAsync()
        {
            var DBContext = _context;
            return await DBContext.Bookings.ToListAsync();
        }

        public async Task<BookingEntity> ReadByIdAsync(Guid id)
        {
            var DBContext = _context;
            return await DBContext.Bookings.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<BookingEntity>> ReadBySearchAsync(Expression<Func<BookingEntity, bool>> filters)
        {
            var DBContext = _context;
            return await DBContext.Bookings
                .Where(filters)
                .ToListAsync();


        }
        public async Task<BookingEntity> ReadWithInclude(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(BookingEntity entity)
        {
           var DBContext = _context;
            BookingEntity existingEntity = await DBContext.Bookings.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existingEntity != null) 
            {
                    existingEntity.BookingDate = entity.BookingDate;
                    existingEntity.NumberOfGuests = entity.NumberOfGuests;
                    existingEntity.TotalPrice = entity.TotalPrice;
                    existingEntity.Status = entity.Status;

                    if (entity.ConfirmedAt.HasValue)
                        existingEntity.ConfirmedAt = entity.ConfirmedAt;

                    if (entity.CancelledAt.HasValue)
                        existingEntity.CancelledAt = entity.CancelledAt;
            }
            await DBContext.SaveChangesAsync();

        }
    }


}
