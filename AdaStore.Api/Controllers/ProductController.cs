using Microsoft.AspNetCore.Mvc;

namespace AdaStore.Api.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
