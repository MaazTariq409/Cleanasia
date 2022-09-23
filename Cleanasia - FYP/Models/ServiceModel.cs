using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cleanasia.Models
{
    public class ServiceModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ServiceCategory")]
        public int ProductCategoryID { get; set; }
        public virtual CategoryModel ServiceCategory { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        [Display(Name = "Price")]
        public string price { get; set; }
        public string picture { get; set; }
    }
}
