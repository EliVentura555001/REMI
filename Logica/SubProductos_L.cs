using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class SubProductos_L
    {
        public bool Actualizar(SubProductos_E actualizarSubProducto, ref string mensajeError)
        {
            using (remiEntities db = new remiEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        SubProducto SubProductodb = db.SubProducto.Find(actualizarSubProducto.IdSubProducto);
                        SubProductodb.NombreSubProducto = actualizarSubProducto.NombreSubProducto;
                        SubProductodb.DescripcionSubProducto = actualizarSubProducto.DescripcionSubProducto;
                        SubProductodb.CostoSubProducto = actualizarSubProducto.CostoSubProducto;
                        SubProductodb.PrecioSubProducto = actualizarSubProducto.PrecioSubProducto;
                        SubProductodb.Instrucciones = actualizarSubProducto.Instrucciones;
                        SubProductodb.EstadoSubProducto = actualizarSubProducto.EstadoSubProducto;
                        db.SaveChanges();

                        if (actualizarSubProducto.DetalleSubProducto == null || !actualizarSubProducto.DetalleSubProducto.Any())
                        {
                            mensajeError = "No hay detalles para guardar.";
                            trans.Rollback();
                            return false;
                        }

                        // 1. Ids de suministros seleccionados
                        var idsSeleccionados = actualizarSubProducto.DetalleSubProducto.Select(d => d.IdDetalleSubProducto).ToList();

                        // 2. Detalles actuales en BD
                        var detallesBD = db.DetalleSubProducto
                            .Where(d => d.IdSubProducto == actualizarSubProducto.IdSubProducto)
                            .ToList();

                        // 3. Eliminar los que ya no están seleccionados
                        foreach (var detalle in detallesBD)
                        {
                            if (!idsSeleccionados.Contains(detalle.IdDetalleSubProducto))
                            {
                                db.DetalleSubProducto.Remove(detalle);
                            }
                        }

                        // 4. Agregar los nuevos detalles que no existan
                        foreach (var detalle in actualizarSubProducto.DetalleSubProducto)
                        {
                            if (detalle.IdSuministro == 0)
                            {
                                mensajeError = "IdSuministro no válido en detalle.";
                                trans.Rollback();
                                return false;
                            }

                            var detalleBD = detallesBD.FirstOrDefault(d => d.IdDetalleSubProducto == detalle.IdDetalleSubProducto);
                            if (detalleBD != null)
                            {
                                // Actualizar el detalle existente
                                detalleBD.IdSuministro = detalle.IdSuministro;
                                detalleBD.CantidadSuministro = detalle.CantidadSuministro;
                                detalleBD.UnidadMedidaSP = detalle.UnidadMedidaSP;
                                detalleBD.CostoSuministro = detalle.CostoSuministro; 
                            }
                            else
                            {
                                // Agregar nuevo detalle
                                DetalleSubProducto nuevoDetalle = new DetalleSubProducto()
                                {
                                    IdSubProducto = actualizarSubProducto.IdSubProducto,
                                    IdSuministro = detalle.IdSuministro,
                                    CantidadSuministro = detalle.CantidadSuministro,
                                    UnidadMedidaSP = detalle.UnidadMedidaSP,
                                    CostoSuministro = detalle.CostoSuministro 
                                };
                                db.DetalleSubProducto.Add(nuevoDetalle);
                            }
                        }

                        db.SaveChanges();
                        trans.Commit();
                        mensajeError = string.Empty;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        mensajeError = ex.Message;
                        return false;
                    }
                }
            }
        }
        public bool Guardar(SubProductos_E datosNuevoSubProducto, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        SubProducto NuevoSubProducto = new SubProducto()
                        {
                            NombreSubProducto = datosNuevoSubProducto.NombreSubProducto,
                            DescripcionSubProducto = datosNuevoSubProducto.DescripcionSubProducto,
                            CostoSubProducto = datosNuevoSubProducto.CostoSubProducto,
                            PrecioSubProducto = datosNuevoSubProducto.PrecioSubProducto,
                            Instrucciones = datosNuevoSubProducto.Instrucciones,
                            EstadoSubProducto = datosNuevoSubProducto.EstadoSubProducto
                        };
                        db.SubProducto.Add(NuevoSubProducto);
                        db.SaveChanges();

                        if (datosNuevoSubProducto.DetalleSubProducto == null || !datosNuevoSubProducto.DetalleSubProducto.Any())
                        {
                            mensajeError = "No hay detalles para guardar.";
                            trans.Rollback();
                            return false;
                        }

                        foreach (var detalle in datosNuevoSubProducto.DetalleSubProducto)
                        {
                            if (detalle.IdSuministro == 0)
                            {
                                mensajeError = "IdSuministro no válido en detalle.";
                                trans.Rollback();
                                return false;
                            }

                            DetalleSubProducto nuevoDetalle = new DetalleSubProducto()
                            {
                                IdSubProducto = NuevoSubProducto.IdSubProducto,
                                IdSuministro = detalle.IdSuministro,
                                CantidadSuministro = detalle.CantidadSuministro,
                                UnidadMedidaSP = detalle.UnidadMedidaSP,
                                CostoSuministro = detalle.CostoSuministro
                            };
                            db.DetalleSubProducto.Add(nuevoDetalle);
                            db.SaveChanges();
                        }
                        trans.Commit();
                        mensajeError = string.Empty;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        mensajeError = ex.Message;
                        return false;
                    }
                }
            }
        }
        public List<SubProductos_E> ListarSubProductosActivos()
        {
            using (var db = new remiEntities())
            {
                List<SubProductos_E> subProductos = new List<SubProductos_E>();
                subProductos = db.SubProducto.Where(w => w.EstadoSubProducto == true).Select(s => new SubProductos_E
                {
                    IdSubProducto = s.IdSubProducto,
                    NombreSubProducto = s.NombreSubProducto,
                    DescripcionSubProducto = s.DescripcionSubProducto,
                    CostoSubProducto = s.CostoSubProducto,
                    PrecioSubProducto = s.PrecioSubProducto,
                    Instrucciones = s.Instrucciones,
                }).ToList();
                return subProductos;
            }
        }
        public List<SubProductos_E> ListarSubProductos()
        {
            using (var db = new remiEntities())
            {
                List<SubProductos_E> subProductos = new List<SubProductos_E>();
                subProductos = db.SubProducto.Select(s => new SubProductos_E
                {
                    IdSubProducto = s.IdSubProducto,
                    NombreSubProducto = s.NombreSubProducto,
                    DescripcionSubProducto = s.DescripcionSubProducto,
                    CostoSubProducto = s.CostoSubProducto,
                    PrecioSubProducto = s.PrecioSubProducto,
                    Instrucciones = s.Instrucciones,
                    DetalleSubProducto = s.DetalleSubProducto
                        .Select(d => new DetalleSubProducto_E
                        {
                            IdDetalleSubProducto = d.IdDetalleSubProducto,
                            IdSubProducto = d.IdSubProducto,
                            IdSuministro = d.IdSuministro,
                            NombreSuministros = d.Suministros.NombreSuministro,
                            CantidadSuministro = d.CantidadSuministro,
                            UnidadMedidaSP = d.UnidadMedidaSP,
                            CostoSuministro = d.CostoSuministro
                        })
                        .ToList(),
                    EstadoSubProducto = s.EstadoSubProducto
                }).ToList(); 
                return subProductos;
            }
        }
        public List<SubProductos_E> ListarSubProductosPorProducto(int idProducto)
        {
            using (var db = new remiEntities())
            {
                var subProductos = db.DetalleProducto
                    .Where(dp => dp.IdProducto == idProducto)
                    .Select(dp => dp.SubProducto)
                    .Distinct()
                    .Select(sp => new SubProductos_E
                    {
                        IdSubProducto = sp.IdSubProducto,
                        NombreSubProducto = sp.NombreSubProducto,
                        CostoSubProducto = sp.CostoSubProducto,
                    })
                    .ToList();

                return subProductos;
            }
        }
        public List<DetalleSubProducto_E> ObtenerDetallesDeSubProducto(int idSubProducto)
        {
            using (var db = new remiEntities())
            {
                var detalles = db.DetalleSubProducto
                    .Where(dsp => dsp.IdSubProducto == idSubProducto)
                    .Select(dsp => new DetalleSubProducto_E
                    {
                        IdDetalleSubProducto = dsp.IdDetalleSubProducto,
                        IdSubProducto = dsp.IdSubProducto,
                        IdSuministro = dsp.IdSuministro,
                        NombreSubProducto = dsp.SubProducto.NombreSubProducto,
                        NombreSuministros = dsp.Suministros.NombreSuministro,
                        CantidadSuministro = dsp.CantidadSuministro,
                        UnidadMedidaSP = dsp.UnidadMedidaSP,
                        CostoSuministro = dsp.CostoSuministro

                    })
                    .ToList();

                return detalles;
            }
        }
    }
}
