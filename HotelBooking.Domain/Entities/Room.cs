using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; }
        public decimal PricePerHight { get; set; }
        public int Capacity { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
    }
}
