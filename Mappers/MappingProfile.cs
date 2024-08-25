using AutoMapper;
using GoHappy.API.Dtos.ListingDtos;
using GoHappy.API.Dtos.ReviewDtos;
using GoHappy.API.Models;

namespace GoHappy.API.Mappers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// mapping for listingssssss
			CreateMap<Listing, ListingDto>().ForMember(dto => dto.Reviews, opt => opt.MapFrom(src => src.Reviews));
			CreateMap<CreateListingDto, Listing>();
			CreateMap<UpdateListingDto, Listing>();

			// mapping for reviews..
			CreateMap<Review, ReviewDto>().ReverseMap();
			CreateMap<CreateReviewDto, Review>();
			CreateMap<UpdateReviewDto, Review>();
		}
	}

}
