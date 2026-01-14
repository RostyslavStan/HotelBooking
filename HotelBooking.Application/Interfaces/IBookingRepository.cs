using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetById(Guid id);
        Task<IEnumerable<Booking>> GetByUser(Guid userId);
        Task Add(Booking booking);
        Task Delete(Guid id);
    }
}
