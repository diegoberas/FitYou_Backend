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
    public class TelecablePackageController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/TelecablePackage
        public IQueryable<TelecablePackage> GetTelecablePackages()
        {
            return db.TelecablePackages;
        }

        // GET: api/TelecablePackage/5
        [ResponseType(typeof(TelecablePackage))]
        public IHttpActionResult GetTelecablePackage(int id)
        {
            TelecablePackage telecablePackage = db.TelecablePackages.Find(id);
            if (telecablePackage == null)
            {
                return NotFound();
            }

            return Ok(telecablePackage);
        }

        // PUT: api/TelecablePackage/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelecablePackage(int id, TelecablePackage telecablePackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telecablePackage.Id)
            {
                return BadRequest();
            }

            db.Entry(telecablePackage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelecablePackageExists(id))
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

        // POST: api/TelecablePackage
        [ResponseType(typeof(TelecablePackage))]
        public IHttpActionResult PostTelecablePackage(TelecablePackage telecablePackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TelecablePackages.Add(telecablePackage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = telecablePackage.Id }, telecablePackage);
        }

        // DELETE: api/TelecablePackage/5
        [ResponseType(typeof(TelecablePackage))]
        public IHttpActionResult DeleteTelecablePackage(int id)
        {
            TelecablePackage telecablePackage = db.TelecablePackages.Find(id);
            if (telecablePackage == null)
            {
                return NotFound();
            }

            db.TelecablePackages.Remove(telecablePackage);
            db.SaveChanges();

            return Ok(telecablePackage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelecablePackageExists(int id)
        {
            return db.TelecablePackages.Count(e => e.Id == id) > 0;
        }
    }
}