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
    public class brokerrsController : ApiController
    {
        private MasterContext db = new MasterContext();

        // GET: api/brokerrs
        public IQueryable<brokerr> Getbrokerrs()
        {
            return db.brokerrs;
        }

        // GET: api/brokerrs/5
        [ResponseType(typeof(brokerr))]
        public IHttpActionResult Getbrokerr(int id)
        {
            brokerr brokerr = db.brokerrs.Find(id);
            if (brokerr == null)
            {
                return NotFound();
            }

            return Ok(brokerr);
        }

        // PUT: api/brokerrs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbrokerr(int id, brokerr brokerr)
        {
           

            if (id != brokerr.id)
            {
                return BadRequest();
            }

            db.Entry(brokerr).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!brokerrExists(id))
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

        // POST: api/brokerrs
        [ResponseType(typeof(brokerr))]
        public IHttpActionResult Postbrokerr(brokerr brokerr)
        {
           

            db.brokerrs.Add(brokerr);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brokerr.id }, brokerr);
        }

        // DELETE: api/brokerrs/5
        [ResponseType(typeof(brokerr))]
        public IHttpActionResult Deletebrokerr(int id)
        {
            brokerr brokerr = db.brokerrs.Find(id);
            if (brokerr == null)
            {
                return NotFound();
            }

            db.brokerrs.Remove(brokerr);
            db.SaveChanges();

            return Ok(brokerr);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool brokerrExists(int id)
        {
            return db.brokerrs.Count(e => e.id == id) > 0;
        }
    }
}