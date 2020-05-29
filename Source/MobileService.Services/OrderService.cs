namespace MobileService.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using MobileService.Data;
    using MobileService.Services.Models.Order;

    public class OrderService : IOrderService
    {
        private readonly MobileServiceDbContext dbContext;
        private readonly IMapper mapper;

        public OrderService(MobileServiceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<OrderServiceModel> GetOrderAsync(int orderId)
        {
            var order = await this.dbContext.Orders
                .ProjectTo<OrderServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.OrderId == orderId);

            return order;
        }

        public async Task<int> GetOrderIdAsync(string orderNumber, string password)
        {
            int ordeId = await this.dbContext.Orders
                .Where(x => x.OrderNumber == orderNumber && x.OrderPassword == password)
                .Select(x => x.OrderId)
                .FirstOrDefaultAsync();

            return ordeId;
        }
    }
}
