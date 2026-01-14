using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Contracts
{
    public record RegisterRequest(string name, string email, string passwordHash);
}
