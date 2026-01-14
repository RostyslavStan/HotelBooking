using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        public AppDbContext _context { get; set; }
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            //await _context.Users.AddAsync(user);
        }
    }
}
