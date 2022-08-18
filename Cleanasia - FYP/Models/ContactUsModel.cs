using System.ComponentModel.DataAnnotations;

namespace Cleanasia.Models
{
	public class ContactUsModel
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Message { get; set; }
	}
}
