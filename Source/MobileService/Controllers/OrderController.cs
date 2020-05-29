namespace MobileService.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MobileService.Services.Contracts;
    using MobileService.ViewModels.Order;
    using System.Threading.Tasks;

    public class OrderController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOrderService orderService;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            this.mapper = mapper;
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int orderId)
        {
            var order = await this.orderService.GetOrderAsync(orderId);

            var viewModel = this.mapper.Map<OrderViewModel>(order);



            //var model = new OrderViewModel() 
            //{
            //    OrderNumber = "122DDDDS12",
            //    CustomerName = "Pesho Peshov Peshov",
            //    CustomerEmail = "pedssds@dsdsdsd.com",
            //    CustomerPhoneNumber = "232 2323 2323",
            //    Device = "Iphone 6",
            //    Repair = "Broken display",
            //    Status = "Repaired",
            //    RepairDescription = ""
            //};

            return View(viewModel);
        }
    }
}
