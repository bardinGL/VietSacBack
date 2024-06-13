using Microsoft.AspNetCore.Mvc;

namespace VietSacBackend._1.Web
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
