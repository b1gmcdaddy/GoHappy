using AutoMapper;
using GoHappy.API.Dtos.ListingDtos;
using GoHappy.API.Models;

namespace GoHappy.API.Mappers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Listing, ListingDto>().ReverseMap();
			CreateMap<CreateListingDto, Listing>();
			CreateMap<UpdateListingDto, Listing>();
		}
	}
}
