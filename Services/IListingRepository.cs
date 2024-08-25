using GoHappy.API.Dtos.ListingDtos;
using GoHappy.API.Models;

namespace GoHappy.API.Services
{
	public interface IListingRepository
	{
		Task<List<Listing>> GetAllListingsAsync();
		Task<Listing?> GetListingByIdAsync(int id);
		Task<Listing> CreateListingAsync(Listing listing);
		Task<Listing?> UpdateListingAsync(int id, UpdateListingDto listingDto);
		Task<Listing?> DeleteListingAsync(int id);
		Task<bool> ListingExists(int id);
	}
}
