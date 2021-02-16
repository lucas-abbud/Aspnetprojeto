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
    public class CadernosApiController : ApiController
    {
        private SistemaDbContext db = new SistemaDbContext();

        // GET: api/CadernosApi
        public IQueryable<Caderno> GetCadernoes()
        {
            return db.Cadernoes;
        }

        // GET: api/CadernosApi/5
        [ResponseType(typeof(Caderno))]
        public IHttpActionResult GetCaderno(int id)
        {
            Caderno caderno = db.Cadernoes.Find(id);
            if (caderno == null)
            {
                return NotFound();
            }

            return Ok(caderno);
        }

        // PUT: api/CadernosApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCaderno(int id, Caderno caderno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caderno.CadernoId)
            {
                return BadRequest();
            }

            db.Entry(caderno).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadernoExists(id))
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

        // POST: api/CadernosApi
        [ResponseType(typeof(Caderno))]
        public IHttpActionResult PostCaderno(Caderno caderno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cadernoes.Add(caderno);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = caderno.CadernoId }, caderno);
        }

        // DELETE: api/CadernosApi/5
        [ResponseType(typeof(Caderno))]
        public IHttpActionResult DeleteCaderno(int id)
        {
            Caderno caderno = db.Cadernoes.Find(id);
            if (caderno == null)
            {
                return NotFound();
            }

            db.Cadernoes.Remove(caderno);
            db.SaveChanges();

            return Ok(caderno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CadernoExists(int id)
        {
            return db.Cadernoes.Count(e => e.CadernoId == id) > 0;
        }
    }
}