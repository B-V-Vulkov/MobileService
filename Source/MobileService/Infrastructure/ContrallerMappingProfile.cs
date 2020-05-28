namespace MobileService.Infrastructure
{
    using AutoMapper;

    using ViewModels;
    using Services.Models;

    public class ContrallerMappingProfile : Profile
    {
        public ContrallerMappingProfile()
        {
            this.CreateMap<UserServiceModel, UserViewModel>();
        }
    }
}
