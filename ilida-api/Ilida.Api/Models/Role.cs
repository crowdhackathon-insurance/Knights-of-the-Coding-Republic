using System.ComponentModel.DataAnnotations;

namespace Ilida.Api.Models
{
    public class Role
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}