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
using APIpractice.Models;

namespace APIpractice.Controllers
{
    public class FacctoriesController : ApiController
    {
        private APIEntities db = new APIEntities();

        // GET: api/Facctories
        public IQueryable<Facctory> GetFacctories()
        {
            return db.Facctories;
        }

        // GET: api/Facctories/5
        [ResponseType(typeof(Facctory))]
        public IHttpActionResult GetFacctory(int id)
        {
            Facctory facctory = db.Facctories.Find(id);
            if (facctory == null)
            {
                return NotFound();
            }

            return Ok(facctory);
        }

        // PUT: api/Facctories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFacctory(int id, Facctory facctory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facctory.ID)
            {
                return BadRequest();
            }

            db.Entry(facctory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacctoryExists(id))
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

        // POST: api/Facctories
        [ResponseType(typeof(Facctory))]
        public IHttpActionResult PostFacctory(Facctory facctory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Facctories.Add(facctory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = facctory.ID }, facctory);
        }

        // DELETE: api/Facctories/5
        [ResponseType(typeof(Facctory))]
        public IHttpActionResult DeleteFacctory(int id)
        {
            Facctory facctory = db.Facctories.Find(id);
            if (facctory == null)
            {
                return NotFound();
            }

            db.Facctories.Remove(facctory);
            db.SaveChanges();

            return Ok(facctory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacctoryExists(int id)
        {
            return db.Facctories.Count(e => e.ID == id) > 0;
        }
    }
}