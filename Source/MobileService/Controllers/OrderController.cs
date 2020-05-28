namespace MobileService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MobileService.Services.Contracts;
    using MobileService.ViewModels.Order;

    public class OrderController : Controller
    {
        // var result = this.mapper.Map<UserViewModel>(await this.userService.GetUser());

        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOrder(OrderViewModel viewModel)
        {
            bool isExists = this.orderService.CheckOrder(viewModel.OrderId, viewModel.Password);

            if (!isExists)
            {
                return View(viewModel);
            }

            return View("");
        }
    }
}