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
    public class TelecableController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/Telecable
        public IQueryable<Telecable> GetTelecables()
        {
            return db.Telecables;
        }

        // GET: api/Telecable/5
        [ResponseType(typeof(Telecable))]
        public IHttpActionResult GetTelecable(int id)
        {
            Telecable telecable = db.Telecables.Find(id);
            if (telecable == null)
            {
                return NotFound();
            }

            return Ok(telecable);
        }

        // PUT: api/Telecable/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelecable(int id, Telecable telecable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telecable.Id)
            {
                return BadRequest();
            }

            db.Entry(telecable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelecableExists(id))
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

        // POST: api/Telecable
        [ResponseType(typeof(Telecable))]
        public IHttpActionResult PostTelecable(Telecable telecable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telecables.Add(telecable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = telecable.Id }, telecable);
        }

        // DELETE: api/Telecable/5
        [ResponseType(typeof(Telecable))]
        public IHttpActionResult DeleteTelecable(int id)
        {
            Telecable telecable = db.Telecables.Find(id);
            if (telecable == null)
            {
                return NotFound();
            }

            db.Telecables.Remove(telecable);
            db.SaveChanges();

            return Ok(telecable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelecableExists(int id)
        {
            return db.Telecables.Count(e => e.Id == id) > 0;
        }
    }
}