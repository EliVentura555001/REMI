using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedidos_E
    {
        public int IdPedido { get; set; }
        public string DescripcionPedido { get; set; }
        public System.DateTime FechaPedido { get; set; }
        public Nullable<System.DateTime> FechaModPedido { get; set; }
        public string NombreProducto { get; set; }
        public List<DetalleProducto_E> DetallePedido { get; set; }
        public List<DetalleSubProducto_E> DetallePedidoSP { get; set; }
    }
}
