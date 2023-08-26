using Microsoft.AspNetCore.Mvc;
using Controllers_IActionResult.Models;

namespace Controllers_IActionResult.Controllers
{
    public class HomeController : Controller
    {
        Person p = new Person
        {
            Number = 1001,
            Name = "Jose",
            Balance = 500
        };

        [Route ("/")]
        public IActionResult Index()
        {
            return Content("Welcome to my Bank");
        }

        [Route ("account-details")]

        public IActionResult Details()
        {
            return Json(p);
        }

        [Route("account-statment")]
        public IActionResult Statment()
        {
            return File("/José-Elias-Tarraf-neto.pdf",
                "application/pdf");
        }

        [Route("get-balance/{accountNumber:int?}")]
        public IActionResult Balance()
        {
            if (Request.RouteValues.ContainsKey("accountNumber"))
            {
                int accN = Convert.ToInt32(Request.RouteValues["accountNumber"]);

                if (accN > 1001)
                {
                    return BadRequest("Account Number Less than 1001");
                }

                if (accN != p.Number)
                {
                    return BadRequest("Account Number should be 1001");
                }

                return Content(p.Balance.ToString());
            }

            return NotFound("Account Number not Supplied");
        }
    }   
}
