using GoHappy.API.Models;

namespace GoHappy.API.Dtos.ReviewDtos
{
	public class ReviewDto
	{
		public int Id { get; set; }

		public string ReviewContent { get; set; } = string.Empty;

		public DateTime CreatedOn { get; set; } = DateTime.Now;

		public int? ListingId { get; set; }
	}
}
