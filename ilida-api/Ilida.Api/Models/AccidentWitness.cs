using System.ComponentModel.DataAnnotations;

namespace Ilida.Api.Models
{
    public class AccidentWitness
    {
        public long Id { get; set; }

        [Required]
        [StringLength(10)]
        public string IdCard { get; set; }

        public long AccidentId { get; set; }

        public virtual Accident Accident { get; set; }
    }
}