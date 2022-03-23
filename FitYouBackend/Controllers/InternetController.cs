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
using FitYouBackend.Models;

namespace FitYouBackend.Controllers
{
    public class InternetController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/Internet
        public IQueryable<Internet> GetInternets()
        {
            return db.Internets;
        }

        // GET: api/Internet/5
        [ResponseType(typeof(Internet))]
        public IHttpActionResult GetInternet(int id)
        {
            Internet internet = db.Internets.Find(id);
            if (internet == null)
            {
                return NotFound();
            }

            return Ok(internet);
        }

        // PUT: api/Internet/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInternet(int id, Internet internet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != internet.Id)
            {
                return BadRequest();
            }

            db.Entry(internet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternetExists(id))
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

        // POST: api/Internet
        [ResponseType(typeof(Internet))]
        public IHttpActionResult PostInternet(Internet internet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Internets.Add(internet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = internet.Id }, internet);
        }

        // DELETE: api/Internet/5
        [ResponseType(typeof(Internet))]
        public IHttpActionResult DeleteInternet(int id)
        {
            Internet internet = db.Internets.Find(id);
            if (internet == null)
            {
                return NotFound();
            }

            db.Internets.Remove(internet);
            db.SaveChanges();

            return Ok(internet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InternetExists(int id)
        {
            return db.Internets.Count(e => e.Id == id) > 0;
        }
    }
}