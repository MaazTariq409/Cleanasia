using Cleanasia.Models;
using System;
using System.Collections.Generic;

namespace Cleanasia.ViewModels
{
    public class ServiceListDetailViewModel
    {
        public int Id { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public String Price { get; set; }
        public String Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public DateTime StartingDateTime { get; set; }
        public int Hours { get; set; }

        public string Receipt { get; set; }
        public string picture { get; set; }

        public List<ServiceModel> Products { get; set; }

        public List<ServiceModel> services { get; set; }
    }
}
