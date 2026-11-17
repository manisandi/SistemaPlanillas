using Microsoft.AspNetCore.Mvc;

namespace SistemaPlanillas.Controllers
{
    public class ReportesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
