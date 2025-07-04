using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_1_Basico_1;
using Proyecto_1_Basico_1.Models;
using System.Threading.Tasks;

namespace Proyecto_1_Basico_1.Controllers

{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public UsuariosController(ApplicationDbContext db) 
        {
            dbContext = db;
        }

        //public IActionResult Usuarios()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Usuarios()
        {
            var usuarios = await dbContext.Usuarios.ToListAsync();
            return View(usuarios);
        }
    }
}
