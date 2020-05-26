namespace MobileService.Infrastructure
{
    using AutoMapper;
    using MobileService.Models;
    using MobileService.Services.Models;

    public class ContrallerMappingProfile : Profile
    {
        public ContrallerMappingProfile()
        {
            this.CreateMap<UserServiceModel, UserViewModel>();
        }
    }
}
