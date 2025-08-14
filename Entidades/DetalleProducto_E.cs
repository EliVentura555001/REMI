using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleProducto_E
    {
        public int IdSubProducto { get; set; }
        public int IdProducto { get; set; }
        public string NombreSubProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadPorcionesP { get; set; }
        public decimal CostoSubProducto { get; set; }
        public decimal PrecioSubProducto { get; set; }
        public List<DetallePedidoP_E> DetallePedidoProducto { get; set; }
    }
}
