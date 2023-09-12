using Microsoft.AspNetCore.Mvc;
using ModelValidation.Model;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        [Route ("register")]
        public IActionResult Index(Person p)
        {
            return Json(p);
        }
    }
}
