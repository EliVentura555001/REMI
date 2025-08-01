using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Logica
{
    public class Categorias_L
    {
        public bool Actualizar(Categorias_E actualizarCategoria, ref string mensajeError)
        {
            using (remiEntities db = new remiEntities())
            {
                try
                {
                    Categorias categoriadb = db.Categorias.Find(actualizarCategoria.IdCategoria);
                    categoriadb.NombreCategoria = actualizarCategoria.NombreCategoria;
                    categoriadb.DescripcionCategoria = actualizarCategoria.DescripcionCategoria;
                    categoriadb.EstadoCategoria = actualizarCategoria.EstadoCategoria;
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
        public bool Guardar(Categorias_E datosNuevaCategoria, ref string mensajeError)
        {   
            using (var db = new remiEntities())
            {
                try
                {

                    Categorias NuevaCategoria = new Categorias()
                    {
                        NombreCategoria = datosNuevaCategoria.NombreCategoria,
                        DescripcionCategoria = datosNuevaCategoria.DescripcionCategoria,
                        EstadoCategoria = datosNuevaCategoria.EstadoCategoria
                    };
                    db.Categorias.Add(NuevaCategoria);
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
        public List<Categorias_E> ListarCategoriasActivas()
        {
            using (var db = new remiEntities())
            {
                List<Categorias_E> categorias = new List<Categorias_E>();
                categorias = db.Categorias.Where(w => w.EstadoCategoria == true).Select(s => new Categorias_E
                {
                    IdCategoria = s.IdCategoria,
                    NombreCategoria = s.NombreCategoria,
                    DescripcionCategoria = s.DescripcionCategoria,
                }).ToList();
                return categorias;
            }
        }
        public List<Categorias_E> ListarCategorias()
        {
            using (var db = new remiEntities())
            {
                List<Categorias_E> categorias = new List<Categorias_E>();
                categorias = db.Categorias.Select(s => new Categorias_E
                {
                    IdCategoria = s.IdCategoria,
                    NombreCategoria = s.NombreCategoria,
                    DescripcionCategoria = s.DescripcionCategoria,
                    EstadoCategoria = s.EstadoCategoria
                }).ToList();
                return categorias;
            }
        }
    }
}
