using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleOrden_E
    {
        public int IdPedido { get; set; }
        public int IdOrden { get; set; }
        public int IdSubProducto { get; set; }
        public int IdProducto { get; set; }
        public int CantidadPorciones { get; set; }
        public decimal PrecioOrden { get; set; }
        public string NombreSubProducto { get; set; }
        public string NombreProducto { get; set; }
    }
}
