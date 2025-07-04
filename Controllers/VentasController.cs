using Microsoft.AspNetCore.Mvc;

namespace  Proyecto_1_Basico_1.Controllers

{
    public class VentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
