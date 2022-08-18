using Cleanasia.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cleanasia.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public int Hours { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime StartingDateTime => DateTime.ParseExact($"(StartDate) (StartTime)", "mm:dd:yyyy hh:mm:tt", CultureInfo.GetCultureInfo("en-US"));
    }
}
