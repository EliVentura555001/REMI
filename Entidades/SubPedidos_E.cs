using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class SubPedidos_E
    {
        public int IdSubPedido { get; set; }
        public int? IdOrden { get; set; }
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public System.DateTime FechaSubPedido { get; set; }
        public string EstadoSubPedido { get; set; }
    }
}
