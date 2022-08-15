using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cleanasia.Models
{
    public class ServiceModel
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ProductCategory")]
        public int ProductCategoryID { get; set; }
        public virtual CategoryModel ProductCategory { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int PhoneNumber { get; set; }
        public string picture { get; set; }
    }
}
