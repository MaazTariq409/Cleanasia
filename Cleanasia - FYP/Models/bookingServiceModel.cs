using System;

namespace Cleanasia.Models
{
    public class bookingServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int  Phone { get; set; }
        public string Address { get; set; }
        public DateTime StartingDateTime { get; set; }
        public int Hours { get; set; }
        public string StartDate => StartingDateTime.ToString("MM/dd/yyyy");
        public string StartTime => StartingDateTime.ToString("hh:mm:tt");
    }
}
