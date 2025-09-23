using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CategoriasSubProducto_L
    {
        public bool Actualizar(CategoriasSubProducto_E actualizarCategoriaSP, ref string mensajeError)
        {
            using (remiEntities db = new remiEntities())
            {
                try
                {
                    CategoriaSubProducto categoriaspdb = db.CategoriaSubProducto.Find(actualizarCategoriaSP.IdCategoriaSP);
                    categoriaspdb.NombreCategoriaSP = actualizarCategoriaSP.NombreCategoriaSP;
                    categoriaspdb.DescripcionCategoriaSP = actualizarCategoriaSP.DescripcionCategoriaSP;
                    categoriaspdb.EstadoCategoriaSP = actualizarCategoriaSP.EstadoCategoriaSP;
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
        public bool Guardar(CategoriasSubProducto_E datosNuevaCategoriaSP, ref string mensajeError)
        {
            using (var db = new remiEntities())
            {
                try
                {

                    CategoriaSubProducto NuevaCategoriaSP = new CategoriaSubProducto()
                    {
                        NombreCategoriaSP = datosNuevaCategoriaSP.NombreCategoriaSP,
                        DescripcionCategoriaSP = datosNuevaCategoriaSP.DescripcionCategoriaSP,
                        EstadoCategoriaSP = datosNuevaCategoriaSP.EstadoCategoriaSP
                    };
                    db.CategoriaSubProducto.Add(NuevaCategoriaSP);
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
        public List<CategoriasSubProducto_E> ListarCategoriasSPActivas()
        {
            using (var db = new remiEntities())
            {
                List<CategoriasSubProducto_E> categoriasSP = new List<CategoriasSubProducto_E>();
                categoriasSP = db.CategoriaSubProducto.Where(w => w.EstadoCategoriaSP == true).Select(s => new CategoriasSubProducto_E
                {
                    IdCategoriaSP = s.IdCategoriaSP,
                    NombreCategoriaSP = s.NombreCategoriaSP,
                    DescripcionCategoriaSP = s.DescripcionCategoriaSP,
                }).ToList();
                return categoriasSP;
            }
        }
        public List<CategoriasSubProducto_E> ListarCategoriasSP()
        {
            using (var db = new remiEntities())
            {
                List<CategoriasSubProducto_E> categoriasSP = new List<CategoriasSubProducto_E>();
                categoriasSP = db.CategoriaSubProducto.Select(s => new CategoriasSubProducto_E
                {
                    IdCategoriaSP = s.IdCategoriaSP,
                    NombreCategoriaSP = s.NombreCategoriaSP,
                    DescripcionCategoriaSP = s.DescripcionCategoriaSP,
                    EstadoCategoriaSP = s.EstadoCategoriaSP
                }).ToList();
                return categoriasSP;
            }
        }
    }
}
