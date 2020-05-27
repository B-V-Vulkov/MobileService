using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileService.Models;
using MobileService.Services.Contracts;

namespace MobileService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            // var result = this.mapper.Map<UserViewModel>(await this.userService.GetUser());

            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
