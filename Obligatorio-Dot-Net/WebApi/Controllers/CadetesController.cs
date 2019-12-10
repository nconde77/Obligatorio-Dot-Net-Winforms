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
    public class CadetesController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/Cadetes
        public IQueryable<Cadete> GetCadeteSet()
        {
            return db.CadeteSet;
        }

        // GET: api/Cadetes/5
        [ResponseType(typeof(Cadete))]
        public IHttpActionResult GetCadete(int id)
        {
            Cadete cadete = db.CadeteSet.Find(id);
            if (cadete == null)
            {
                return NotFound();
            }

            return Ok(cadete);
        }

        // PUT: api/Cadetes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCadete(int id, Cadete cadete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cadete.Id)
            {
                return BadRequest();
            }

            db.Entry(cadete).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadeteExists(id))
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

        // POST: api/Cadetes
        [ResponseType(typeof(Cadete))]
        public IHttpActionResult PostCadete(Cadete cadete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CadeteSet.Add(cadete);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cadete.Id }, cadete);
        }

        // DELETE: api/Cadetes/5
        [ResponseType(typeof(Cadete))]
        public IHttpActionResult DeleteCadete(int id)
        {
            Cadete cadete = db.CadeteSet.Find(id);
            if (cadete == null)
            {
                return NotFound();
            }

            db.CadeteSet.Remove(cadete);
            db.SaveChanges();

            return Ok(cadete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CadeteExists(int id)
        {
            return db.CadeteSet.Count(e => e.Id == id) > 0;
        }
    }
}