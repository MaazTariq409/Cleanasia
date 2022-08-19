using System.ComponentModel.DataAnnotations;

namespace Cleanasia.Models
{
	public class CheckOutModel
	{
		[Key]
		public int Id { get; set; }
		public string Receipt { get; set; }
		public string picture { get; set; }
	}
}
