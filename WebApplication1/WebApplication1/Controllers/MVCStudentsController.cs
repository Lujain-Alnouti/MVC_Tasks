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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MVCStudentsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/MVCStudents
        public IQueryable<MVCStudent> GetMVCStudents()
        {
            return db.MVCStudents;
        }

        // GET: api/MVCStudents/5
        [ResponseType(typeof(MVCStudent))]
        public IHttpActionResult GetMVCStudent(int id)
        {
            MVCStudent mVCStudent = db.MVCStudents.Find(id);
            if (mVCStudent == null)
            {
                return NotFound();
            }

            return Ok(mVCStudent);
        }

        // PUT: api/MVCStudents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMVCStudent(int id, MVCStudent mVCStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mVCStudent.StudentID)
            {
                return BadRequest();
            }

            db.Entry(mVCStudent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MVCStudentExists(id))
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

        // POST: api/MVCStudents
        [ResponseType(typeof(MVCStudent))]
        public IHttpActionResult PostMVCStudent(MVCStudent mVCStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MVCStudents.Add(mVCStudent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mVCStudent.StudentID }, mVCStudent);
        }

        // DELETE: api/MVCStudents/5
        [ResponseType(typeof(MVCStudent))]
        public IHttpActionResult DeleteMVCStudent(int id)
        {
            MVCStudent mVCStudent = db.MVCStudents.Find(id);
            if (mVCStudent == null)
            {
                return NotFound();
            }

            db.MVCStudents.Remove(mVCStudent);
            db.SaveChanges();

            return Ok(mVCStudent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MVCStudentExists(int id)
        {
            return db.MVCStudents.Count(e => e.StudentID == id) > 0;
        }
    }
}