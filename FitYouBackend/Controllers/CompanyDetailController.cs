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
    public class CompanyDetailController : ApiController
    {
        private FityouContext db = new FityouContext();

        // GET: api/CompanyDetail
        public IQueryable<CompanyDetail> GetCompanyDetails()
        {
            return db.CompanyDetails;
        }

        // GET: api/CompanyDetail/5
        [ResponseType(typeof(CompanyDetail))]
        public IHttpActionResult GetCompanyDetail(int id)
        {
            CompanyDetail companyDetail = db.CompanyDetails.Find(id);
            if (companyDetail == null)
            {
                return NotFound();
            }

            return Ok(companyDetail);
        }

        // PUT: api/CompanyDetail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyDetail(int id, CompanyDetail companyDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(companyDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyDetailExists(id))
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

        // POST: api/CompanyDetail
        [ResponseType(typeof(CompanyDetail))]
        public IHttpActionResult PostCompanyDetail(CompanyDetail companyDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyDetails.Add(companyDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = companyDetail.Id }, companyDetail);
        }

        // DELETE: api/CompanyDetail/5
        [ResponseType(typeof(CompanyDetail))]
        public IHttpActionResult DeleteCompanyDetail(int id)
        {
            CompanyDetail companyDetail = db.CompanyDetails.Find(id);
            if (companyDetail == null)
            {
                return NotFound();
            }

            db.CompanyDetails.Remove(companyDetail);
            db.SaveChanges();

            return Ok(companyDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyDetailExists(int id)
        {
            return db.CompanyDetails.Count(e => e.Id == id) > 0;
        }
    }
}