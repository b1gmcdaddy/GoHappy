using System.ComponentModel.DataAnnotations.Schema;

namespace GoHappy.API.Models
{
	public class Listing
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		public List<Review> Review { get; set; } = new List<Review>();
	}
}
