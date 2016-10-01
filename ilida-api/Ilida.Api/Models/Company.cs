using System.ComponentModel.DataAnnotations;

namespace Ilida.Api.Models
{
    public class Company
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}