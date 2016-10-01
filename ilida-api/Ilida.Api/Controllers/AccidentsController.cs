using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Ilida.Api.Models;

namespace Ilida.Api.Controllers
{
    public class AccidentsController : ApiController
    {
        private IlidaApiContext db = new IlidaApiContext();

        // GET: api/Accidents
        public IQueryable<Accident> GetAccidents()
        {
            return db.Accidents;
        }

        // GET: api/Accidents/5
        [ResponseType(typeof(Accident))]
        public async Task<IHttpActionResult> GetAccident(long id)
        {
            Accident accident = await db.Accidents.FindAsync(id);
            if (accident == null)
            {
                return NotFound();
            }

            return Ok(accident);
        }

        // PUT: api/Accidents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAccident(long id, Accident accident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accident.Id)
            {
                return BadRequest();
            }

            db.Entry(accident).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccidentExists(id))
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

        // POST: api/Accidents
        [ResponseType(typeof(Accident))]
        public async Task<IHttpActionResult> PostAccident(Accident accident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accidents.Add(accident);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = accident.Id }, accident);
        }

        // DELETE: api/Accidents/5
        [ResponseType(typeof(Accident))]
        public async Task<IHttpActionResult> DeleteAccident(long id)
        {
            Accident accident = await db.Accidents.FindAsync(id);
            if (accident == null)
            {
                return NotFound();
            }

            db.Accidents.Remove(accident);
            await db.SaveChangesAsync();

            return Ok(accident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccidentExists(long id)
        {
            return db.Accidents.Count(e => e.Id == id) > 0;
        }
    }
}