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

        [HttpGet]
        public async Task<IActionResult> Usuarios()
        {
            var usuarios = await dbContext.Usuarios.ToListAsync(); // Correct usage of ToListAsync
            return View(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Usuarios usuarioActualizado)
        {
            Console.WriteLine("➡️ Datos recibidos:");
            Console.WriteLine("ID: " + usuarioActualizado.ID_USUARIO);
            Console.WriteLine("Nombre: " + usuarioActualizado.NOMBRE_COMPLETO);
            Console.WriteLine("Fecha: " + usuarioActualizado.FECHA_DE_INGRESO);
            Console.WriteLine("Email: " + usuarioActualizado.EMAIL);
            Console.WriteLine("Teléfono: " + usuarioActualizado.TELEFONO);
            var usuarioExistente = await dbContext.Usuarios.FindAsync(usuarioActualizado.ID_USUARIO); // Use FindAsync for async operations
            if (usuarioExistente != null)
            {
                usuarioExistente.NOMBRE_COMPLETO = usuarioActualizado.NOMBRE_COMPLETO;
                usuarioExistente.FECHA_DE_INGRESO = usuarioActualizado.FECHA_DE_INGRESO;
                usuarioExistente.EMAIL = usuarioActualizado.EMAIL;
                usuarioExistente.TELEFONO = usuarioActualizado.TELEFONO;

                await dbContext.SaveChangesAsync();
                // Use SaveChangesAsync for async operations
            }

            var usuarios = await dbContext.Usuarios.ToListAsync(); // Correct usage of ToListAsync
            return RedirectToAction("Usuarios");
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Usuarios nuevoUsuario)
        {
            if (ModelState.IsValid)
            {
                dbContext.Usuarios.Add(nuevoUsuario);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Usuarios");
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var busqueda = await dbContext.Usuarios.FindAsync(Id); // Await the FindAsync method to get the actual entity

            if (busqueda != null)
            {
                dbContext.Usuarios.Remove(busqueda);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Usuarios"); // Ensure this return statement is outside the if block
        }
    }
}
