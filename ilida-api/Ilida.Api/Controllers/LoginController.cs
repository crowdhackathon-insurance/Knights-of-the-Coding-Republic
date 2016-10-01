using Ilida.Api.Dtos;
using Ilida.Api.Mappers;
using Ilida.Api.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Ilida.Api.Controllers
{
    public class LoginController : ApiController
    {
        private IlidaApiContext db = new IlidaApiContext();
        private readonly IMapper<User, UserDto> _userDtoMapper;

        public LoginController(
            IMapper<User, UserDto> userDtoMapper)
        {
            if (userDtoMapper == null) throw new ArgumentNullException("userDtoMapper");

            _userDtoMapper = userDtoMapper;
        }

        // POST: api/login
        [ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> Post([FromBody] LoginRequest loginRequest)
        {
            User user = await db.Users.Where(x => x.Username == loginRequest.Username && x.Password == loginRequest.Password).FirstOrDefaultAsync();
            if (user == null)
            {
                return Unauthorized();
            }

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
    }
}