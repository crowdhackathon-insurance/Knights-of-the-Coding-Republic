using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ilida.Api.Models
{
    public class User
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [Required]
        [StringLength(10)]
        public string IdCard { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}