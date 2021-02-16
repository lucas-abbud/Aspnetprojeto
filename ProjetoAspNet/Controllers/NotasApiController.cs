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
using ProjetoAspNet.Data;
using ProjetoAspNet.Domain;

namespace ProjetoAspNet.Controllers
{
    public class NotasApiController : ApiController
    {
        private SistemaDbContext db = new SistemaDbContext();

        // GET: api/NotasApi
        public IQueryable<Notas> GetNotas()
        {
            return db.Notas;
        }

        // GET: api/NotasApi/5
        [ResponseType(typeof(Notas))]
        public IHttpActionResult GetNotas(int id)
        {
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return NotFound();
            }

            return Ok(notas);
        }

        // PUT: api/NotasApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNotas(int id, Notas notas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notas.NotasId)
            {
                return BadRequest();
            }

            db.Entry(notas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotasExists(id))
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

        // POST: api/NotasApi
        [ResponseType(typeof(Notas))]
        public IHttpActionResult PostNotas(Notas notas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notas.Add(notas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = notas.NotasId }, notas);
        }

        // DELETE: api/NotasApi/5
        [ResponseType(typeof(Notas))]
        public IHttpActionResult DeleteNotas(int id)
        {
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return NotFound();
            }

            db.Notas.Remove(notas);
            db.SaveChanges();

            return Ok(notas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotasExists(int id)
        {
            return db.Notas.Count(e => e.NotasId == id) > 0;
        }
    }
}