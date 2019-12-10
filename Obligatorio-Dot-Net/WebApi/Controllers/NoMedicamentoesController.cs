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
    public class NoMedicamentoesController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/NoMedicamentoes
        public IQueryable<NoMedicamento> GetNoMedicamentoes()
        {
            return db.NoMedicamentoes;
        }

        // GET: api/NoMedicamentoes/5
        [ResponseType(typeof(NoMedicamento))]
        public IHttpActionResult GetNoMedicamento(int id)
        {
            NoMedicamento noMedicamento = db.NoMedicamentoes.Find(id);
            if (noMedicamento == null)
            {
                return NotFound();
            }

            return Ok(noMedicamento);
        }

        // PUT: api/NoMedicamentoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNoMedicamento(int id, NoMedicamento noMedicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != noMedicamento.Id)
            {
                return BadRequest();
            }

            db.Entry(noMedicamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoMedicamentoExists(id))
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

        // POST: api/NoMedicamentoes
        [ResponseType(typeof(NoMedicamento))]
        public IHttpActionResult PostNoMedicamento(NoMedicamento noMedicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NoMedicamentoes.Add(noMedicamento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = noMedicamento.Id }, noMedicamento);
        }

        // DELETE: api/NoMedicamentoes/5
        [ResponseType(typeof(NoMedicamento))]
        public IHttpActionResult DeleteNoMedicamento(int id)
        {
            NoMedicamento noMedicamento = db.NoMedicamentoes.Find(id);
            if (noMedicamento == null)
            {
                return NotFound();
            }

            db.NoMedicamentoes.Remove(noMedicamento);
            db.SaveChanges();

            return Ok(noMedicamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoMedicamentoExists(int id)
        {
            return db.NoMedicamentoes.Count(e => e.Id == id) > 0;
        }
    }
}