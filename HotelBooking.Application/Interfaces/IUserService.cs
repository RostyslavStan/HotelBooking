using HotelBooking.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(RegisterRequest request);
        Task<string> LoginUser(LoginRequest request);
    }
}
