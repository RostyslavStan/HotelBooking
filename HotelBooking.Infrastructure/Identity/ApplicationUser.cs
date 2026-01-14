using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelBooking.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? Initials { get; set; }
    }
}
