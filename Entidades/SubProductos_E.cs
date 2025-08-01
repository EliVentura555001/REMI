using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SubProductos_E
    {
        public int IdSubProducto { get; set; }
        public string NombreSubProducto { get; set; }
        public string DescripcionSubProducto { get; set; }
        public decimal PrecioSubProducto { get; set; }
        public decimal CostoSubProducto { get; set; }
        public string Instrucciones { get; set; }
        public List<DetalleSubProducto_E> DetalleSubProducto { get; set; }
        public bool EstadoSubProducto { get; set; }
    }
}
