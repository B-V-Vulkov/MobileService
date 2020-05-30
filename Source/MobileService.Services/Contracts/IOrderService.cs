namespace MobileService.Services.Contracts
{
    using System.Threading.Tasks;

    using Models.Order;

    public interface IOrderService
    {
        Task<OrderServiceModel> GetOrderAsync(string orderNumber, string password);

        Task<ServiceWorkerOrderServiceModel> GetServiceWorkerOrderAsync(int serviceWorkerId);

        Task<CreatedOrderDataServiceModel> InsertOrderAsync(InsertOrderServiceModel insertOrder);

        Task InsertRepairOrderAsync(InsertRepairOrderServiceModel insertRepairOrder);
    }
}
