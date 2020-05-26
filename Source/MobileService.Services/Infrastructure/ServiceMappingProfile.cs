namespace MobileService.Services.Infrastructure
{
    using AutoMapper;

    using Data.Models;
    using MobileService.Services.Models;

    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<User, UserServiceModel>();
        }
    }
}
