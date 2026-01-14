using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Contracts
{
    public record LoginRequest(string email, string passwordHash);
}
