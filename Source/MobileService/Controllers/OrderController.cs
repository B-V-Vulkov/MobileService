namespace MobileService.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using AutoMapper;

    using ViewModels.Order;
    using Services.Contracts;
    using Services.Models.Order;

    public class OrderController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOrderService orderService;
        private readonly IDeviceService deviceService;
        private readonly IRepairService repairService;
        private readonly IEmployeeService employeeService;

        public OrderController(
            IMapper mapper,
            IOrderService orderService,
            IDeviceService deviceService,
            IRepairService repairService,
            IEmployeeService employeeService)
        {
            this.mapper = mapper;
            this.orderService = orderService;
            this.deviceService = deviceService;
            this.repairService = repairService;
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult CheckOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckOrder(CheckOrderViewModel viewModel)
        {
            var order = this.mapper.Map<DataOrderViewModel>(await this.orderService
                .GetOrderAsync(viewModel.OrderNumber, viewModel.OrderPassword));

            if (order == null)
            {
                this.ViewBag.ErrorMessage = "Invalid order number or password";
                return View(viewModel);
            }

            return View(nameof(OrderData), order);
        }

        [HttpPost]
        public IActionResult OrderData(DataOrderViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpGet]
        [ApplicationAuthentication("Admin", "Receptionist")]
        public async Task<IActionResult> CreateOrder()
        {
            var viewModel = await InitializeCreateOrderViewModelAsync();

            return View(viewModel);
        }

        [HttpPost]
        [ApplicationAuthentication("Admin", "Receptionist")]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel viewModel) 
        {
            var currentReceptionistId = User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            var order = this.mapper.Map<InsertOrderServiceModel>(viewModel);
            order.ReceptionistId = int.Parse(currentReceptionistId);

            try
            {
                var createdOrderData = await this.orderService.InsertOrderAsync(order);

                var createdOrderViewModel = new CreatedOrderViewModel()
                {
                    OrderNumber = createdOrderData.OrderNumber,
                    OrderPassword = createdOrderData.OrderPassword,
                    OrderPrice = createdOrderData.OrderPrice
                };

                return View("CreatedOrder", createdOrderViewModel);
            }
            catch (Exception)
            {
                this.ViewBag.ErrorMessage = "An error occurred please try again later";
                viewModel = await InitializeCreateOrderViewModelAsync();
                
                return View(viewModel);
            }
        }
        
        [HttpGet]
        [ApplicationAuthentication("Admin", "ServiceWorker")]
        public async Task<IActionResult> RepairOrder()
        {
            var currentserviceWorkerId = User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            var serviceWorkerOrder = await this.orderService.GetServiceWorkerOrderAsync(int.Parse(currentserviceWorkerId));

            var viewModel = this.mapper.Map<RepairOrderViewModel>(serviceWorkerOrder);

            if (viewModel == null)
            {
                return View("ServiceWorkerEmptyOrders");
            }

            return View(viewModel);
        }

        [HttpPost]
        [ApplicationAuthentication("Admin", "ServiceWorker")]
        public async Task<IActionResult> RepairOrder(int OrderId, string repairDescription)
        {
            var currentserviceWorkerId = User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            var insertRepairOrder = new InsertRepairOrderServiceModel()
            {
                OrderId = OrderId,
                RepairDescription = repairDescription,
                ServiceWorkerId = int.Parse(currentserviceWorkerId)
            };

            await this.orderService.InsertRepairOrderAsync(insertRepairOrder);

            return RedirectToAction(nameof(RepairOrder));
        }

        private async Task<CreateOrderViewModel> InitializeCreateOrderViewModelAsync()
        {
            var deviceModels = await this.deviceService.GetAllDeviceModelsAsync();
            var repairTypes = await this.repairService.GetAllRepairTypesAsync();
            var serviceWorkers = await this.employeeService.GetAllServiceWorkers();

            var viewModel = new CreateOrderViewModel();

            foreach (var deviceModel in deviceModels)
            {
                viewModel.DeviceModels
                    .Add(new SelectListItem(deviceModel.DeviceModelName, deviceModel.DeviceModelId.ToString()));
            }

            foreach (var repairType in repairTypes)
            {
                viewModel.RepairTypes
                    .Add(new SelectListItem(repairType.RepairTypeName, repairType.RepairTypeId.ToString()));
            }

            foreach (var serviceWorker in serviceWorkers)
            {
                viewModel.ServiceWorkers
                    .Add(new SelectListItem(serviceWorker.ServiceWorkerName, serviceWorker.ServiceWorkerId.ToString()));
            }

            return viewModel;
        }
    }
}
