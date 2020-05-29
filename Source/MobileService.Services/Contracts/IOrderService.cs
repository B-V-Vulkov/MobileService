namespace MobileService.Services.Contracts
{
    using System.Threading.Tasks;

    using Models.Order;

    public interface IOrderService
    {
        Task<int> GetOrderIdAsync(string orderNumber, string password);

        Task<OrderServiceModel> GetOrderAsync(int orderId);
    }
}
