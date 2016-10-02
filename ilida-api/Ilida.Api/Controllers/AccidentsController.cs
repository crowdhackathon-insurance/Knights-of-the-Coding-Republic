using Ilida.Api.Dtos;
using Ilida.Api.Mappers;
using Ilida.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Ilida.Api.Controllers
{
    public class AccidentsController : ApiController
    {
        private IlidaApiContext db = new IlidaApiContext();
        private readonly IMapper<Accident, AccidentDto> _accidentDtoMapper;

        public AccidentsController(
            IMapper<Accident, AccidentDto> accidentDtoMapper)
        {
            if (accidentDtoMapper == null) throw new ArgumentNullException("accidentDtoMapper");

            _accidentDtoMapper = accidentDtoMapper;
        }

        // GET: api/Accidents
        public IEnumerable<AccidentDto> GetAccidents()
        {
            return _accidentDtoMapper.Map(db.Accidents.ToList());
        }

        // GET: api/Accidents/5
        [ResponseType(typeof(AccidentDto))]
        public async Task<IHttpActionResult> GetAccident(long id)
        {
            Accident accident = await db.Accidents.FindAsync(id);
            if (accident == null)
            {
                return NotFound();
            }

            return Ok(_accidentDtoMapper.Map(accident));
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
        [ResponseType(typeof(AccidentDto))]
        public async Task<IHttpActionResult> PostAccident(Accident accident)
        {
            accident.WorkflowStatus = await db.WorkflowStatuses.FindAsync(2);
            accident.WorkflowStatusId = accident.WorkflowStatus.Id;
            accident.User = await db.Users.FindAsync(accident.UserId);

            // Verify user exists
            if (accident.User == null)
            {
                ModelState.AddModelError("UserId", "Specified user does not exist");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accidents.Add(accident);
            await db.SaveChangesAsync();

            var accidentAction = new AccidentAction
            {
                Timestamp = DateTime.UtcNow,
                UserId = accident.UserId,
                WorkflowActionId = 1,
                WorkflowAction = await db.WorkflowActions.FindAsync(1),
                Accident = accident,
                PreviousWorkflowStatusId = 1,
                NextWorkflowStatusId = 3,
                Comment = "Αριθμός ατυχήματος: " + accident.Id
            };

            accident.AccidentActions.Add(accidentAction);

            db.Entry(accident).State = EntityState.Modified;
            await db.SaveChangesAsync();

            //accident = await db.Accidents.FirstOrDefaultAsync(x => x.Id == accident.Id);

            return CreatedAtRoute("DefaultApi", new { id = accident.Id }, _accidentDtoMapper.Map(accident));
        }

        // POST: api/Accidents/5/processed
        [ResponseType(typeof(AccidentDto))]
        public async Task<IHttpActionResult> ProcessAccident(long id, long actionFromUserId)
        {
            Accident accident = await db.Accidents.FindAsync(id);
            if (accident == null)
            {
                return NotFound();
            }

            var lastAction = accident.AccidentActions.Last();

            var action = new AccidentAction
            {
                Timestamp = DateTime.UtcNow,
                UserId = accident.UserId,
                WorkflowActionId = 2,
                WorkflowAction = await db.WorkflowActions.FindAsync(2),
                Accident = accident,
                PreviousWorkflowStatusId = lastAction.WorkflowActionId,
                NextWorkflowStatusId = 3,
                Comment = "Από: " + actionFromUserId
            };
            accident.AccidentActions.Add(action);
            accident.WorkflowStatusId++;
            accident.WorkflowStatus = await db.WorkflowStatuses.FindAsync(accident.WorkflowStatusId);

            db.Entry(accident).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return Ok(_accidentDtoMapper.Map(accident));
        }

        // DELETE: api/Accidents/5
        [ResponseType(typeof(AccidentDto))]
        public async Task<IHttpActionResult> DeleteAccident(long id)
        {
            Accident accident = await db.Accidents.FindAsync(id);
            if (accident == null)
            {
                return NotFound();
            }

            db.Accidents.Remove(accident);
            await db.SaveChangesAsync();

            return Ok(_accidentDtoMapper.Map(accident));
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