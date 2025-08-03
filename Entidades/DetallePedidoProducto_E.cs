using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePedidoProducto_E
    {
       public int IdDetallePedidoProducto { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int IdSubProducto { get; set; }
        public decimal CostoParcial { get; set; }
        public int CantidadPorciones { get; set; }
        public string NombreProducto { get; set; }
        public string NombreSubProducto { get; set; }
        public string CostoSubProducto { get; set; }
    }
}
