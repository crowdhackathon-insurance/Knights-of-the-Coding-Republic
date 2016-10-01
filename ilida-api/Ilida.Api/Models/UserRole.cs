using Newtonsoft.Json;

namespace Ilida.Api.Models
{
    public class UserRole
    {
        public long Id { get; set; }

        [JsonIgnore]
        public long UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public long RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}