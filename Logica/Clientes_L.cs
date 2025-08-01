using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Clientes_L
    {
        public bool Actualizar(Clientes_E actualizarCliente, ref string mensajeError)
        {
            using (remiEntities db = new remiEntities())
            {
                try
                {
                    Clientes clientedb = db.Clientes.Find(actualizarCliente.IdCliente);
                    clientedb.NombreCliente = actualizarCliente.NombreCliente;
                    clientedb.TelefonoCliente = actualizarCliente.TelefonoCliente;
                    clientedb.CorreoCliente = actualizarCliente.CorreoCliente;
                    clientedb.DireccionCliente = actualizarCliente.DireccionCliente;
                    clientedb.EstadoCliente = actualizarCliente.EstadoCliente;
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
        public bool Guardar(Clientes_E datosNuevoCliente, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                try
                {

                    Clientes NuevoCliente = new Clientes()
                    {
                        NombreCliente = datosNuevoCliente.NombreCliente,
                        TelefonoCliente = datosNuevoCliente.TelefonoCliente,
                        CorreoCliente = datosNuevoCliente.CorreoCliente,
                        DireccionCliente = datosNuevoCliente.DireccionCliente,
                        EstadoCliente = datosNuevoCliente.EstadoCliente
                    };
                    db.Clientes.Add(NuevoCliente);
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
        public List<Clientes_E> ListarClientesActivos()
        {
            using (var db = new remiEntities())
            {
                List<Clientes_E> Clientes = new List<Clientes_E>();
                Clientes = db.Clientes.Where(w => w.EstadoCliente == true).Select(s => new Clientes_E
                {
                    IdCliente = s.IdCliente,
                    NombreCliente = s.NombreCliente,
                    TelefonoCliente = s.TelefonoCliente,
                    CorreoCliente = s.CorreoCliente,
                    DireccionCliente = s.DireccionCliente,
                }).ToList();
                return Clientes;
            }
        }
        public List<Clientes_E> ListarClientes()
        {
            using (var db = new remiEntities())
            {
                List<Clientes_E> Clientes = new List<Clientes_E>();
                Clientes = db.Clientes.Select(s => new Clientes_E
                {
                    IdCliente = s.IdCliente,
                    NombreCliente = s.NombreCliente,
                    TelefonoCliente = s.TelefonoCliente,
                    CorreoCliente = s.CorreoCliente,
                    DireccionCliente = s.DireccionCliente,
                    EstadoCliente = s.EstadoCliente
                }).ToList();
                return Clientes;
            }
        }
    }
}
