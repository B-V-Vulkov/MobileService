namespace MobileService.Services
{
    using System.Threading.Tasks;

    using Contracts;
    using Models.Home;

    public class OrderService : IOrderService
    {
        public bool CheckOrder(int orderId, string password)
        {
            if (orderId == 1 & password == "1234")
            {
                return true;
            }

            return false;
        }

        public OrderServiceModel GetOrderAsync(int orderId, string password)
        {
            OrderServiceModel order = new OrderServiceModel();

            if (orderId == 1 & password == "1234")
            {
                order.UserName = "Test Testov Testov";
            }

            return order;
        }
    }
}
