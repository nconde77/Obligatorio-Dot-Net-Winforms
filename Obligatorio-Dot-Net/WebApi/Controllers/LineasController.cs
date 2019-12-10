using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Core;

namespace WebApi.Controllers
{
    public class LineasController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/Lineas
        public IQueryable<Linea> GetLineaSet()
        {
            return db.LineaSet;
        }

        // GET: api/Lineas/5
        [ResponseType(typeof(Linea))]
        public IHttpActionResult GetLinea(int id)
        {
            Linea linea = db.LineaSet.Find(id);
            if (linea == null)
            {
                return NotFound();
            }

            return Ok(linea);
        }

        // PUT: api/Lineas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLinea(int id, Linea linea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linea.Id)
            {
                return BadRequest();
            }

            db.Entry(linea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaExists(id))
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

        // POST: api/Lineas
        [ResponseType(typeof(Linea))]
        public IHttpActionResult PostLinea(Linea linea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LineaSet.Add(linea);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = linea.Id }, linea);
        }

        // DELETE: api/Lineas/5
        [ResponseType(typeof(Linea))]
        public IHttpActionResult DeleteLinea(int id)
        {
            Linea linea = db.LineaSet.Find(id);
            if (linea == null)
            {
                return NotFound();
            }

            db.LineaSet.Remove(linea);
            db.SaveChanges();

            return Ok(linea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineaExists(int id)
        {
            return db.LineaSet.Count(e => e.Id == id) > 0;
        }
    }
}