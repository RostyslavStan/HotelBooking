using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IHotelRepository
    {
        Task<Hotel> GetById(Guid id);
        Task<IEnumerable<Hotel>> GetByCity(string city);
        Task<IEnumerable<Hotel>> SearchByTitle(string title);
        Task Add(Hotel hotel);
        Task Update(Hotel hotel);
        Task Delete(Guid id);
    }
}
