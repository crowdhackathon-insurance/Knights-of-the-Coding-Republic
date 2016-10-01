using Ilida.Api.Dtos;
using Ilida.Api.Models;
using System.Linq;

namespace Ilida.Api.Mappers
{
    public class UserDtoMapper : BaseMapper<User, UserDto>
    {
        public override UserDto Map(User user)
        {
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
                IdCard = user.IdCard,
                Company = user.Company,
                Roles = user.UserRoles.Select(x => x.Role),
            };
        }
    }
}