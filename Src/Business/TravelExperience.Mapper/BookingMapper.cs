using TravelExperience.Booking;
using TravelExperience.Common;
using TravelExperience.Entity.Entity;

namespace TravelExperience.Mapper
{
    public class BookingMapper : IMapperServices<BookingEntity, BookingDTO>
    {
        public BookingDTO ToDTO(BookingEntity entity)
        {
            BookingDTO dto = new BookingDTO()
            {
                Id = entity.Id,
                BookingDate = entity.BookingDate,
                NumberOfGuests = entity.NumberOfGuests,
                TotalPrice = entity.TotalPrice,
                Status = entity.Status,
                CreatedAt = entity.CreatedAt,
                ConfirmedAt = entity.ConfirmedAt,
                CancelledAt = entity.CancelledAt
            };
            return dto;
        }

        public BookingEntity ToEntity(BookingDTO dto)
        {
            BookingEntity entity = new BookingEntity()
            {
                Id = dto.Id,
                BookingDate = dto.BookingDate,
                NumberOfGuests = dto.NumberOfGuests,
                TotalPrice = dto.TotalPrice,
                Status = dto.Status,
                CreatedAt = dto.CreatedAt,
                ConfirmedAt = dto.ConfirmedAt,
                CancelledAt = dto.CancelledAt
            };
            return entity;
        }
    }
}
