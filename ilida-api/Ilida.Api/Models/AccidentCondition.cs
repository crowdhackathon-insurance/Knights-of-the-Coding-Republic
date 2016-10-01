using System.ComponentModel.DataAnnotations;

namespace Ilida.Api.Models
{
    public class AccidentCondition
    {
        public long Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}