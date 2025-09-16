using Microsoft.AspNetCore.Mvc;

namespace TP02.Controllers
{
    public class CreditosController : Controller
    {
        // GET: CreditosC
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
