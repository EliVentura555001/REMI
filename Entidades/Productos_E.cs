using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos_E
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal CostoProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public int IdCategoria { get; set; }
        public List<DetalleProducto_E> DetalleProducto { get; set; }
        public string NombreCategoria { get; set; }
        public bool EstadoProducto { get; set; }
    }
}
