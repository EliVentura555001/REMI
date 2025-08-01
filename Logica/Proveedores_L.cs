using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Proveedores_L
    {
        public bool Actualizar(Proveedores_E actualizarProveedor, ref string mensajeError)
        {
            using (remiEntities db = new remiEntities())
            {
                try
                {
                    Proveedores proveedoresdb = db.Proveedores.Find(actualizarProveedor.IdProveedor);
                    proveedoresdb.NombreProveedor = actualizarProveedor.NombreProveedor;
                    proveedoresdb.TelefonoProveedor = actualizarProveedor.TelefonoProveedor;
                    proveedoresdb.CorreoProveedor = actualizarProveedor.CorreoProveedor;
                    proveedoresdb.DireccionProveedor = actualizarProveedor.DireccionProveedor;
                    proveedoresdb.EstadoProveedor = actualizarProveedor.EstadoProveedor;
                    db.SaveChanges();
                    mensajeError = string.Empty;
                    return true;
                }
                catch (Exception ex)
                {
                    mensajeError = ex.Message;
                    return false;
                }
            }
        }
        public bool Guardar(Proveedores_E datosNuevoProveedor, ref string mensajeError)
        {   
            using (var db = new remiEntities())
            {
                try
                {

                    Proveedores NuevoProveedor = new Proveedores()
                    {
                        NombreProveedor = datosNuevoProveedor.NombreProveedor,
                        TelefonoProveedor = datosNuevoProveedor.TelefonoProveedor,
                        CorreoProveedor = datosNuevoProveedor.CorreoProveedor,
                        DireccionProveedor = datosNuevoProveedor.DireccionProveedor,
                        EstadoProveedor = datosNuevoProveedor.EstadoProveedor
                    };
                    db.Proveedores.Add(NuevoProveedor);
                    db.SaveChanges();
                    mensajeError = string.Empty;
                    return true;
                }
                catch (Exception ex)
                {
                    mensajeError = ex.Message;
                    return false;
                }
            }
        }
        public List<Proveedores_E> ListarProveedoresActivos()
        {
            using (var db = new remiEntities())
            {
                List<Proveedores_E> Proveedores = new List<Proveedores_E>();
                Proveedores = db.Proveedores.Where(w => w.EstadoProveedor == true).Select(s => new Proveedores_E
                {
                    IdProveedor = s.IdProveedor,
                    NombreProveedor = s.NombreProveedor,
                    TelefonoProveedor = s.TelefonoProveedor,
                    CorreoProveedor = s.CorreoProveedor,
                    DireccionProveedor = s.DireccionProveedor,
                }).ToList();
                return Proveedores;
            }
        }
        public List<Proveedores_E> ListarProveedores()
        {
            using (var db = new remiEntities())
            {
                List<Proveedores_E> Proveedores = new List<Proveedores_E>();
                Proveedores = db.Proveedores.Select(s => new Proveedores_E
                {
                    IdProveedor = s.IdProveedor,
                    NombreProveedor = s.NombreProveedor,
                    TelefonoProveedor = s.TelefonoProveedor,
                    CorreoProveedor = s.CorreoProveedor,
                    DireccionProveedor = s.DireccionProveedor,
                    EstadoProveedor = s.EstadoProveedor
                }).ToList();
                return Proveedores;
            }
        }
    }
}
