using Microsoft.AspNetCore.Mvc;

namespace AdaStore.Api.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
