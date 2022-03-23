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
    public class DetailPlanController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/DetailPlan
        public IQueryable<DetailPlan> GetDetailPlans()
        {
            return db.DetailPlans;
        }

        // GET: api/DetailPlan/5
        [ResponseType(typeof(DetailPlan))]
        public IHttpActionResult GetDetailPlan(int id)
        {
            DetailPlan detailPlan = db.DetailPlans.Find(id);
            if (detailPlan == null)
            {
                return NotFound();
            }

            return Ok(detailPlan);
        }

        // PUT: api/DetailPlan/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetailPlan(int id, DetailPlan detailPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detailPlan.Id)
            {
                return BadRequest();
            }

            db.Entry(detailPlan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailPlanExists(id))
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

        // POST: api/DetailPlan
        [ResponseType(typeof(DetailPlan))]
        public IHttpActionResult PostDetailPlan(DetailPlan detailPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetailPlans.Add(detailPlan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detailPlan.Id }, detailPlan);
        }

        // DELETE: api/DetailPlan/5
        [ResponseType(typeof(DetailPlan))]
        public IHttpActionResult DeleteDetailPlan(int id)
        {
            DetailPlan detailPlan = db.DetailPlans.Find(id);
            if (detailPlan == null)
            {
                return NotFound();
            }

            db.DetailPlans.Remove(detailPlan);
            db.SaveChanges();

            return Ok(detailPlan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetailPlanExists(int id)
        {
            return db.DetailPlans.Count(e => e.Id == id) > 0;
        }
    }
}