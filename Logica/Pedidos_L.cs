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
        public bool Actualizar(Pedidos_E actualizarPedido, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Pedido PedidoActualizado = new Pedido()
                        {
                            IdPedido = actualizarPedido.IdPedido,
                            DescripcionPedido = actualizarPedido.DescripcionPedido,
                            FechaModPedido = DateTime.Now
                        };
                        db.SaveChanges();

                        if (actualizarPedido.DetallePedido == null || !actualizarPedido.DetallePedido.Any())
                        {
                            mensajeError = "No hay detalles para guardar.";
                            trans.Rollback();
                            return false;
                        }

                        // Actualizar detalles de productos
                        foreach (var detalle in actualizarPedido.DetallePedido)
                        {
                            if (detalle.IdSubProducto == 0)
                            {
                                mensajeError = "IdSubProducto no válido en detalle.";
                                trans.Rollback();
                                return false;
                            }

                            DetallePedidoProducto DetallePedidoActual = new DetallePedidoProducto()
                            {
                                IdDetallePedidoProducto = detalle.IdDetalleProducto,
                                IdPedido = PedidoActualizado.IdPedido,
                                IdProducto = detalle.IdProducto,
                                IdSubProducto = detalle.IdSubProducto,
                                CantidadPorciones = detalle.CantidadPorciones,
                                CostoParcial = detalle.CostoSubProducto
                            };
                        }

                        // Actualizar detalles de suministros (ingredientes)
                        if (actualizarPedido.DetallePedidoSP != null && actualizarPedido.DetallePedidoSP.Any())
                        {
                            foreach (var detalleSP in actualizarPedido.DetallePedidoSP)
                            {
                                // Buscar el detalle original en la base de datos
                                var detalleOriginal = db.DetallePedidoSP
                                    .FirstOrDefault(d => d.IdDetallePedidoSP == detalleSP.IdDetalleSubProducto);

                                decimal cantidadAnterior = detalleOriginal != null ? detalleOriginal.CantidadSuministroPSP : 0;
                                decimal cantidadNueva = detalleSP.CantidadSuministro;

                                // Solo si la cantidad ha cambiado
                                if (cantidadAnterior != cantidadNueva)
                                {
                                    decimal diferencia = cantidadNueva - cantidadAnterior;
                                    // Si la diferencia es positiva, se resta existencias (se usó más suministro)
                                    // Si la diferencia es negativa, se suma existencias (se usó menos suministro)
                                    if (!new Suministros_L().RestarExistencia(detalleSP.IdSuministro, diferencia, db, ref mensajeError))
                                    {
                                        trans.Rollback();
                                        return false;
                                    }
                                }

                                // Actualiza el detalle en la base de datos si es necesario
                                if (detalleOriginal != null)
                                {
                                    detalleOriginal.CantidadSuministroPSP = cantidadNueva;
                                    detalleOriginal.UnidadMedidaPSP = detalleSP.UnidadMedidaSP;
                                    detalleOriginal.CostoParcialPSP = detalleSP.CostoSuministro;
                                }
                                else
                                {
                                    // Si es un nuevo detalle, lo agregas
                                    DetallePedidoSP nuevoDetalleSP = new DetallePedidoSP()
                                    {
                                        IdPedido = PedidoActualizado.IdPedido,
                                        IdSubProducto = detalleSP.IdSubProducto,
                                        IdSuministro = detalleSP.IdSuministro,
                                        CantidadSuministroPSP = cantidadNueva,
                                        UnidadMedidaPSP = detalleSP.UnidadMedidaSP,
                                        CostoParcialPSP = detalleSP.CostoSuministro
                                    };
                                    db.DetallePedidoSP.Add(nuevoDetalleSP);

                                    // Ejecuta RestarExistencia para el nuevo detalle
                                    if (!new Suministros_L().RestarExistencia(detalleSP.IdSuministro, cantidadNueva, db, ref mensajeError))
                                    {
                                        trans.Rollback();
                                        return false;
                                    }
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
        public List<Pedidos_E> ListarPedidos()
        {
            using (var db = new remiEntities())
            {
                List<Pedidos_E> pedidos = new List<Pedidos_E>();
                pedidos = db.Pedido.Select(s => new Pedidos_E
                {
                    IdPedido = s.IdPedido,
                    DescripcionPedido = s.DescripcionPedido,
                    FechaPedido = s.FechaPedido,
                    FechaModPedido = s.FechaModPedido,
                    NombreProducto = s.DetallePedidoProducto.Select(d => d.Producto.NombreProducto).FirstOrDefault(),
                    DetallePedido = s.DetallePedidoProducto
                        .Select(d => new DetalleProducto_E
                        {
                            IdDetalleProducto = d.IdDetallePedidoProducto,
                            IdProducto = d.IdProducto,
                            IdSubProducto = d.IdSubProducto,
                            NombreProducto = d.Producto.NombreProducto,
                            NombreSubProducto = d.SubProducto.NombreSubProducto,
                            CantidadPorciones = d.CantidadPorciones,
                            CostoSubProducto = d.CostoParcial,
                        })
                        .ToList(),
                    DetallePedidoSP = s.DetallePedidoSP
                        .Select(d => new DetalleSubProducto_E
                        {
                            IdDetalleSubProducto = d.IdDetallePedidoSP,
                            IdSubProducto = d.IdSubProducto,
                            IdSuministro = d.IdSuministro,
                            CantidadSuministro = d.CantidadSuministroPSP,
                            UnidadMedidaSP = d.UnidadMedidaPSP,
                            CostoSuministro = d.CostoParcialPSP,
                            NombreSuministros = db.Suministros
                                .Where(su => su.IdSuministro == d.IdSuministro)
                                .Select(su => su.NombreSuministro)
                                .FirstOrDefault(),
                            NombreSubProducto = d.SubProducto.NombreSubProducto
                        })
                        .ToList()
                }).ToList();
                return pedidos;
            }
        }
    }
}
