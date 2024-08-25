using GoHappy.API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoHappy.API.Dtos.ListingDtos
{
	public class ListingDto
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public decimal Price { get; set; }

	}
}
