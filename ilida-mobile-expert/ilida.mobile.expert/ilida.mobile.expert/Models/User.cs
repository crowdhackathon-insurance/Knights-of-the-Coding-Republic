using System.Collections.Generic;

namespace Ilida.Api.Models
{
    public class User
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }

        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string IdCard { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}