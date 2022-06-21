using Microsoft.AspNetCore.Mvc;

namespace LAB.SuperHeroCRUD.Controllers
{
    public class SuperHeroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
