using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ordenes_E
    {
        public int IdOrden { get; set; }
        public string DescripcionOrden { get; set; }
        public System.DateTime FechaCreacionOrden { get; set; }
        public Nullable<System.DateTime> FechaModOrden { get; set; }
        public string NombreProducto { get; set; }
        public List<DetalleProducto_E> DetalleProducto { get; set; }
        public List<DetalleOrden_E> DetalleOrden{ get; set; }

    }
}
