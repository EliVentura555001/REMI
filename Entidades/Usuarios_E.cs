using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios_E
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int IdRol { get; set; }
        public string TelefonoUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public bool EstadoUsuario { get; set; }
    }
}
