using System.Globalization;
using API.Dtos;
using AutoMapper;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(src.FirstName.ToLower() + " " + src.LastName.ToLower())))
                .ReverseMap();
        }
    }
}