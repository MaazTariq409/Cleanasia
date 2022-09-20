using Cleanasia.Models;
using System.Collections.Generic;

namespace Cleanasia.ViewModels
{
    public class ServiceListDetailViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public List<ServiceModel> Products { get; set; }
    }
}
