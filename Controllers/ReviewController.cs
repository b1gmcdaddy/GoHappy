using AutoMapper;
using GoHappy.API.Dtos.ListingDtos;
using GoHappy.API.Dtos.ReviewDtos;
using GoHappy.API.Models;
using GoHappy.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoHappy.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
        private readonly IReviewRepository _reviewRepo;
		private readonly IMapper _mapper;
		private readonly IListingRepository _listingRepo;

		public ReviewController(IReviewRepository reviewRepo, IMapper mapper, IListingRepository listingRepo)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
			_listingRepo = listingRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
			var reviews = await _reviewRepo.GetAllReviewsAsync();
            var reviewDtos = _mapper.Map<IEnumerable<ReviewDto>>(reviews);
            return Ok(reviewDtos);
		}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById([FromRoute] int id)
        {
			var review = await _reviewRepo.GetReviewByIdAsync(id);	

			if (review == null)
			{
				return NotFound();
			}

			var reviewDto = _mapper.Map<ReviewDto>(review);
			return Ok(reviewDto);
		}

		[HttpPost("{listingId}")]
		public async Task<IActionResult> CreateReview([FromRoute] int listingId, [FromBody] CreateReviewDto reviewDto)
		{
			if(!await _listingRepo.ListingExists(listingId))
			{
				return BadRequest("no such listin existsts..");
			}

			var reviewModel = _mapper.Map<Review>(reviewDto);
			reviewModel.ListingId = listingId; 
			await _reviewRepo.CreateReviewAsync(reviewModel);
;			return CreatedAtAction(nameof(GetReviewById), new { id = reviewModel.Id }, reviewModel);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateReview([FromRoute] int id, [FromBody] UpdateReviewDto updateDto)
		{
			var review = await _reviewRepo.UpdateReviewAsync(id, updateDto);
			if (review == null)
			{
				return NotFound();
			}
			return Ok(review);

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteReview([FromRoute] int id)
		{
			var reviewModel = await _reviewRepo.DeleteReviewAsync(id);
			return NoContent();
		}
    }
}
