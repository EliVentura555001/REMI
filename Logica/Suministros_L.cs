using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Suministros_L
    {
        public bool Actualizar(Suministros_E actualizarSuministro, ref string mensajeError)
        {
            using (remiEntities db = new remiEntities())
            {
                try
                {
                    Suministros suministrodb = db.Suministros.Find(actualizarSuministro.IdSuministro);
                    suministrodb.NombreSuministro = actualizarSuministro.NombreSuministro;
                    suministrodb.DescripcionSuministro = actualizarSuministro.DescripcionSuministro;
                    suministrodb.CostoSuministro = actualizarSuministro.CostoSuministro;
                    suministrodb.Cantidad = actualizarSuministro.Cantidad;
                    suministrodb.PresentacionSuministro = actualizarSuministro.PresentacionSuministro;
                    suministrodb.UnidadMedida = actualizarSuministro.UnidadMedida;
                    suministrodb.ExistenciasSuministro = actualizarSuministro.ExistenciasSuministro;
                    suministrodb.IdProveedor = actualizarSuministro.IdProveedor;
                    suministrodb.EstadoSuministro = actualizarSuministro.EstadoSuministro;
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
        public bool Guardar(Suministros_E datosNuevoSuministro, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                try
                {

                    Suministros NuevoSuministro = new Suministros()
                    {
                        NombreSuministro = datosNuevoSuministro.NombreSuministro,
                        DescripcionSuministro = datosNuevoSuministro.DescripcionSuministro,
                        CostoSuministro = datosNuevoSuministro.CostoSuministro,
                        Cantidad = datosNuevoSuministro.Cantidad,
                        PresentacionSuministro = datosNuevoSuministro.PresentacionSuministro,
                        UnidadMedida = datosNuevoSuministro.UnidadMedida,
                        ExistenciasSuministro = datosNuevoSuministro.ExistenciasSuministro,
                        IdProveedor = datosNuevoSuministro.IdProveedor,
                        EstadoSuministro = datosNuevoSuministro.EstadoSuministro
                    };
                    db.Suministros.Add(NuevoSuministro);
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
        public List<Suministros_E> ListarSuministrosActivos()
        {
            using (var db = new remiEntities())
            {
                List<Suministros_E> Suministros = new List<Suministros_E>();
                Suministros = db.Suministros.Where(w => w.EstadoSuministro == true).Select(s => new Suministros_E
                {
                    IdSuministro = s.IdSuministro,
                    NombreSuministro = s.NombreSuministro,
                    DescripcionSuministro = s.DescripcionSuministro,
                    CostoSuministro = s.CostoSuministro,
                    Cantidad = s.Cantidad,
                    PresentacionSuministro = s.PresentacionSuministro,
                    UnidadMedida = s.UnidadMedida,
                    ExistenciasSuministro = s.ExistenciasSuministro,
                    IdProveedor = s.IdProveedor,
                }).ToList();
                return Suministros;
            }
        }
        public List<Suministros_E> ListarSuministros()
        {
            using (var db = new remiEntities())
            {
                List<Suministros_E> Suministros = new List<Suministros_E>();
                Suministros = db.Suministros.Select(s => new Suministros_E
                {
                    IdSuministro = s.IdSuministro,
                    NombreSuministro = s.NombreSuministro,
                    DescripcionSuministro = s.DescripcionSuministro,
                    CostoSuministro = s.CostoSuministro,
                    Cantidad = s.Cantidad,
                    PresentacionSuministro = s.PresentacionSuministro,
                    UnidadMedida = s.UnidadMedida,
                    ExistenciasSuministro = s.ExistenciasSuministro,
                    IdProveedor = s.IdProveedor,
                    EstadoSuministro = s.EstadoSuministro,
                    NombreProveedor= s.Proveedores.NombreProveedor
                }).ToList();
                return Suministros;
            }
        }
        public bool RestarExistencia(int idSuministro, decimal cantidad, remiEntities db, ref string mensajeError)
        {
            var suministro = db.Suministros.Find(idSuministro);
            if (suministro == null)
            {
                mensajeError = $"No se encontró el suministro con ID {idSuministro}.";
                return false;
            }
            if (suministro.ExistenciasSuministro < cantidad)
            {
                mensajeError = $"No hay suficiente existencia para el suministro {suministro.NombreSuministro}.";
                return false;
            }
            suministro.ExistenciasSuministro -= cantidad;
            return true;
        }
    }
}
