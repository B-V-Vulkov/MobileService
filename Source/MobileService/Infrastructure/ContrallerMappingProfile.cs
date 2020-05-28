namespace MobileService.Infrastructure
{
    using AutoMapper;
    using MobileService.Services.Models;
    using MobileService.ViewModels;

    public class ContrallerMappingProfile : Profile
    {
        public ContrallerMappingProfile()
        {
            this.CreateMap<UserServiceModel, UserViewModel>();
        }
    }
}
