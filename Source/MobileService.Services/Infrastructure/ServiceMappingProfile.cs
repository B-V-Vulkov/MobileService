namespace MobileService.Services.Infrastructure
{
    using AutoMapper;

    using Data.Models;
    using Models.Order;

    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<Order, OrderServiceModel>()
                .ForMember(x => x.CustomerName, opt => opt.MapFrom(x => x.Customer.FirstName + ' ' + x.Customer.MiddleName + ' ' + x.Customer.LastName))
                .ForMember(x => x.CustomerEmail, opt => opt.MapFrom(x => x.Customer.Email))
                .ForMember(x => x.CustomerPhoneNumber, opt => opt.MapFrom(x => x.Customer.PhoneNumber))
                .ForMember(x => x.Device, opt => opt.MapFrom(x => x.DeviceModel.DeviceModelName))
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status.OrderStatusName))
                .ForMember(x => x.Repair, opt => opt.MapFrom(x => x.RepairType.RepairTypeName));
        }
    }
}
