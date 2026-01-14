using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetById(Guid id);
        Task<IEnumerable<Room>> GetAllByHotel(Guid hotelId);
        Task Add(Room room);
        Task Update(Room room);
        Task Delete(Guid id);
    }
}
