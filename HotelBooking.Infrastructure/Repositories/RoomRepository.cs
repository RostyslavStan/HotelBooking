using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;
        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Room room)
        {
            await _context.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await _context.Rooms.Where(x => x.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetAllByHotel(Guid hotelId)
        {
            var rooms = await _context.Rooms.Where(x => x.HotelId == hotelId).ToListAsync();
            return rooms;
        }

        public async Task<Room> GetById(Guid id)
        {
            var room = await _context.Rooms.FirstAsync(x => x.Id == id);
            return room;
        }

        public async Task Update(Room room)
        {
            await _context.Rooms.ExecuteUpdateAsync(x => x
            .SetProperty(x => x.PricePerHight, room.PricePerHight)
            .SetProperty(x => x.Capacity, room.Capacity));
            await _context.SaveChangesAsync();
        }
    }
}
