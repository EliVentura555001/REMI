using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Pedidos_L
    {
        public bool Actualizar(Pedidos_E actualizarProducto, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Pedido NuevoPedido = new Pedido()
                        {
                            DescripcionPedido = actualizarProducto.DescripcionPedido,
                            FechaPedido = DateTime.Now
                        };
                        db.Pedido.Add(NuevoPedido);
                        db.SaveChanges();

                        if (actualizarProducto.DetallePedido == null || !actualizarProducto.DetallePedido.Any())
                        {
                            mensajeError = "No hay detalles para guardar.";
                            trans.Rollback();
                            return false;
                        }

                        // Guardar detalles de productos
                        foreach (var detalle in actualizarProducto.DetallePedido)
                        {
                            if (detalle.IdSubProducto == 0)
                            {
                                mensajeError = "IdSubProducto no válido en detalle.";
                                trans.Rollback();
                                return false;
                            }

                            DetallePedidoProducto nuevoDetalle = new DetallePedidoProducto()
                            {
                                IdPedido = NuevoPedido.IdPedido,
                                IdProducto = detalle.IdProducto,
                                IdSubProducto = detalle.IdSubProducto,
                                CantidadPorciones = detalle.CantidadPorciones,
                                CostoParcial = detalle.CostoSubProducto
                            };
                            db.DetallePedidoProducto.Add(nuevoDetalle);
                        }

                        // Guardar detalles de suministros (ingredientes)
                        if (actualizarProducto.DetallePedidoSP != null && actualizarProducto.DetallePedidoSP.Any())
                        {
                            foreach (var detalleSP in actualizarProducto.DetallePedidoSP)
                            {
                                DetallePedidoSP nuevoDetalleSP = new DetallePedidoSP()
                                {
                                    IdPedido = NuevoPedido.IdPedido,
                                    IdSubProducto = detalleSP.IdSubProducto,
                                    IdSuministro = detalleSP.IdSuministro,
                                    CantidadSuministroPSP = detalleSP.CantidadSuministro,
                                    UnidadMedidaPSP = detalleSP.UnidadMedidaSP,
                                    CostoParcialPSP = detalleSP.CostoSuministro
                                };
                                db.DetallePedidoSP.Add(nuevoDetalleSP);
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
        public bool Guardar(Pedidos_E datosNuevoPedido, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Pedido NuevoPedido = new Pedido()
                        {
                            DescripcionPedido = datosNuevoPedido.DescripcionPedido,
                            FechaPedido = DateTime.Now
                        };
                        db.Pedido.Add(NuevoPedido);
                        db.SaveChanges();

                        if (datosNuevoPedido.DetallePedido == null || !datosNuevoPedido.DetallePedido.Any())
                        {
                            mensajeError = "No hay detalles para guardar.";
                            trans.Rollback();
                            return false;
                        }

                        // Guardar detalles de productos
                        foreach (var detalle in datosNuevoPedido.DetallePedido)
                        {
                            if (detalle.IdSubProducto == 0)
                            {
                                mensajeError = "IdSubProducto no válido en detalle.";
                                trans.Rollback();
                                return false;
                            }

                            DetallePedidoProducto nuevoDetalle = new DetallePedidoProducto()
                            {
                                IdPedido = NuevoPedido.IdPedido,
                                IdProducto = detalle.IdProducto,
                                IdSubProducto = detalle.IdSubProducto,
                                CantidadPorciones = detalle.CantidadPorciones,
                                CostoParcial = detalle.CostoSubProducto
                            };
                            db.DetallePedidoProducto.Add(nuevoDetalle);
                        }

                        // Guardar detalles de suministros (ingredientes)
                        if (datosNuevoPedido.DetallePedidoSP != null && datosNuevoPedido.DetallePedidoSP.Any())
                        {
                            foreach (var detalleSP in datosNuevoPedido.DetallePedidoSP)
                            {
                                DetallePedidoSP nuevoDetalleSP = new DetallePedidoSP()
                                {
                                    IdPedido = NuevoPedido.IdPedido,
                                    IdSubProducto = detalleSP.IdSubProducto,
                                    IdSuministro = detalleSP.IdSuministro,
                                    CantidadSuministroPSP = detalleSP.CantidadSuministro,
                                    UnidadMedidaPSP = detalleSP.UnidadMedidaSP,
                                    CostoParcialPSP = detalleSP.CostoSuministro
                                };
                                db.DetallePedidoSP.Add(nuevoDetalleSP);

                                // Actualiza existencias
                                if (!new Suministros_L().RestarExistencia(detalleSP.IdSuministro, detalleSP.CantidadSuministro, db, ref mensajeError))
                                {
                                    trans.Rollback();
                                    return false;
                                }
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
                    PrecioProducto = s.PrecioProducto,
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
                    PrecioProducto = s.PrecioProducto,
                    IdCategoria = s.IdProducto,
                    NombreCategoria = s.Categorias.NombreCategoria,
                    DetalleProducto = s.DetalleProducto
                        .Select(d => new DetalleProducto_E
                        {
                            IdDetalleProducto = d.IdDetalleProducto,
                            IdSubProducto = d.IdSubProducto,
                            IdProducto = d.IdProducto,
                            NombreSubProducto = d.SubProducto.NombreSubProducto,
                        })
                        .ToList(),
                    EstadoProducto = s.EstadoProducto
                }).ToList();
                return Productos;
            }
        }
    }
}
