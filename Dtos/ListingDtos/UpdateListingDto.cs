﻿namespace GoHappy.API.Dtos.ListingDtos
{
	public class UpdateListingDto
	{
		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public decimal Price { get; set; }
	}
}
