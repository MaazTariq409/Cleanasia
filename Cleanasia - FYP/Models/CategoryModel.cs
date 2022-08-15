using System.ComponentModel.DataAnnotations;

namespace Cleanasia.Models
{
    public class CategoryModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string picture { get; set; }
    }
}
