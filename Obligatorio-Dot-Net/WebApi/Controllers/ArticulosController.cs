using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Core;

namespace WebApi.Controllers
{
    public class ArticulosController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/Articulos?conStock=n or ''
        public IQueryable<Articulo> GetArticuloSet(string conStock)
        {
            //si manda n es sin stock, sino por defecto manda con stock
            if (conStock == "n" || conStock == "n")
                return db.ArticuloSet.Where(a => a.CantidadEnStock < 0);
            else
                return db.ArticuloSet.Where(a => a.CantidadEnStock > 0);
            
        }

        // GET: api/Articulos?term=n or ''
        public IQueryable<Articulo> GetArticulosSearch(string term)
        {
            //retorna los que contiene term en su nombre o descripcion            
            return db.ArticuloSet.Where(a => a.Nombre.Contains(term) || a.Descripcion.Contains(term)) ;            
        }

        // GET: api/Articulos/5
        [ResponseType(typeof(Articulo))]
        public IHttpActionResult GetArticulo(int id)
        {
            Articulo articulo = db.ArticuloSet.Find(id);
            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(articulo);
        }

        // PUT: api/Articulos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticulo(int id, Articulo articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articulo.Id)
            {
                return BadRequest();
            }

            db.Entry(articulo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Articulos
        [ResponseType(typeof(Articulo))]
        public IHttpActionResult PostArticulo(Articulo articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {                          
                if (articulo == null || articulo.Nombre == null)
                    return BadRequest();    //no acepta null
                else
                {
                    db.ArticuloSet.Add(articulo);
                    db.SaveChanges();
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = articulo.Id }, articulo);
        }

        // DELETE: api/Articulos/5
        [ResponseType(typeof(Articulo))]
        public IHttpActionResult DeleteArticulo(int id)
        {
            Articulo articulo = db.ArticuloSet.Find(id);
            if (articulo == null)
            {
                return NotFound();
            }

            db.ArticuloSet.Remove(articulo);
            db.SaveChanges();

            return Ok(articulo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticuloExists(int id)
        {
            return db.ArticuloSet.Count(e => e.Id == id) > 0;
        }
    }
}