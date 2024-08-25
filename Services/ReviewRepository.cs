using System.Reflection;
using AutoMapper;
using GoHappy.API.Data;
using GoHappy.API.Dtos.ReviewDtos;
using GoHappy.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GoHappy.API.Services
{
	public class ReviewRepository : IReviewRepository
	{
        private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public ReviewRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
			_mapper = mapper;
        }

		public async Task<Review> CreateReviewAsync(Review review)
		{
			await _context.Reviews.AddAsync(review);
			await _context.SaveChangesAsync();
			return review;
		}

		public async Task<Review?> DeleteReviewAsync(int id)
		{
			var existingReview = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);	

			if(existingReview != null)
			{
				_context.Reviews.Remove(existingReview);
				await _context.SaveChangesAsync();
				return existingReview;

			} else
			{
				return null;
			}
		}

		public async Task<List<Review>> GetAllReviewsAsync()
		{
			return await _context.Reviews.ToListAsync();
		}

		public async Task<Review?> GetReviewByIdAsync(int id)
		{
			return await _context.Reviews.FindAsync(id);	
		}

		public async Task<Review?> UpdateReviewAsync(int id, UpdateReviewDto review)
		{
			var existingReview = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);

			if (existingReview == null)
			{
				return null;
			}
			_mapper.Map(review, existingReview);
			await _context.SaveChangesAsync();
			return existingReview;
		}
	}
}
