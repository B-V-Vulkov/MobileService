namespace MobileService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MobileService.ViewModels.Login;

    public class loginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel viewModel)
        {
            return View();
        }
    }
}
