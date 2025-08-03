using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleSubProducto_E
    {
        public int IdDetalleSubProducto { get; set; }
        public int IdSubProducto { get; set; }
        public int IdSuministro { get; set; }
        public decimal CantidadSuministro { get; set; }
        public string UnidadMedidaSP { get; set; }
        public decimal CostoSuministro { get; set; }
        public string NombreSuministros { get; set; }
        public string NombreSubProducto { get; set; }
    }
}
