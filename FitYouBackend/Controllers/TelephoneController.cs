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
    public class TelephoneController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/Telephone
        public IQueryable<Telephone> GetTelephones()
        {
            return db.Telephones;
        }

        // GET: api/Telephone/5
        [ResponseType(typeof(Telephone))]
        public IHttpActionResult GetTelephone(int id)
        {
            Telephone telephone = db.Telephones.Find(id);
            if (telephone == null)
            {
                return NotFound();
            }

            return Ok(telephone);
        }

        // PUT: api/Telephone/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelephone(int id, Telephone telephone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telephone.Id)
            {
                return BadRequest();
            }

            db.Entry(telephone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelephoneExists(id))
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

        // POST: api/Telephone
        [ResponseType(typeof(Telephone))]
        public IHttpActionResult PostTelephone(Telephone telephone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telephones.Add(telephone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = telephone.Id }, telephone);
        }

        // DELETE: api/Telephone/5
        [ResponseType(typeof(Telephone))]
        public IHttpActionResult DeleteTelephone(int id)
        {
            Telephone telephone = db.Telephones.Find(id);
            if (telephone == null)
            {
                return NotFound();
            }

            db.Telephones.Remove(telephone);
            db.SaveChanges();

            return Ok(telephone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelephoneExists(int id)
        {
            return db.Telephones.Count(e => e.Id == id) > 0;
        }
    }
}