using Microsoft.EntityFrameworkCore;
using Proyecto_1_Basico_1.Models;
using System.Security.Cryptography.X509Certificates;

namespace Proyecto_1_Basico_1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
