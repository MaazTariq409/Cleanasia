using Cleanasia.Models;
using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cleanasia.ViewModels
{
    public class ServicesViewModel
    {
        public List<ServiceModel> services { get; set; }
        public List<CategoryModel> categories { get; set; }
    }
}
