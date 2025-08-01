using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suministros_E
    {
        public int IdSuministro { get; set; }
        public string NombreSuministro { get; set; }
        public string DescripcionSuministro { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ExistenciasSuministro { get; set; }
        public string UnidadMedida { get; set; }
        public decimal CostoSuministro { get; set; }
        public decimal PresentacionSuministro { get; set; }
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; } // Agregado para mostrar el nombre del proveedor
        public bool EstadoSuministro { get; set; }
    }
}
