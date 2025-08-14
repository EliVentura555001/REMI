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
                        // 1. Buscar el pedido existente en la base de datos
                        var pedidoDb = db.Pedido.FirstOrDefault(p => p.IdPedido == actualizarPedido.IdPedido);
                        if (pedidoDb == null)
                        {
                            mensajeError = "No se encontró el pedido.";
                            trans.Rollback();
                            return false;
                        }

                        // 2. Actualizar campos principales
                        pedidoDb.DescripcionPedido = actualizarPedido.DescripcionPedido;
                        pedidoDb.FechaModPedido = DateTime.Now;

                        if (actualizarPedido.DetallePedido == null || !actualizarPedido.DetallePedido.Any())
                        {
                            mensajeError = "No hay detalles para guardar.";
                            trans.Rollback();
                            return false;
                        }

                        // Actualizar detalles de productos
                        foreach (var detalle in actualizarPedido.DetallePedido)
                        {
                            if (detalle.IdProducto == 0)
                            {
                                mensajeError = "IdProducto no válido en detalle.";
                                trans.Rollback();
                                return false;
                            }

                            // Buscar si ya existe el detalle en la base de datos
                            var detalleExistente = db.DetallePedidoP
                                .FirstOrDefault(d => d.IdPedido == pedidoDb.IdPedido
                                                  && d.IdProducto == detalle.IdProducto
                                                  && d.IdSubProducto == detalle.IdSubProducto);

                            if (detalleExistente != null)
                            {
                                // Actualizar los campos existentes
                                detalleExistente.CantidadPorciones = detalle.CantidadPorcionesP;
                                detalleExistente.CostoSubProducto = detalle.CostoSubProducto;
                            }
                            else
                            {
                                // Si no existe, agregar nuevo
                                DetallePedidoP DetallePedidoActual = new DetallePedidoP()
                                {
                                    IdPedido = pedidoDb.IdPedido,
                                    IdProducto = detalle.IdProducto,
                                    IdSubProducto = detalle.IdSubProducto,
                                    CantidadPorciones = detalle.CantidadPorcionesP,
                                    CostoSubProducto = detalle.CostoSubProducto
                                };
                                db.DetallePedidoP.Add(DetallePedidoActual);
                            }
                        }


                        // Actualizar detalles de suministros (ingredientes)
                        if (actualizarPedido.DetallePedidoSP != null && actualizarPedido.DetallePedidoSP.Any())
                        {
                            foreach (var detalleSP in actualizarPedido.DetallePedidoSP)
                            {
                                // Buscar el detalle original en la base de datos
                                var detalleOriginal = db.DetallePedidoSP
                                    .FirstOrDefault(d => d.IdSubProducto == detalleSP.IdSubProducto);

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
                                    detalleOriginal.CostoParcialPSP = detalleSP.CostoSuministro;
                                }
                                else
                                {
                                    // Si es un nuevo detalle, lo agregas
                                    DetallePedidoSP nuevoDetalleSP = new DetallePedidoSP()
                                    {
                                        IdPedido = pedidoDb.IdPedido,
                                        IdSubProducto = detalleSP.IdSubProducto,
                                        IdSuministro = detalleSP.IdSuministro,
                                        CantidadSuministroPSP = cantidadNueva,
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

                            DetallePedidoP nuevoDetalle = new DetallePedidoP()
                            {
                                IdPedido = NuevoPedido.IdPedido,
                                IdProducto = detalle.IdProducto,
                                IdSubProducto = detalle.IdSubProducto,
                                CantidadPorciones = detalle.CantidadPorcionesP,
                                CostoSubProducto = detalle.CostoSubProducto
                            };
                            db.DetallePedidoP.Add(nuevoDetalle);
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
        public List<Pedidos_E> ListarPedidos()
        {
            using (var db = new remiEntities())
            {
                var pedidos = db.Pedido.Select(s => new Pedidos_E
                {
                    IdPedido = s.IdPedido,
                    DescripcionPedido = s.DescripcionPedido,
                    FechaPedido = s.FechaPedido,
                    FechaModPedido = s.FechaModPedido,
                    NombreProducto = s.DetallePedidoP.Select(d => d.Producto.NombreProducto).FirstOrDefault(),
                    DetallePedido = s.DetallePedidoP
                        .Select(d => new DetalleProducto_E
                        {
                            IdProducto = d.IdProducto,
                            IdSubProducto = d.IdSubProducto,
                            NombreProducto = d.Producto.NombreProducto,
                            NombreSubProducto = d.SubProducto.NombreSubProducto,
                            CantidadPorcionesP = d.CantidadPorciones,
                            CostoSubProducto = d.CostoSubProducto,
                        })
                        .ToList(),
                    DetallePedidoSP = s.DetallePedidoSP
                        .Select(d => new DetalleSubProducto_E
                        {
                            IdSubProducto = d.SubProducto.IdSubProducto,
                            IdSuministro = d.Suministros.IdSuministro,
                            CantidadSuministro = d.CantidadSuministroPSP,
                            CostoSuministro = d.CostoParcialPSP,
                            NombreSuministros = d.Suministros.NombreSuministro,
                            NombreSubProducto = d.SubProducto.NombreSubProducto
                        })
                        .ToList()
                }).ToList();
                return pedidos;
            }
        }
        public List<DetallePedidoP_E> ObtenerDetallePedidoPorSubProducto(int idSubProducto)
        {
            using (var db = new remiEntities())
            {
                var detalles = db.DetallePedidoP
                    .Where(d => d.IdSubProducto == idSubProducto && d.CantidadPorciones > 0)
                    .OrderBy(d => d.IdPedido)
                    .Select(d => new DetallePedidoP_E
                    {
                        IdPedido = d.IdPedido,
                        IdProducto = d.IdProducto,
                        IdSubProducto = d.IdSubProducto,
                        CantidadPorciones = d.CantidadPorciones,
                        CostoSubProducto = d.CostoSubProducto,
                        // Puedes agregar más campos si tu entidad los tiene
                    })
                    .ToList();

                return detalles;
            }
        }
    }
}
