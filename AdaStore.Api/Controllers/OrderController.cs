using Microsoft.AspNetCore.Mvc;

namespace AdaStore.Api.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
