namespace MobileService.Services.Infrastructure
{
    using AutoMapper;

    using Data.Models;
    using Models.Order;
    using Models.Device;
    using Models.Employee;
    using Models.Repair;

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

            this.CreateMap<Order, ServiceWorkerOrderServiceModel>()
                .ForMember(x => x.OrderId, opt => opt.MapFrom(x => x.OrderId))
                .ForMember(x => x.CustomerName, opt => opt.MapFrom(x => x.Customer.FirstName + ' ' + x.Customer.MiddleName + ' ' + x.Customer.LastName))
                .ForMember(x => x.CustomerEmail, opt => opt.MapFrom(x => x.Customer.Email))
                .ForMember(x => x.Device, opt => opt.MapFrom(x => x.DeviceModel.DeviceModelName))
                .ForMember(x => x.Repair, opt => opt.MapFrom(x => x.RepairType.RepairTypeName));

            this.CreateMap<Employee, ServiceWorkerServiceModel>()
                .ForMember(x => x.ServiceWorkerId, opt => opt.MapFrom(x => x.EmployeeId))
                .ForMember(x => x.ServiceWorkerName, opt => opt.MapFrom(x => x.FirstName + ' ' + x.LastName));

            this.CreateMap<Employee, EmployeeServiceModel>()
                .ForMember(x => x.Role, opt => opt.MapFrom(x => x.EmployeePosition.EmployeePositionName));

            this.CreateMap<DeviceModel, DeviceModelServiceModel>();

            this.CreateMap<RepairType, RepairTypeServiceModel>();

            this.CreateMap<InsertOrderServiceModel, Customer>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.CustomerFirstName))
                .ForMember(x => x.MiddleName, opt => opt.MapFrom(x => x.CustomerMiddleName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.CustomerLastName))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.CustomerEmail))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.CustomerPhoneNumber));
        }
    }
}
