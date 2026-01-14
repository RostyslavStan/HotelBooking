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
    public class HotelRepository : IHotelRepository
    {
        private AppDbContext _context { get; set; }
        private readonly string _connectionString;
        public HotelRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<Hotel> GetById(Guid id)
        {
            var hotel = await _context.Hotels.FirstAsync(x => x.Id == id);
            return hotel;
        }

        public async Task<IEnumerable<Hotel>> GetByCity(string city)
        {
            var hotels = await _context.Hotels.Where(x => x.City == city).ToListAsync();
            return hotels;  
        }

        public async Task Add(Hotel hotel)
        {
            await _context.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Hotel hotel)
        {
            await _context.Hotels
                .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, hotel.Name)
                .SetProperty(x => x.Description, hotel.Description)
                .SetProperty(x => x.City, hotel.City)
                .SetProperty(x => x.Address, hotel.Address));
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await _context.Hotels.Where(x => x.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> SearchByTitle(string searchString)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = @"
                SELECT * FROM Hotels
                WHERE LOWER(Name) 
                LIKE CONCAT('%', LOWER(@searchString), '%')";
            var hotels = await connection.QueryAsync<Hotel>(sql, new { searchString });
            return hotels;
        }
    }
}
