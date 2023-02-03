using AutoMapper;
using UserApi.Model.Domain;
using UserApi.Model.Dto;

namespace UserApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDetails, UserDetailsDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
        }

    }
}
