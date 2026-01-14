using Dapper;
using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;
        public BookingRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task Add(Booking booking)
        {
            await _context.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await _context.Bookings.Where(x => x.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<Booking> GetById(Guid id)
        {
            var booking = await _context.Bookings.FirstAsync(x => x.Id == id);
            return booking;
        }

        public async Task<IEnumerable<Booking>> GetByUser(Guid userId)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = @"
                SELECT * FROM Bookings
                WHERE UserId=@userId";
            var bookings = await connection.QueryAsync<Booking>(sql, new { userId });
            return bookings;
        }
    }
}
