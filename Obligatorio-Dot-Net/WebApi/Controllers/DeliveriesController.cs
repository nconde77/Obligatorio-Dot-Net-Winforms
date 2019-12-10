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
    public class DeliveriesController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/Deliveries
        public IQueryable<Delivery> GetDeliverySet()
        {
            return db.DeliverySet;
        }

        // GET: api/Deliveries/5
        [ResponseType(typeof(Delivery))]
        public IHttpActionResult GetDelivery(int id)
        {
            Delivery delivery = db.DeliverySet.Find(id);
            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        // PUT: api/Deliveries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDelivery(int id, Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != delivery.Id)
            {
                return BadRequest();
            }

            db.Entry(delivery).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(id))
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

        // POST: api/Deliveries
        [ResponseType(typeof(Delivery))]
        public IHttpActionResult PostDelivery(Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeliverySet.Add(delivery);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = delivery.Id }, delivery);
        }

        // DELETE: api/Deliveries/5
        [ResponseType(typeof(Delivery))]
        public IHttpActionResult DeleteDelivery(int id)
        {
            Delivery delivery = db.DeliverySet.Find(id);
            if (delivery == null)
            {
                return NotFound();
            }

            db.DeliverySet.Remove(delivery);
            db.SaveChanges();

            return Ok(delivery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryExists(int id)
        {
            return db.DeliverySet.Count(e => e.Id == id) > 0;
        }
    }
}