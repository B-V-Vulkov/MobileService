namespace MobileService.Services.Contracts
{
    using System.Threading.Tasks;

    using Models.Home;

    public interface IOrderService
    {
        bool CheckOrder(int orderId, string password);
    }
}
