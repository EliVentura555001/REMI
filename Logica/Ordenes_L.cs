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
        public bool Actualizar(Ordenes_E actualizarOrden, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Buscar el pedido existente en la base de datos
                        var ordenDB = db.Ordenes.FirstOrDefault(p => p.IdOrden == actualizarOrden.IdOrden);
                        if (ordenDB == null)
                        {
                            mensajeError = "No se encontró la orden.";
                            trans.Rollback();
                            return false;
                        }

                        // 2. Actualizar campos principales
                        ordenDB.DescripcionOrden = actualizarOrden.DescripcionOrden;
                        ordenDB.FechaModOrden = DateTime.Now;

                        // 3. Eliminar detalles que ya no están en la lista recibida
                        var detallesActuales = db.DetalleOrden
                            .Where(d => d.IdOrden == actualizarOrden.IdOrden)
                            .ToList();

                        var detallesAEliminar = detallesActuales
                            .Where(detalleBD => !actualizarOrden.DetalleOrden.Any(detalleForm =>
                                detalleForm.IdProducto == detalleBD.IdProducto &&
                                detalleForm.IdSubProducto == detalleBD.IdSubProducto))
                            .ToList();

                        foreach (var detalleEliminar in detallesAEliminar)
                        {
                            // Devolver stock antes de eliminar
                            var detallePedidoP = db.DetallePedidoP
                                .FirstOrDefault(dp => dp.IdPedido == detalleEliminar.IdPedido
                                                   && dp.IdSubProducto == detalleEliminar.IdSubProducto);
                            if (detallePedidoP != null)
                            {
                                detallePedidoP.CantidadPorciones += detalleEliminar.CantidadPorciones;
                            }
                            db.DetalleOrden.Remove(detalleEliminar);
                        }

                        // 4. Actualizar o agregar detalles
                        if (actualizarOrden.DetalleOrden != null && actualizarOrden.DetalleOrden.Any())
                        {
                            foreach (var detalleOP in actualizarOrden.DetalleOrden)
                            {
                                var detalleOriginal = db.DetalleOrden
                                    .FirstOrDefault(d => d.IdOrden == actualizarOrden.IdOrden
                                                      && d.IdProducto == detalleOP.IdProducto
                                                      && d.IdSubProducto == detalleOP.IdSubProducto);

                                int cantidadAnterior = detalleOriginal != null ? detalleOriginal.CantidadPorciones : 0;
                                int cantidadNueva = detalleOP.CantidadPorciones;

                                if (detalleOriginal != null)
                                {
                                    // Modificar el detalle existente
                                    var detallePedidoP = db.DetallePedidoP
                                        .FirstOrDefault(dp => dp.IdPedido == detalleOriginal.IdPedido
                                                           && dp.IdSubProducto == detalleOriginal.IdSubProducto);

                                    if (cantidadNueva < cantidadAnterior)
                                    {
                                        int diferencia = cantidadAnterior - cantidadNueva;
                                        if (detallePedidoP != null)
                                            detallePedidoP.CantidadPorciones += diferencia;
                                    }
                                    else if (cantidadNueva > cantidadAnterior)
                                    {
                                        int diferencia = cantidadNueva - cantidadAnterior;
                                        if (detallePedidoP != null)
                                        {
                                            if (detallePedidoP.CantidadPorciones >= diferencia)
                                                detallePedidoP.CantidadPorciones -= diferencia;
                                            else
                                            {
                                                mensajeError = "No hay suficientes porciones disponibles para aumentar la cantidad.";
                                                trans.Rollback();
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            mensajeError = "No se encontró el detalle de pedido para restar porciones.";
                                            trans.Rollback();
                                            return false;
                                        }
                                    }

                                    // Actualizar campos
                                    detalleOriginal.CantidadPorciones = cantidadNueva;
                                    detalleOriginal.PrecioOrden = detalleOP.PrecioOrden;
                                }
                                else
                                {
                                    int cantidadRestante = detalleOP.CantidadPorciones;

                                    // Buscar pedidos con porciones disponibles para este subproducto
                                    var pedidos = db.DetallePedidoP
                                        .Where(d => d.IdSubProducto == detalleOP.IdSubProducto && d.CantidadPorciones > 0)
                                        .OrderBy(d => d.IdPedido)
                                        .ToList();

                                    foreach (var pedido in pedidos)
                                    {
                                        if (cantidadRestante <= 0) break;

                                        int porcionesADeducir = Math.Min(pedido.CantidadPorciones, cantidadRestante);

                                        // Restar las porciones en la base de datos
                                        pedido.CantidadPorciones -= porcionesADeducir;

                                        // Crear el detalle de la orden con el IdPedido de donde se dedujo
                                        DetalleOrden actualDetalle = new DetalleOrden()
                                        {
                                            IdOrden = actualizarOrden.IdOrden,
                                            IdPedido = pedido.IdPedido,
                                            IdProducto = detalleOP.IdProducto,
                                            IdSubProducto = detalleOP.IdSubProducto,
                                            CantidadPorciones = porcionesADeducir,
                                            PrecioOrden = detalleOP.PrecioOrden
                                        };
                                        db.DetalleOrden.Add(actualDetalle);

                                        cantidadRestante -= porcionesADeducir;
                                    }

                                    // Si no hay suficientes porciones, cancelar la transacción
                                    if (cantidadRestante > 0)
                                    {
                                        mensajeError = $"No hay suficientes porciones disponibles para el subproducto {detalleOP.IdSubProducto}.";
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
                            NombreProducto = d.Producto.NombreProducto,
                            NombreSubProducto = d.SubProducto.NombreSubProducto,
                            CantidadPorciones = d.CantidadPorciones,
                            PrecioOrden = d.PrecioOrden
                        })
                        .ToList()
                }).ToList();
                return ordenes;
            }
        }
        public List<DetalleOrden_E> ObtenerDetallesOrdenporID(int idOrden)
        {
            using (var db = new remiEntities())
            {
                var detalles = db.DetalleOrden
                    .Where(d => d.IdOrden == idOrden)
                    .Select(d => new DetalleOrden_E
                    {
                        IdPedido = d.IdPedido,
                        IdProducto = d.IdProducto,
                        IdSubProducto = d.IdSubProducto,
                        NombreProducto = d.Producto.NombreProducto,
                        NombreSubProducto = d.SubProducto.NombreSubProducto,
                        CantidadPorciones = d.CantidadPorciones,
                        PrecioOrden = d.PrecioOrden
                    })
                    .ToList();
                return detalles;
            }
        }
    }
}
