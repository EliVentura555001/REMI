using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Productos_L
    {
        public bool Actualizar(Productos_E actualizarProducto, ref string mensajeError)
        {
            using (remiEntities db = new remiEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Producto Productodb = db.Producto.Find(actualizarProducto.IdProducto);
                        Productodb.NombreProducto = actualizarProducto.NombreProducto;
                        Productodb.DescripcionProducto = actualizarProducto.DescripcionProducto;
                        Productodb.CostoProducto = actualizarProducto.CostoProducto;
                        Productodb.IdCategoria = actualizarProducto.IdCategoria;
                        Productodb.EstadoProducto = actualizarProducto.EstadoProducto;
                        db.SaveChanges();

                        if (actualizarProducto.DetalleProducto == null || !actualizarProducto.DetalleProducto.Any())
                        {
                            mensajeError = "No hay detalles para guardar.";
                            trans.Rollback();
                            return false;
                        }

                        // 1. Ids de suministros seleccionados
                        var idsSeleccionados = actualizarProducto.DetalleProducto.Select(d => d.IdProducto).ToList();

                        // 2. Detalles actuales en BD
                        var detallesBD = db.DetalleProducto
                            .Where(d => d.IdProducto == actualizarProducto.IdProducto)
                            .ToList();

                        // 3. Eliminar los que ya no están seleccionados
                        foreach (var detalle in detallesBD)
                        {
                            if (!idsSeleccionados.Contains(detalle.IdProducto))
                            {
                                db.DetalleProducto.Remove(detalle);
                            }
                        }

                        // 4. Agregar los nuevos detalles que no existan
                        foreach (var detalle in actualizarProducto.DetalleProducto)
                        {
                            if (detalle.IdSubProducto == 0)
                            {
                                mensajeError = "IdSubProducto no válido en detalle.";
                                trans.Rollback();
                                return false;
                            }

                            var detalleBD = detallesBD.FirstOrDefault(d => d.IdProducto == detalle.IdProducto);
                            if (detalleBD != null)
                            {
                                // Actualizar el detalle existente
                                detalleBD.IdSubProducto = detalle.IdSubProducto;
                            }
                            else
                            {
                                // Agregar nuevo detalle
                                DetalleProducto nuevoDetalle = new DetalleProducto()
                                {
                                    IdProducto = actualizarProducto.IdProducto,
                                    IdSubProducto = detalle.IdSubProducto,
                                    CostoSubProducto = detalle.CostoSubProducto,
                                    CantidadPorcionesP = detalle.CantidadPorcionesP

                                };
                                db.DetalleProducto.Add(nuevoDetalle);
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
        public bool Guardar(Productos_E datosNuevoProducto, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Producto NuevoProducto = new Producto()
                        {
                            NombreProducto = datosNuevoProducto.NombreProducto,
                            DescripcionProducto = datosNuevoProducto.DescripcionProducto,
                            CostoProducto = datosNuevoProducto.CostoProducto,
                            IdCategoria = datosNuevoProducto.IdCategoria,
                            EstadoProducto = datosNuevoProducto.EstadoProducto
                        };
                        db.Producto.Add(NuevoProducto);
                        db.SaveChanges();

                        if (datosNuevoProducto.DetalleProducto == null || !datosNuevoProducto.DetalleProducto.Any())
                        {
                            mensajeError = "No hay detalles para guardar.";
                            trans.Rollback();
                            return false;
                        }

                        foreach (var detalle in datosNuevoProducto.DetalleProducto)
                        {
                            if (detalle.IdSubProducto == 0)
                            {
                                mensajeError = "IdSubProducto no válido en detalle.";
                                trans.Rollback();
                                return false;
                            }

                            DetalleProducto nuevoDetalle = new DetalleProducto()
                            {
                                IdProducto = NuevoProducto.IdProducto,
                                IdSubProducto = detalle.IdSubProducto,
                                CostoSubProducto = detalle.CostoSubProducto,
                                CantidadPorcionesP = detalle.CantidadPorcionesP
                            };
                            db.DetalleProducto.Add(nuevoDetalle);
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
        public List<Productos_E> ListarProductosActivos()
        {
            using (var db = new remiEntities())
            {
                List<Productos_E> Productos = new List<Productos_E>();
                Productos = db.Producto.Where(w => w.EstadoProducto == true).Select(s => new Productos_E
                {
                    IdProducto = s.IdProducto,
                    NombreProducto = s.NombreProducto,
                    DescripcionProducto = s.DescripcionProducto,
                    CostoProducto = s.CostoProducto,
                    IdCategoria = s.IdCategoria,
                }).ToList();
                return Productos;
            }
        }
        public List<Productos_E> ListarProductos()
        {
            using (var db = new remiEntities())
            {
                List<Productos_E> Productos = new List<Productos_E>();
                Productos = db.Producto.Select(s => new Productos_E
                {
                    IdProducto = s.IdProducto,
                    NombreProducto = s.NombreProducto,
                    DescripcionProducto = s.DescripcionProducto,
                    CostoProducto = s.CostoProducto,
                    IdCategoria = s.IdCategoria,
                    NombreCategoria = s.Categorias.NombreCategoria,
                    DetalleProducto = s.DetalleProducto
                        .Select(d => new DetalleProducto_E
                        {
                            IdSubProducto = d.IdSubProducto,
                            IdProducto = d.IdProducto,
                            NombreSubProducto = d.SubProducto.NombreSubProducto,
                            CostoSubProducto = d.CostoSubProducto,
                            CantidadPorcionesP = d.CantidadPorcionesP
                        })
                        .ToList(),
                    EstadoProducto = s.EstadoProducto
                }).ToList();
                return Productos;
            }
        }
        public List<Productos_E> ObtenerSubProductosPorProducto(int idProducto)
        {
            using (var db = new remiEntities())
            {
                List<Productos_E> dProductos = new List<Productos_E>();
                dProductos = db.Producto.Where(w => w.IdProducto == idProducto).Select(s => new Productos_E
                {
                    DetalleProducto = s.DetalleProducto
                        .Select(d => new DetalleProducto_E
                        {
                            IdSubProducto = d.IdSubProducto,
                            IdProducto = d.IdProducto,
                            NombreProducto = s.NombreProducto,
                            NombreSubProducto = d.SubProducto.NombreSubProducto,
                            CostoSubProducto = d.CostoSubProducto,
                            CantidadPorcionesP =d.CantidadPorcionesP
                        }).ToList()
                }).ToList();
                return dProductos;
            }
        }
    }
}
