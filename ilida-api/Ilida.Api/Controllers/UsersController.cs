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
using Ilida.Api.Dtos;
using Ilida.Api.Mappers;

namespace Ilida.Api.Controllers
{
    public class UsersController : ApiController
    {
        private IlidaApiContext db = new IlidaApiContext();
        private readonly IMapper<User, UserDto> _userDtoMapper;

        public UsersController(
            IMapper<User, UserDto> userDtoMapper)
        {
            if (userDtoMapper == null) throw new ArgumentNullException("userDtoMapper");

            _userDtoMapper = userDtoMapper;
        }
        // GET: api/Users
        public IEnumerable<UserDto> GetUsers()
        {
            return _userDtoMapper.Map(db.Users.ToList());
        }

        // GET: api/Users/5
        [ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> GetUser(long id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_userDtoMapper.Map(user));
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(long id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, _userDtoMapper.Map(user));
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> DeleteUser(long id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(_userDtoMapper.Map(user));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(long id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}