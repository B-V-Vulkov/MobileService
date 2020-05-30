namespace MobileService.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using MobileService.Services.Contracts;
    using MobileService.ViewModels.Login;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class loginController : Controller
    {
        private readonly IEmployeeService employeeService;

        public loginController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            try
            {
                var employee = await this.employeeService
                    .GetEmployeeAsync(viewModel.Email, viewModel.Password);

                await this.SetAuthenticationCookieAsync(employee.EmployeeId, employee.Role);

                // redirect
                return View();
            }
            catch (Exception)
            {
                this.ViewBag.ErrorMessage = "Invalid email or password";
                return View(viewModel);
            }
        }

        private async Task SetAuthenticationCookieAsync(int employeeId, string Role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employeeId.ToString()),
                new Claim(ClaimTypes.Role, Role)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        //private async void ResetAuthenticationCookieAsync()
        //{

        //}
    }
}
