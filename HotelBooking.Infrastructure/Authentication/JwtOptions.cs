using HotelBooking.Application.Interfaces;
namespace HotelBooking.Infrastructure.Authentication
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } 
        public int ExpiersHours { get; set; }
    }
}
