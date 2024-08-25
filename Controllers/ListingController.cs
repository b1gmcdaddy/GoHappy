using AutoMapper;
using GoHappy.API.Data;
using GoHappy.API.Dtos.ListingDtos;
using GoHappy.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoHappy.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ListingController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public ListingController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllListings()
		{
			var listings =  await _context.Listings.ToListAsync();
			var listingDtos = _mapper.Map<IEnumerable<ListingDto>>(listings);
			return Ok(listingDtos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetListingById([FromRoute] int id)
		{
			var listing = await _context.Listings.FindAsync(id);

			if (listing == null)
			{
				return NotFound();
			}

			var listingDto = _mapper.Map<ListingDto>(listing);
			return Ok(listingDto);
		}

		[HttpPost]
		public async Task<IActionResult> CreateListing([FromBody] CreateListingDto listingDto)
		{
			var listingModel = _mapper.Map<Listing>(listingDto);
			_context.Listings.Add(listingModel);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetListingById), new { id = listingModel.Id }, listingModel);
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateListing([FromRoute] int id, [FromBody] UpdateListingDto updateDto)
		{
			var listingModel = await _context.Listings.FindAsync(id);

			if (listingModel == null)
			{
				return NotFound();
			}

			_mapper.Map(updateDto, listingModel);

			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteListing([FromRoute] int id)
		{
			var listingModel = await _context.Listings.FindAsync(id);

			if (listingModel == null)
			{
				return NotFound();
			}

			_context.Listings.Remove(listingModel);
			await _context.SaveChangesAsync();
			return NoContent();	
		}
	}
}
