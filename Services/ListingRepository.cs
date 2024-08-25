using AutoMapper;
using GoHappy.API.Data;
using GoHappy.API.Dtos.ListingDtos;
using GoHappy.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GoHappy.API.Services
{
	public class ListingRepository : IListingRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public ListingRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
			_mapper = mapper;
        }

        public async Task<List<Listing>> GetAllListingsAsync()
		{
			return await _context.Listings.Include(l => l.Reviews).ToListAsync();
		}

		async Task<Listing?> IListingRepository.GetListingByIdAsync(int id)
		{
			return await _context.Listings.Include(l => l.Reviews).FirstOrDefaultAsync(l => l.Id == id);
		}

		async Task<Listing> IListingRepository.CreateListingAsync(Listing listing)
		{
			await _context.Listings.AddAsync(listing);
			await _context.SaveChangesAsync();
			return listing;
		}

		async Task<Listing?> IListingRepository.DeleteListingAsync(int id)
		{
			var listingModel = await _context.Listings.FirstOrDefaultAsync(x => x.Id == id);

			if (listingModel == null)
			{
				return null;
			}

			_context.Listings.Remove(listingModel);
			await _context.SaveChangesAsync();
			return listingModel;
		}

		async Task<Listing?> IListingRepository.UpdateListingAsync(int id, UpdateListingDto listingDto)
		{
			var existingListing = await _context.Listings.FirstOrDefaultAsync(x => x.Id == id);

			if (existingListing == null)
			{
				return null;
			}

			_mapper.Map(listingDto, existingListing);

			await _context.SaveChangesAsync();

			return existingListing;
		}

		public async Task<bool> ListingExists(int id)
		{
			return await _context.Listings.AnyAsync(l => l.Id == id);
		}
	}
}
