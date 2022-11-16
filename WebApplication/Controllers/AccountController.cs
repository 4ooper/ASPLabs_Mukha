using Microsoft.AspNetCore.Mvc;
using BuildingContractor.Domain;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            var user = (User)HttpContext.Items["User"];
            return View(user);
        }
    }
}
