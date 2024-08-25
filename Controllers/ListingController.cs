using AutoMapper;
using GoHappy.API.Data;
using GoHappy.API.Dtos.ListingDtos;
using GoHappy.API.Models;
using GoHappy.API.Services;
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
		private readonly IListingRepository _listingRepo;
		private readonly IMapper _mapper;

		public ListingController(ApplicationDbContext context, IMapper mapper, IListingRepository listingRepo)
		{
			_listingRepo = listingRepo;
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllListings()
		{
			var listings = await _listingRepo.GetAllListingsAsync();
			var listingDtos = _mapper.Map<IEnumerable<ListingDto>>(listings);
			return Ok(listingDtos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetListingById([FromRoute] int id)
		{
			var listing = await _listingRepo.GetListingByIdAsync(id);	

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
			await _listingRepo.CreateListingAsync(listingModel);
			return CreatedAtAction(nameof(GetListingById), new { id = listingModel.Id }, listingModel);
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateListing([FromRoute] int id, [FromBody] UpdateListingDto updateDto)
		{
			var listingModel = await _listingRepo.UpdateListingAsync(id, updateDto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteListing([FromRoute] int id)
		{
			var listingModel = await _listingRepo.DeleteListingAsync(id);
			return NoContent();	
		}
	}
}
