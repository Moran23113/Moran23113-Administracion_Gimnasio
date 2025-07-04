using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_1_Basico_1.Models
{
    public class Usuarios
    {
        [Key]
        public int ID_USUARIO { get; set; }
        public required string NOMBRE_COMPLETO { get; set; }
        public required string FECHA_DE_INGRESO { get; set; }
        public required string EMAIL { get; set; }
        public required string TELEFONO { get; set; }
    }
}
