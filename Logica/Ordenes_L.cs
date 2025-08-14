using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Ordenes_L
    {
        public bool Actualizar(Ordenes_E actualizarPedido, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Ordenes NuevaOrden = new Ordenes()
                        {
                            DescripcionOrden = actualizarPedido.DescripcionOrden,
                            FechaCreacionOrden = DateTime.Now
                        };
                        db.Ordenes.Add(NuevaOrden);
                        db.SaveChanges();

                        // Guardar detalles de productos
                        foreach (var detalle in actualizarPedido.DetalleOrden)
                        {
                            if (detalle.IdSubProducto == 0)
                            {
                                mensajeError = "IdSubProducto no válido en detalle.";
                                trans.Rollback();
                                return false;
                            }

                            DetalleOrden nuevoDetalle = new DetalleOrden()
                            {
                                IdPedido = detalle.IdPedido,
                                IdProducto = detalle.IdProducto,
                                IdSubProducto = detalle.IdSubProducto,
                                CantidadPorciones = detalle.CantidadPorciones,
                                PrecioOrden = detalle.PrecioOrden
                            };
                            db.DetalleOrden.Add(nuevoDetalle);
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
        public bool Guardar(Ordenes_E datosNuevaOrden, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Ordenes NuevaOrden = new Ordenes()
                        {
                            DescripcionOrden = datosNuevaOrden.DescripcionOrden,
                            FechaCreacionOrden = DateTime.Now
                        };
                        db.Ordenes.Add(NuevaOrden);
                        db.SaveChanges();

                        // Lista para almacenar los detalles a guardar
                        var detallesOrdenAGuardar = new List<DetalleOrden>();

                        foreach (var detalle in datosNuevaOrden.DetalleOrden)
                        {
                            if (detalle.IdSubProducto == 0)
                            {
                                mensajeError = "IdSubProducto no válido en detalle.";
                                trans.Rollback();
                                return false;
                            }

                            int cantidadRestante = detalle.CantidadPorciones;

                            // Buscar pedidos con porciones disponibles para este subproducto
                            var pedidos = db.DetallePedidoP
                                .Where(d => d.IdSubProducto == detalle.IdSubProducto && d.CantidadPorciones > 0)
                                .OrderBy(d => d.IdPedido)
                                .ToList();

                            foreach (var pedido in pedidos)
                            {
                                if (cantidadRestante <= 0) break;

                                int porcionesADeducir = Math.Min(pedido.CantidadPorciones, cantidadRestante);

                                // Restar las porciones en la base de datos
                                pedido.CantidadPorciones -= porcionesADeducir;

                                // Crear el detalle de la orden con el IdPedido de donde se dedujo
                                DetalleOrden nuevoDetalle = new DetalleOrden()
                                {
                                    IdPedido = pedido.IdPedido,
                                    IdOrden = NuevaOrden.IdOrden,
                                    IdProducto = detalle.IdProducto,
                                    IdSubProducto = detalle.IdSubProducto,
                                    CantidadPorciones = porcionesADeducir,
                                    PrecioOrden = detalle.PrecioOrden
                                };
                                detallesOrdenAGuardar.Add(nuevoDetalle);

                                cantidadRestante -= porcionesADeducir;
                            }

                            // Si no hay suficientes porciones, cancelar la transacción
                            if (cantidadRestante > 0)
                            {
                                mensajeError = $"No hay suficientes porciones disponibles para el subproducto {detalle.IdSubProducto}.";
                                trans.Rollback();
                                return false;
                            }
                        }

                        // Guardar todos los detalles de la orden
                        foreach (var detalleOrden in detallesOrdenAGuardar)
                        {
                            db.DetalleOrden.Add(detalleOrden);
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
        public List<Ordenes_E> ListaOrdenes()
        {
            using (var db = new remiEntities())
            {
                var ordenes = db.Ordenes.Select(s => new Ordenes_E
                {
                    IdOrden = s.IdOrden,
                    DescripcionOrden = s.DescripcionOrden,
                    FechaCreacionOrden = s.FechaCreacionOrden,
                    FechaModOrden = s.FechaModOrden,
                    NombreProducto = s.DetalleOrden
                        .Select(d => d.Producto.NombreProducto)
                        .FirstOrDefault(),
                    DetalleOrden = s.DetalleOrden
                        .Select(d => new DetalleOrden_E
                        {
                            IdPedido = d.IdPedido,
                            IdProducto = d.Producto.IdProducto,
                            IdSubProducto = d.SubProducto.IdSubProducto,
                            NombreSubProducto = d.SubProducto.NombreSubProducto,
                            CantidadPorciones = d.CantidadPorciones,
                            PrecioOrden = d.PrecioOrden
                        })
                        .ToList()
                }).ToList();
                return ordenes;
            }
        }
    }
}
