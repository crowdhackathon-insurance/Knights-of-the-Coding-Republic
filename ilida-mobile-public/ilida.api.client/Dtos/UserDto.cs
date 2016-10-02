using Ilida.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ilida.Api.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string IdCard { get; set; }

        public Company Company { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}