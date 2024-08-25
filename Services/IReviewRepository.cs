using GoHappy.API.Dtos.ReviewDtos;
using GoHappy.API.Models;

namespace GoHappy.API.Services
{
	public interface IReviewRepository
	{
		Task<List<Review>> GetAllReviewsAsync();
		Task<Review?> GetReviewByIdAsync(int id);
		Task<Review> CreateReviewAsync(Review review);
		Task<Review?> UpdateReviewAsync(int id, UpdateReviewDto review);
		Task<Review?> DeleteReviewAsync(int id);
	}
}
