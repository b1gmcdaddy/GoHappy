namespace GoHappy.API.Models
{
	public class Review
	{
		public int Id { get; set; }

		public string ReviewContent { get; set; } = string.Empty;

		public DateTime CreatedOn { get; set; } = DateTime.Now;

		public int? ListingId { get; set; }	

		public Listing? Listing { get; set; }
	}
}
