using System;

namespace Cleanasia.Models
{
    public class bookingServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public String  Phone { get; set; }
        public string Address { get; set; }
        public DateTime StartingDateTime { get; set; }
        public int Hours { get; set; }
        public string Receipt { get; set; }
        public string picture { get; set; }
    }
}
