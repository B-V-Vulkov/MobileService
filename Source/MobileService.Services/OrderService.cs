namespace MobileService.Services
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Contracts;
    using Models.Order;
    using MobileService.Data.Models;
    using System;
    using System.Linq;

    using static CodeGenerator.OrderCodeGenerator;
    using Microsoft.EntityFrameworkCore.Internal;

    public class OrderService : IOrderService
    {
        private readonly MobileServiceDbContext dbContext;
        private readonly IMapper mapper;

        public OrderService(MobileServiceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<OrderServiceModel> GetOrderAsync(string orderNumber, string password)
        {
            var order = await this.dbContext.Orders
                .ProjectTo<OrderServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.OrderNumber == orderNumber && x.OrderPassword == password);

            return order;
        }

        public async Task<ServiceWorkerOrderServiceModel> GetServiceWorkerOrderAsync(int serviceWorkerId)
        {
            var serviceWorkerOrder = await this.dbContext.Orders
                .Where(x => x.ServiceWorkerId == serviceWorkerId && x .StatusId == 1)
                .ProjectTo<ServiceWorkerOrderServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return serviceWorkerOrder;
        }

        public async Task<CreatedOrderDataServiceModel> InsertOrderAsync(InsertOrderServiceModel insertOrder)
        {
            var orderNumber = GenerateOrderCode();
            var orderPassword = GenerateOrderCode();

            var customer = this.mapper.Map<Customer>(insertOrder);

            await this.dbContext.Orders
                .AddAsync(new Order()
                {
                    DeviceModelId = insertOrder.DeviceModelId,
                    RepairTypeId = insertOrder.RepairTypeId,                    
                    ReceptionistId = insertOrder.ReceptionistId,
                    ServiceWorkerId = insertOrder.ServiceWorkerId,
                    OrderNumber = orderNumber,
                    OrderPassword = orderPassword,
                    OrderedOn = DateTime.UtcNow,
                    Customer = customer,
                    StatusId = 1
                });

            await this.dbContext.SaveChangesAsync();

            var orderPrice = await this.dbContext.RepairPrices
                .Where(x => x.DeviceModelId == insertOrder.DeviceModelId && x.RepairTypeId == insertOrder.RepairTypeId)
                .Select(x => x.Price)
                .FirstOrDefaultAsync();

            return new CreatedOrderDataServiceModel()
            {
                OrderNumber = orderNumber,
                OrderPassword = orderPassword,
                OrderPrice = orderPrice
            };
        }

        public async Task InsertRepairOrderAsync(InsertRepairOrderServiceModel insertRepairOrder)
        {
            var order = await this.dbContext.Orders
                .FirstOrDefaultAsync(x => x.OrderId == insertRepairOrder.OrderId);

            order.RepairDescription = insertRepairOrder.RepairDescription;
            order.RepairedOn = DateTime.UtcNow;
            order.StatusId = 2;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
