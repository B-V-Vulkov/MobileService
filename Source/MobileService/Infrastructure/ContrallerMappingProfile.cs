﻿namespace MobileService.Infrastructure
{
    using AutoMapper;

    using ViewModels.Order;
    using Services.Models.Order;

    public class ContrallerMappingProfile : Profile
    {
        public ContrallerMappingProfile()
        {
            this.CreateMap<OrderServiceModel, DataOrderViewModel>();

            this.CreateMap<ServiceWorkerOrderServiceModel, RepairOrderViewModel>();

            this.CreateMap<CreateOrderViewModel, InsertOrderServiceModel>();
        }
    }
}
