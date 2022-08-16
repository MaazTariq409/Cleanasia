using Cleanasia.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCuisine.ViewModels
{
    public class ProductViewModel
    {
        public List<CategoryModel> categories { get; set; }
        public List<ServiceModel> services { get; set; }
    }
}
