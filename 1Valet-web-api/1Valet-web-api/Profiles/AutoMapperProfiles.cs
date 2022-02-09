using _1Valet_web_api.Models;
using _1Valet_web_api.DomainModels;
using AutoMapper;

namespace _1Valet_web_api.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Models.Device, DomainModels.Device>()
                .ReverseMap();

            CreateMap<Models.Type, DomainModels.Type>()
                 .ReverseMap();

        }
    }
}
