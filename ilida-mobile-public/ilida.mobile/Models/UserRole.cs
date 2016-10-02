
namespace Ilida.Api.Models
{
    public class UserRole
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }

        public long RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}