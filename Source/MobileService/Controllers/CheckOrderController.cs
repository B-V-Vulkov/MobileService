namespace MobileService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MobileService.Services.Contracts;
    using MobileService.ViewModels.CheckOrder;

    public class CheckOrderController : Controller
    {
        private readonly IOrderService orderService;

        public CheckOrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CheckOrderViewModel viewModel)
        {
            int orderId = await this.orderService
                .GetOrderIdAsync(viewModel.OrderNumber, viewModel.OrderPassword);

            if (orderId == 0)
            {
                this.ViewBag.ErrorMessage = "Invalid order number or password";
                return View(viewModel);
            }


            return RedirectToAction("Index", "Order", new { orderId = orderId});
        }
    }
}