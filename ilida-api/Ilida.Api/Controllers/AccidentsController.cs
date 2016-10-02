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
    [RoutePrefix("api/accidents")]
    public class AccidentsController : ApiController
    {
        private IlidaApiContext db = new IlidaApiContext();
        private readonly IMapper<Accident, AccidentDto> _accidentDtoMapper;
        private readonly IMapper<CreateAccidentRequest, Accident> _accidentFromCreateRequestMapper;

        public AccidentsController(
            IMapper<Accident, AccidentDto> accidentDtoMapper,
            IMapper<CreateAccidentRequest, Accident> accidentFromCreateRequestMapper)
        {
            if (accidentDtoMapper == null) throw new ArgumentNullException("accidentDtoMapper");
            if (accidentFromCreateRequestMapper == null) throw new ArgumentNullException("accidentFromCreateRequestMapper");

            _accidentDtoMapper = accidentDtoMapper;
            _accidentFromCreateRequestMapper = accidentFromCreateRequestMapper;
        }

        // GET: api/Accidents
        public IEnumerable<AccidentDto> GetAccidents(long userId = 0, long workflowStatusId = 0)
        {
            var query = db.Accidents.AsQueryable();
            if (userId > 0)
            {
                query = query.Where(x => x.UserId == userId);
            }

            if (workflowStatusId > 0)
            {
                query = query.Where(x => x.WorkflowStatusId >= workflowStatusId);
            }


            return _accidentDtoMapper.Map(query.ToList());
        }

        // GET: api/Accidents/5
        [ResponseType(typeof(AccidentDto))]
        public async Task<IHttpActionResult> GetAccident(long id, long userId = 0)
        {
            Accident accident = await db.Accidents.FindAsync(id);
            if (accident == null ||
                (userId > 0 && accident.UserId != userId))
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
        public async Task<IHttpActionResult> PostAccident(CreateAccidentRequest request)
        {
            var accident = _accidentFromCreateRequestMapper.Map(request);

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
                NextWorkflowStatusId = 2,
                Comment = "Αριθμός ατυχήματος: " + accident.Id
            };

            accident.AccidentActions.Add(accidentAction);

            // Add some fixed companies for now => this is to be populated by an async worker.
            // The worker will hit several data APIs/sources to find as many data as it can.
            accident.AccidentCompanies.Add(
                new AccidentCompany
                {
                    AccidentId = accident.Id,
                    CompanyId = 1,
                    Company = await db.Companies.FindAsync(1)
                });
            accident.AccidentCompanies.Add(new AccidentCompany
            {
                AccidentId = accident.Id,
                CompanyId = 2,
                Company = await db.Companies.FindAsync(2)
            });

            db.Entry(accident).State = EntityState.Modified;
            await db.SaveChangesAsync();

            //accident = await db.Accidents.FirstOrDefaultAsync(x => x.Id == accident.Id);

            return CreatedAtRoute("DefaultApi", new { id = accident.Id }, _accidentDtoMapper.Map(accident));
        }

        // POST: api/Accidents/5/processed
        [HttpPost]
        [Route("{id}/process")]
        [ResponseType(typeof(AccidentDto))]
        public async Task<IHttpActionResult> ProcessAccident(long id, long userId)
        {
            Accident accident = await db.Accidents.FindAsync(id);
            if (accident == null)
            {
                return NotFound();
            }

            db.Entry(accident).State = EntityState.Modified;

            var action = new AccidentAction
            {
                Timestamp = DateTime.UtcNow,
                UserId = userId,
                WorkflowActionId = 2,
                WorkflowAction = await db.WorkflowActions.FindAsync(2),
                Accident = accident,
                PreviousWorkflowStatusId = 0,
                NextWorkflowStatusId = 0,
                Comment = "Από: " + userId
            };
            accident.AccidentActions.Add(action);
            accident.WorkflowStatusId = 3;
            accident.WorkflowStatus = await db.WorkflowStatuses.FindAsync(accident.WorkflowStatusId);

            await db.SaveChangesAsync();

            return Ok(_accidentDtoMapper.Map(accident));
        }

        // POST: api/Accidents/5/accept
        [HttpPost]
        [Route("{id}/accept")]
        [ResponseType(typeof(AccidentDto))]
        public async Task<IHttpActionResult> AcceptAccident(long id, long userId)
        {
            Accident accident = await db.Accidents.FindAsync(id);
            if (accident == null)
            {
                return NotFound();
            }

            var action = new AccidentAction
            {
                Timestamp = DateTime.UtcNow,
                UserId = userId,
                WorkflowActionId = 3,
                WorkflowAction = await db.WorkflowActions.FindAsync(3),
                Accident = accident,
                PreviousWorkflowStatusId = 0,
                NextWorkflowStatusId = 0,
                Comment = "Από: " + userId
            };
            accident.AccidentActions.Add(action);
            accident.WorkflowStatusId = 4;
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