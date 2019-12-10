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
    public class FacturasController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/Facturas
        public IQueryable<Factura> GetFacturaSet()
        {
            return db.FacturaSet;
        }

        // GET: api/Facturas/5
        [ResponseType(typeof(Factura))]
        public IHttpActionResult GetFactura(int id)
        {
            Factura factura = db.FacturaSet.Find(id);
            if (factura == null)
            {
                return NotFound();
            }

            return Ok(factura);
        }

        // PUT: api/Facturas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFactura(int id, Factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factura.Id)
            {
                return BadRequest();
            }

            db.Entry(factura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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

        // POST: api/Facturas
        [ResponseType(typeof(Factura))]
        public IHttpActionResult PostFactura(Factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FacturaSet.Add(factura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = factura.Id }, factura);
        }

        // DELETE: api/Facturas/5
        [ResponseType(typeof(Factura))]
        public IHttpActionResult DeleteFactura(int id)
        {
            Factura factura = db.FacturaSet.Find(id);
            if (factura == null)
            {
                return NotFound();
            }

            db.FacturaSet.Remove(factura);
            db.SaveChanges();

            return Ok(factura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacturaExists(int id)
        {
            return db.FacturaSet.Count(e => e.Id == id) > 0;
        }
    }
}