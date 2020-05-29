namespace MobileService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MobileService.Security;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
