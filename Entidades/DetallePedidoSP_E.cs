using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePedidoSP_E
    {
        public int IdDetallePedidoSP { get; set; }
        public int IdPedido { get; set; }
        public int IdSubProducto { get; set; }
        public int IdSuministro { get; set; }
        public decimal CantidadSuministroPSP { get; set; }
        public string UnidadMedidaPSP { get; set; }
        public decimal CostoParcialPSP { get; set; }
        public string NombreSubProducto { get; set; }
        public string NombreSuministro { get; set; }
    }
}
