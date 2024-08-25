namespace GoHappy.API.Dtos.ListingDtos
{
	public class CreateListingDto
	{
		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public decimal Price { get; set; }
	}
}
