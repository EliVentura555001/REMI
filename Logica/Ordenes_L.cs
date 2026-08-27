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

                        // Si no hay detalles, nada que procesar
                        if (datosNuevaOrden.DetalleOrden == null || !datosNuevaOrden.DetalleOrden.Any())
                        {
                            db.SaveChanges();
                            trans.Commit();
                            mensajeError = string.Empty;
                            return true;
                        }

                        // Creamos un SubPedido asociado a esta Orden sólo si vamos a mover porciones
                        SubPedido nuevoSubPedido = null;
                        bool necesitaSubPedido = datosNuevaOrden.DetalleOrden.Any(d => d.CantidadPorciones > 0);

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

                            // Buscar pedidos con porciones disponibles para este subproducto (orden FIFO por IdPedido)
                            var pedidos = db.DetallePedidoP
                                .Where(d => d.IdSubProducto == detalle.IdSubProducto && d.CantidadPorciones > 0)
                                .OrderBy(d => d.IdPedido)
                                .ToList();

                            if (cantidadRestante > 0 && necesitaSubPedido && nuevoSubPedido == null)
                            {
                                // Crear el subpedido vinculado a la orden
                                nuevoSubPedido = new SubPedido()
                                {
                                    IdPedido = pedidos.FirstOrDefault()?.IdPedido ?? 0,
                                    IdOrden = NuevaOrden.IdOrden,
                                    IdUsuario = 0, // asigna según contexto
                                    FechaSubPedido = DateTime.Now,
                                    EstadoSubPedido = "Pendiente" // lo marcamos pendiente hasta comprobar suministros
                                };
                                db.SubPedido.Add(nuevoSubPedido);
                                db.SaveChanges(); // para obtener IdSubPedido
                            }

                            foreach (var pedido in pedidos)
                            {
                                if (cantidadRestante <= 0) break;

                                int porcionesADeducir = Math.Min(pedido.CantidadPorciones, cantidadRestante);

                                // Restar las porciones en el registro origen
                                pedido.CantidadPorciones -= porcionesADeducir;

                                // Registrar en DetalleOrden (como antes)
                                DetalleOrden nuevoDetalleOrden = new DetalleOrden()
                                {
                                    IdPedido = pedido.IdPedido,
                                    IdOrden = NuevaOrden.IdOrden,
                                    IdProducto = detalle.IdProducto,
                                    IdSubProducto = detalle.IdSubProducto,
                                    CantidadPorciones = porcionesADeducir,
                                    PrecioOrden = detalle.PrecioOrden
                                };
                                detallesOrdenAGuardar.Add(nuevoDetalleOrden);

                                // Registrar movimiento en DetallePedidoP apuntando a IdSubPedido (si creamos uno)
                                if (nuevoSubPedido != null)
                                {
                                    var movimientoDetallePedidoP = new DetallePedidoP()
                                    {
                                        IdPedido = pedido.IdPedido,
                                        IdProducto = detalle.IdProducto,
                                        IdSubProducto = detalle.IdSubProducto,
                                        CantidadPorciones = porcionesADeducir,
                                        CostoSubProducto = 0m,
                                        IdSubPedido = nuevoSubPedido.IdSubPedido
                                    };
                                    db.DetallePedidoP.Add(movimientoDetallePedidoP);

                                    // Intentar crear DetallePedidoSP proporcional y restar suministros
                                    var detallesSPOrigen = db.DetallePedidoSP
                                        .Where(s => s.IdPedido == pedido.IdPedido && s.IdSubProducto == detalle.IdSubProducto)
                                        .ToList();

                                    if (detallesSPOrigen.Any())
                                    {
                                        // calcular porciones totales originales para ese subproducto (para repartir proporcionalmente)
                                        int porcionesTotalesOrigen = db.DetallePedidoP
                                            .Where(x => x.IdPedido == pedido.IdPedido && x.IdSubProducto == detalle.IdSubProducto)
                                            .Sum(x => x.CantidadPorciones);

                                        // evitar división por cero
                                        if (porcionesTotalesOrigen > 0)
                                        {
                                            foreach (var spOrigen in detallesSPOrigen)
                                            {
                                                decimal cantidadSuministroPorPorcion = spOrigen.CantidadSuministroPSP / (decimal)porcionesTotalesOrigen;
                                                decimal cantidadSuministroADeducir = Math.Round(cantidadSuministroPorPorcion * porcionesADeducir, 4);

                                                var nuevoDetalleSP = new DetallePedidoSP()
                                                {
                                                    IdPedido = pedido.IdPedido,
                                                    IdSubProducto = detalle.IdSubProducto,
                                                    IdSuministro = spOrigen.IdSuministro,
                                                    CantidadSuministroPSP = cantidadSuministroADeducir,
                                                    CostoParcialPSP = spOrigen.CostoParcialPSP * (cantidadSuministroADeducir / (spOrigen.CantidadSuministroPSP == 0 ? 1 : spOrigen.CantidadSuministroPSP))
                                                };
                                                db.DetallePedidoSP.Add(nuevoDetalleSP);

                                                // Restar existencias de suministros en la misma transacción
                                                if (!new Suministros_L().RestarExistencia(spOrigen.IdSuministro, cantidadSuministroADeducir, db, ref mensajeError))
                                                {
                                                    trans.Rollback();
                                                    return false;
                                                }
                                            }
                                        }
                                        // si porcionesTotalesOrigen == 0, no hacemos nada con suministros (déjalo explícito)
                                    }
                                }

                                cantidadRestante -= porcionesADeducir;
                            }

                            // Si no se pudo cubrir la cantidad pedida -> rollback
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
