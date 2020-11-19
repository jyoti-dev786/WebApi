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
using broker.Models;

namespace broker.Controllers
{
    public class pointssesController : ApiController
    {
        private MasterContext db = new MasterContext();

        // GET: api/pointsses
        public IQueryable<pointss> Getpointsses()
        {
            return db.pointsses;
        }

        // GET: api/pointsses/5
        [ResponseType(typeof(pointss))]
        public IHttpActionResult Getpointss(int id)
        {
            pointss pointss = db.pointsses.Find(id);
            if (pointss == null)
            {
                return NotFound();
            }

            return Ok(pointss);
        }

        // PUT: api/pointsses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpointss(int id, pointss pointss)
        {
           

            if (id != pointss.id)
            {
                return BadRequest();
            }

            db.Entry(pointss).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pointssExists(id))
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

        // POST: api/pointsses
        [ResponseType(typeof(pointss))]
        public IHttpActionResult Postpointss(pointss pointss)
        {
            

            db.pointsses.Add(pointss);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pointss.id }, pointss);
        }

        // DELETE: api/pointsses/5
        [ResponseType(typeof(pointss))]
        public IHttpActionResult Deletepointss(int id)
        {
            pointss pointss = db.pointsses.Find(id);
            if (pointss == null)
            {
                return NotFound();
            }

            db.pointsses.Remove(pointss);
            db.SaveChanges();

            return Ok(pointss);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pointssExists(int id)
        {
            return db.pointsses.Count(e => e.id == id) > 0;
        }
    }
}